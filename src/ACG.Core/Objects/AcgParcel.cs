using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents a cadastral parcel, basic building block of national land registry.
    /// </summary>
    /// <remarks>
    /// Geometry is always polygonal.
    /// </remarks>
    public class AcgParcel : AcgObject
    {
        /// <inheritdoc/>
        public AcgParcel()
        {
            this.BlockNumber = "";
            this.Number = "";
            this.CountryName = "";
            this.StateName = "";
            this.SubmissionNames = "";
            this.CadastralUnitName = "";
            this.Type = 0;
            this.LocationDescription = "";
            this.MunicipalityName = "";
            this.FootprintSurfaceFixed = 0;
            this.RegionName = "";
            this.PreviousNumber = "";
            this.SoilType = 0;
            this.SubmissionFlag = 0;
            this.ZoneNumber = "";
            //this.TypeL0 = 0;
            //this.TypeL1 = 0;
            //this.TypeL2 = 0;
            //this.SubNumber = "";
        }

        /// <inheritdoc/>
        public override AcgObjectType ObjectType
        {
            get
            {
                return AcgObjectType.Parcel;
            }
        }

        #region General

        /// <summary>
        /// Gets or sets cadastral parcel number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets cadastral parcel number in previous records.
        /// </summary>
        public string PreviousNumber { get; set; }

        /// <summary>
        /// Gets or sets name of corresponding cadastral unit.
        /// </summary>
        public string CadastralUnitName { get; set; }

        /// <summary>
        /// Gets or sets parcel's corresponding block number.
        /// </summary>
        public string BlockNumber { get; set; }

        /// <summary>
        /// Gets or sets parcel's corresponding zone number.
        /// </summary>
        public string ZoneNumber { get; set; }

        /// <summary>
        /// Gets or sets primary purpose of the land under the parcel.
        /// </summary>
        public Int32 Type { get; set; }

        /// <summary>
        /// Gets or sets soil type under the parcel.
        /// </summary>
        public Int32 SoilType { get; set; }

        /// <summary>
        /// Gets or sets indicator related to submission process.
        /// </summary>
        public Int16 SubmissionFlag { get; set; }

        /// <summary>
        /// Gets or sets name(s) of people related to submission process.
        /// </summary>
        public string SubmissionNames { get; set; }

        ///// <summary>
        ///// Podbroj katastarske parcele.
        ///// </summary>
        //public string SubNumber { get; set; }

        ///// <summary>
        ///// Primarna namjena površine pod parcelom.
        ///// </summary>
        //public Int32 TypeL0 { get; set; }

        ///// <summary>
        ///// Sekundarna namjena površine pod parcelom u okviru primarne namjene.
        ///// </summary>
        //public Int32 TypeL1 { get; set; }

        ///// <summary>
        ///// Tercijalna namjena površine pod parcelom u okviru sekundarne namjene.
        ///// </summary>
        //public Int32 TypeL2 { get; set; }

        #endregion

        #region Location

        /// <summary>
        /// Gets or sets country name where parcel is situated.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets state name where parcel is situated.
        /// </summary>
        public string StateName { get; set; }

        /// <summary>
        /// Gets or sets region name where parcel is situated.
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// Gets or sets municipality name where parcel is situated.
        /// </summary>
        public string MunicipalityName { get; set; }

        /// <summary>
        /// Gets or sets additional location description of the parcel.
        /// </summary>
        public string LocationDescription { get; set; }

        #endregion

        #region Surface

        /// <summary>
        /// Returns total parcel surface (sqm).
        /// </summary>
        public double FootprintSurface
        {
            get
            {
                return this.FootprintSurfaceFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured parcel surface (sqm).
        /// </summary>
        public double FootprintSurfaceFixed { get; set; }

        #endregion

    }
}
