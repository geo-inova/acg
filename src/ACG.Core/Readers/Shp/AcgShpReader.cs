using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using DotNetDBF;
using GeoAPI.Geometries;
using NetTopologySuite;
using NetTopologySuite.Geometries;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Data reader for ESRI SHP files.
    /// </summary>
    public class AcgShpReader : AcgReader
    {
        /// <inheritdoc/>
        public override List<IAcgObject> Read(string filePath)
        {
            string dbFilePath = filePath.Substring(0, filePath.Length - 4) + ".dbf";

            List<IAcgObject> objectList = new List<IAcgObject>();

            using (Shapefile shapefile = new Readers.Shapefile(filePath))
            {
                foreach (Shape shape in shapefile)
                {
                    AcgBuilding building = new AcgBuilding();

                    switch (shape.Type)
                    {
                        case ShapeType.Polygon:
                            ShapePolygon shapePolygon = shape as ShapePolygon;
                            List<Coordinate> points = new List<Coordinate>();
                            foreach (PointD[] part in shapePolygon.Parts)
                            {
                                Coordinate coordinate = new Coordinate();
                                foreach (PointD point in part)
                                {
                                    points.Add(new Coordinate(point.X, point.Y));
                                }
                                LinearRing linearRing = new LinearRing(points.ToArray());
                                Polygon polygon = new Polygon(linearRing);
                                building.Geometry = polygon;
                            }
                            break;

                        default:
                            break;
                    }
                    objectList.Add(building);
                }
            }

            var reader = new DBFReader(dbFilePath);
            AcgMappingDictionary dictionary = new AcgMappingDictionary();

            string mappingfilePath = ""; //path to .mapping file
            dictionary.Read(mappingfilePath);
            string key = "";

            foreach (int i in Enumerable.Range(0, reader.RecordCount))
            {
                object[] objects = reader.NextRecord();
                DBFField[] dbffields = reader.Fields;

                if (objectList[i].ObjectType == AcgObjectType.Building) key = "AcgBuilding";
                else key = "AcgParcel";

                List<AcgMapping> mappingList = dictionary[key];
                foreach (AcgMapping mapping in mappingList)
                {
                    string value = "";
                    foreach (int j in Enumerable.Range(0, dbffields.Count()))
                    {
                        if (dbffields[j].Name == mapping.Target) value = objects[j].ToString();
                    }
                    AcgBuilding _building = objectList[i] as AcgBuilding;
                    switch (mapping.Source)
                    {
                        case "TotalGrossSurface":
                            _building.TotalGrossSurfaceFixed = Convert.ToDouble(value);
                            objectList[i] = _building;
                            break;
                        case "StreetName":
                            _building.StreetName = value;
                            objectList[i] = _building;
                            break;
                        case "Description":
                            _building.Description = value;
                            objectList[i] = _building;
                            break;
                        case "StreetNumber":
                            _building.StreetNumber = value;
                            objectList[i] = _building;
                            break;
                    }
                }
            }

            return objectList;
        }
    }
}
