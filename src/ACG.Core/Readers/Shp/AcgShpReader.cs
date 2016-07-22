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

            var reader = new DBFReader(filePath);
            foreach (int i in Enumerable.Range(0, reader.RecordCount))
            {
                object[] objects = reader.NextRecord();
                DBFField[] dbf = reader.Fields;
                foreach (int j in Enumerable.Range(0, dbf.Count()))
                {
                    objectList[i].Metadata += dbf[j].Name + "=" + objects[j];
                }
            }
            return objectList;
        }
    }
}
