using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NetTopologySuite;
using NetTopologySuite.Geometries;
using GeoAPI.Geometries;
using netDxf;
using netDxf.Entities;
using netDxf.Collections;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Data reader for Autodesk DXF files.
    /// </summary>
    public class AcgDxfReader : AcgReader
    {
        /// <inheritdoc/>
        public override List<IAcgObject> Read(string filePath)
        {
            List<IAcgObject> objectList = new List<IAcgObject>();

            DxfDocument dxf = DxfDocument.Load(filePath);

            if (dxf.LwPolylines.Count > 0)
            {
                foreach (LwPolyline polyline in dxf.LwPolylines)
                {
                    AcgBuilding building = new AcgBuilding();

                    XDataDictionary xdatadic = polyline.XData;

                    foreach (XData xdata in xdatadic.Values)
                    {
                        List<XDataRecord> rekordlist = xdata.XDataRecord;
                        foreach (XDataRecord rekord in rekordlist)
                        {
                            building.Metadata += rekord.Value;
                        }
                    }

                    List<Coordinate> points = new List<Coordinate>();
                    Coordinate coordinate = new Coordinate();

                    foreach (LwPolylineVertex vertex in polyline.Vertexes)
                    {
                        Vector2 location = vertex.Location;
                        coordinate.X = location.X;
                        coordinate.Y = location.Y;
                        points.Add(coordinate);
                    }
                    if (points.Count > 3)
                    {
                        LinearRing linearing = new LinearRing(points.ToArray());
                        Polygon polygon = new Polygon(linearing);
                        building.Geometry = polygon;
                        objectList.Add(building);
                    }
                }
            }
            return objectList;
        }
    }
}
