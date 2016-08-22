using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Represents a dictionary of field mapping rules.
    /// </summary>
    /// <remarks>
    /// Dictionary key represents the name of <see cref="IAcgObject"/> object.
    /// </remarks>
    public class AcgMappingDictionary : Dictionary<string, List<AcgMapping>>
    {
        /// <summary>
        /// Raads file mapping rules from specified file.
        /// </summary>
        /// <param name="filePath">File path to field mappings definition file.</param>
        public void Read(string filePath)
        {
            StreamReader file = new StreamReader(filePath);

            string line = "", source = "", target = "";
            int position = 0;
            
            line = file.ReadLine();
            while (line != null)
            {
                switch (line)
                {
                    case "[Building]":
                        List<AcgMapping> acgmappingList = new List<AcgMapping>();
                        while ((line = file.ReadLine()) != null && line.Contains("="))
                        {
                            AcgMapping acgmapping = new AcgMapping();
                            position = line.IndexOf("=");
                            source = line.Substring(0, position - 1);
                            target = line.Substring(position + 2, line.Length - position - 2);
                            acgmapping.Source = source;
                            acgmapping.Target = target;
                            acgmappingList.Add(acgmapping);
                        }
                        this.Add("AcgBuilding", acgmappingList);
                        break;

                    case "[Parcel]":
                        List<AcgMapping> _acgmappingList = new List<AcgMapping>();
                        while ((line = file.ReadLine()) != null && line.Contains("="))
                        {
                            AcgMapping acgmapping = new AcgMapping();
                            position = line.IndexOf("=");
                            source = line.Substring(0, position - 1);
                            target = line.Substring(position + 2, line.Length - position - 2);
                            acgmapping.Source = source;
                            acgmapping.Target = target;
                            _acgmappingList.Add(acgmapping);
                        }
                        this.Add("AcgParcel", _acgmappingList);
                        break;
                }
            }
        }
    }
}
