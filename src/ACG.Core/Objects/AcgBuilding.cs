using System;
using System.Collections.Generic;
using System.Text;

using GeoAPI.Geometries;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents a permanent residental, commercial or utility structure.
    /// </summary>
    /// <remarks>
    /// Geometry is always polygonal.
    /// </remarks>
    public class AcgBuilding : AcgObject
    {
        /// <inheritdoc/>
        public AcgBuilding()
        {
            this.HeightFixed = 0;
            this.StreetName = "";
            this.StreetNumber = "";
            this.TotalGrossSurfaceFixed = 0;
            this.EquipmentCATV = 0;
            this.Households = 0;
            this.CountryName = "";
            this.StateName = "";
            this.University = 0;
            this.FloorMezanine = 0;
            this.EquipmentGas = 0;
            this.YearBuilt = 0;
            this.YearReconstructed = 0;
            this.EquipmentHeating = 0;
            this.EquipmentLightning = 0;
            this.EquipmentCooling = 0;
            this.Operation = 0;
            this.EquipmentSewer = 0;
            this.Category = 0;
            this.EquipmentAirCondition = 0;
            this.Construction = 0;
            this.RoofMaterial = 0;
            this.FloorGarret = 0;
            this.CeilingConstruction = 0;
            this.PlaceName = "";
            this.EquipmentOil = 0;
            this.Type = "";
            this.EquipmentDrainage = 0;
            this.LocationDescription = "";
            this.Condition = 0;
            this.MunicipalityName = "";
            this.PrimarySchool = 0;
            this.Retired = 0;
            this.FootprintSurfaceFixed = 0;
            this.FloorCellar = 0;
            this.TotalCommercialSurface = 0;
            this.FloorLoft = 0;
            this.FloorInset = 0;
            this.PreSchool = 0;
            this.FloorGround = 0;
            this.Number = "";
            this.RegionName = "";
            this.School = 0;
            this.SecondarySchool = 0;
            this.TotalCondoSurface = 0;
            this.Inhabitants = 0;
            this.EquipmentElectricity = 0;
            this.FloorBasement = 0;
            this.EquipmentTelephone = 0;
            this.RoofType = 0;
            this.EquipmentWaterHeating = 0;
            this.FacadeType = 0;
            this.WindowType = 0;
            this.EquipmentWater = 0;
            this.Working = 0;
        }

        /// <inheritdoc/>
        public override AcgObjectType ObjectType
        {
            get
            {
                return AcgObjectType.Building;
            }
        }

        #region General

        /// <summary>
        /// Gets or sets the year when bulding was built.
        /// </summary>
        public Int16 YearBuilt { get; set; }

        /// <summary>
        /// Gets or sets the year when building was last reconstructed.
        /// </summary>
        public Int16 YearReconstructed { get; set; }

        /// <summary>
        /// Gets or sets intended operation related to building.
        /// </summary>
        public Int16 Operation { get; set; }

        /// <summary>
        /// Gets or sets primary building usage.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets building number in valorization list.
        /// </summary>
        public string Number { get; set; }

        #endregion

        #region Height

        /// <summary>
        /// Returns building height (m).
        /// </summary>
        public double Height
        {
            get
            {
                return this.HeightFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured building height (m).
        /// </summary>
        public double HeightFixed { get; set; }

        /// <summary>
        /// Gets or sets whether building has mezanine floor.
        /// </summary>
        public Int16 FloorMezanine { get; set; }

        /// <summary>
        /// Gets or sets whether building has garret floor.
        /// </summary>
        public Int16 FloorGarret { get; set; }

        /// <summary>
        /// Gets or sets whether building has cellar.
        /// </summary>
        public Int16 FloorCellar { get; set; }

        /// <summary>
        /// Gets or sets whether building has loft.
        /// </summary>
        public Int16 FloorLoft { get; set; }

        /// <summary>
        /// Gets or sets whether building has inset floor.
        /// </summary>
        public Int16 FloorInset { get; set; }

        /// <summary>
        /// Gets or sets whether building has ground floor.
        /// </summary>
        public Int16 FloorGround { get; set; }

        /// <summary>
        /// Gets or sets whether building has basement.
        /// </summary>
        public Int16 FloorBasement { get; set; }

        #endregion

        #region Surface

        /// <summary>
        /// Returns building total gross surface (sqm).
        /// </summary>
        public double TotalGrossSurface
        {
            get
            {
                return this.TotalGrossSurfaceFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured building total gross surface (sqm).
        /// </summary>
        public double TotalGrossSurfaceFixed { get; set; }

        /// <summary>
        /// Returns building total footprint surface (sqm).
        /// </summary>
        public double FootprintSurface
        {
            get
            {
                return this.FootprintSurfaceFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured building footprint surface (sqm).
        /// </summary>
        public double FootprintSurfaceFixed { get; set; }

        /// <summary>
        /// Gets or sets measured building total commercial surface (sqm).
        /// </summary>
        public double TotalCommercialSurface { get; set; }

        /// <summary>
        /// Gets or sets measured building total dwelling surface (sqm).
        /// </summary>
        public double TotalCondoSurface { get; set; }

        #endregion

        #region Location

        /// <summary>
        /// Gets or sets country name where building is situated.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets state name where building is situated.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets region name where building is situated.
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets municipality name where building is situated.
        /// </summary>
        public string MunicipalityName { get; set; }

        /// <summary>
        /// Gets or sets place name where building is situated.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Gets or sets building street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets building street number.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or sets additional location description of the building.
        /// </summary>
        public string LocationDescription { get; set; }

        #endregion

        #region Equipment

        /// <summary>
        /// Gets or sets whether building is equipped with CATV.
        /// </summary>
        public Int16 EquipmentCATV { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with gas.
        /// </summary>
        public Int16 EquipmentGas { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with heating.
        /// </summary>
        public Int16 EquipmentHeating { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with cooling.
        /// </summary>
        public Int16 EquipmentCooling { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with lightning rod.
        /// </summary>
        public Int16 EquipmentLightning { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with sewer.
        /// </summary>
        public Int16 EquipmentSewer { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with air-conditioning.
        /// </summary>
        public Int16 EquipmentAirCondition { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with oil/chemicals.
        /// </summary>
        public Int16 EquipmentOil { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with drainage.
        /// </summary>
        public Int16 EquipmentDrainage { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with electricity.
        /// </summary>
        public Int16 EquipmentElectricity { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with telephone.
        /// </summary>
        public Int16 EquipmentTelephone { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with water heating.
        /// </summary>
        public Int16 EquipmentWaterHeating { get; set; }

        /// <summary>
        /// Gets or sets whether building is equipped with water.
        /// </summary>
        public Int16 EquipmentWater { get; set; }

        #endregion

        #region Statistics

        /// <summary>
        /// Gets or sets total number of households.
        /// </summary>
        public Int16 Households { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants having university degree.
        /// </summary>
        public Int16 University { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants attending primary school.
        /// </summary>
        public Int16 PrimarySchool { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants being retired.
        /// </summary>
        public Int16 Retired { get; set; }

        /// <summary>
        ///  Gets or sets total number of inhabitants attending pre-school.
        /// </summary>
        public Int16 PreSchool { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants having any school degree.
        /// </summary>
        public Int16 School { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants attending secondary school.
        /// </summary>
        public Int16 SecondarySchool { get; set; }

        /// <summary>
        /// Gets or sets total number of inhabitants.
        /// </summary>
        public Int16 Inhabitants { get; set; }

        /// <summary>
        /// Gets or sets total number of working inhabitants.
        /// </summary>
        public Int16 Working { get; set; }

        #endregion

        #region Construction

        /// <summary>
        /// Gets or sets overall building category.
        /// </summary>
        public Int16 Category { get; set; }

        /// <summary>
        /// Gets or sets building construction system.
        /// </summary>
        public Int16 Construction { get; set; }

        /// <summary>
        /// Gets or sets building ceiling construction.
        /// </summary>
        public Int16 CeilingConstruction { get; set; }

        /// <summary>
        /// Gets or sets overall building condition.
        /// </summary>
        public Int16 Condition { get; set; }

        /// <summary>
        /// Gets or sets building roof material.
        /// </summary>
        public Int16 RoofMaterial { get; set; }

        /// <summary>
        /// Gets or sets building roof construction type.
        /// </summary>
        public Int16 RoofType { get; set; }

        /// <summary>
        /// Gets or sets building roof facade type.
        /// </summary>
        public Int16 FacadeType { get; set; }

        /// <summary>
        /// Gets or sets building windows type.
        /// </summary>
        public Int16 WindowType { get; set; }

        #endregion

    }
}
