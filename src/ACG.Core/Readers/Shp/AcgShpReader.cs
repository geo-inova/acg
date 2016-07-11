using System;
using System.Collections.Generic;
using System.Text;
using NetTopologySuite;

using ACG.Core.Objects;
using NetTopologySuite.Geometries;
using GeoAPI.Geometries;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Data reader for ESRI SHP files.
    /// </summary>
    public class AcgShpReader : IAcgReader
    {
        /// <inheritdoc/>
        public List<IAcgObject> Read(string filePath)
        {
            List<IAcgObject> objectList = new List<IAcgObject>();

            using (Shapefile shapefile = new Readers.Shapefile(filePath))
            {
                foreach (Shape shape in shapefile)
                {
                    AcgBuilding building = new AcgBuilding();

                    string[] metadataNames = shape.GetMetadataNames();
                    if (metadataNames != null)
                    {
                        foreach (string metadataName in metadataNames)
                        {
                            building.Metadata += metadataName + " = " + shape.GetMetadata(metadataName) + "(" + shape.DataRecord.GetDataTypeName(shape.DataRecord.GetOrdinal(metadataName)) + ")";
                            building.Metadata += Environment.NewLine;
                        }
                        building.Metadata += Environment.NewLine;
                    }
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
                                    coordinate.X = point.X;
                                    coordinate.Y = point.Y;
                                    points.Add(coordinate);
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
            return objectList;
        }
    }
}
