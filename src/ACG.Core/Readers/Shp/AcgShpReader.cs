using System;
using System.IO;
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

            if (this.Mappings != null)
            {
                var reader = new DBFReader(dbFilePath);

                string key = "";

                foreach (int i in Enumerable.Range(0, reader.RecordCount))
                {
                    object[] objects = reader.NextRecord();
                    DBFField[] dbffields = reader.Fields;

                    if (objectList[i].ObjectType == AcgObjectType.Building) key = "AcgBuilding";
                    else key = "AcgParcel";

                    List<AcgMapping> mappingList = this.Mappings[key];
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
                            case "EquipmentCATV":
                                _building.EquipmentCATV = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "HeightFixed":
                                _building.HeightFixed = Convert.ToDouble(value);
                                objectList[i] = _building;
                                break;
                            case "Households":
                                _building.Households = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "CountryName":
                                _building.CountryName = value;
                                objectList[i] = _building;
                                break;
                            case "StateName":
                                _building.StateName = value;
                                objectList[i] = _building;
                                break;
                            case "University":
                                _building.University = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FloorMezanine":
                                _building.FloorMezanine = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentGas":
                                _building.EquipmentGas = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "YearBuilt":
                                _building.YearBuilt = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "YearReconstructed":
                                _building.YearReconstructed = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentHeating":
                                _building.EquipmentHeating = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentLightning":
                                _building.EquipmentLightning = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentCooling":
                                _building.EquipmentCooling = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Operation":
                                _building.Operation = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentSewer":
                                _building.EquipmentSewer = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Category":
                                _building.Category = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentAirCondition":
                                _building.EquipmentAirCondition = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Construction":
                                _building.Construction = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "RoofMaterial":
                                _building.RoofMaterial = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FloorGarret":
                                _building.FloorGarret = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "CeilingConstruction":
                                _building.CeilingConstruction = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "PlaceName":
                                _building.PlaceName = value;
                                objectList[i] = _building;
                                break;
                            case "EquipmentOil":
                                _building.EquipmentOil = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Type":
                                _building.Type = value;
                                objectList[i] = _building;
                                break;
                            case "EquipmentDrainage":
                                _building.EquipmentDrainage = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "LocationDescription":
                                _building.LocationDescription = value;
                                objectList[i] = _building;
                                break;
                            case "Condition":
                                _building.Condition = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "MunicipalityName":
                                _building.MunicipalityName = value;
                                objectList[i] = _building;
                                break;
                            case "PrimarySchool":
                                _building.PrimarySchool = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Retired":
                                _building.Retired = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FootprintSurfaceFixed":
                                _building.FootprintSurfaceFixed = Convert.ToDouble(value);
                                objectList[i] = _building;
                                break;
                            case "FloorCellar":
                                _building.FloorCellar = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "TotalCommercialSurface":
                                _building.TotalCommercialSurface = Convert.ToDouble(value);
                                objectList[i] = _building;
                                break;
                            case "FloorLoft":
                                _building.FloorLoft = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FloorInset":
                                _building.FloorInset = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "PreSchool":
                                _building.PreSchool = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FloorGround":
                                _building.FloorGround = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Number":
                                _building.Number = value;
                                objectList[i] = _building;
                                break;
                            case "RegionName":
                                _building.RegionName = value;
                                objectList[i] = _building;
                                break;
                            case "School":
                                _building.School = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "SecondarySchool":
                                _building.SecondarySchool = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "TotalCondoSurface":
                                _building.TotalCondoSurface = Convert.ToDouble(value);
                                objectList[i] = _building;
                                break;
                            case "Inhabitants":
                                _building.Inhabitants = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentElectricity":
                                _building.EquipmentElectricity = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FloorBasement":
                                _building.FloorBasement = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentTelephone":
                                _building.EquipmentTelephone = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "RoofType":
                                _building.RoofType = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentWaterHeating":
                                _building.EquipmentWaterHeating = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "FacadeType":
                                _building.FacadeType = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "WindowType":
                                _building.WindowType = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "EquipmentWater":
                                _building.EquipmentWater = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                            case "Working":
                                _building.Working = Convert.ToInt16(value);
                                objectList[i] = _building;
                                break;
                        }
                    }
                }
            }
            return objectList;
        }
    }
}
