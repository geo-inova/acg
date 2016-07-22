using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTopologySuite.IO;
using NetTopologySuite.IO.Streams;
using NetTopologySuite.Geometries;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.Geometries.Utilities;
using NetTopologySuite.Utilities;
using NetTopologySuite.Features;

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
            List<IAcgObject> objectList = new List<IAcgObject>();


            ShapeReader reader = new ShapeReader(filePath);
            DbaseReader db = new DbaseReader(filePath);


            GeometryFactory geoFactory = new GeometryFactory();
            foreach (IGeometry geometry in reader.ReadAllShapes(geoFactory))
            {
                AcgBuilding building = new AcgBuilding();
                building.Geometry = geometry;

                List<IAttributesTable> tables = db.ToList();
                foreach (IAttributesTable table in tables)
                {
                    string[] names = table.GetNames();
                    object[] obj = table.GetValues();
                    foreach (int i in Enumerable.Range(0, table.Count))
                    {
                        building.Metadata += names.ElementAt(i) + "=" + obj.ElementAt(i).ToString();
                    }
                }
                objectList.Add(building);
            }
            return objectList;
        }
    }
}
