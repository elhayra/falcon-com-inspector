using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.PackageWizard
{
    static class PackageWizard
    {
        private enum Section
        {
            ENDIANESS,
            HEADER,
            FIELDS,
            NONE, 
            INVALID
        }

        private static Section StringToSection(string section)
        {
            switch (section)
            {
                case "***endianess***":
                    return Section.ENDIANESS;

                case "***header***":
                    return Section.HEADER;

                case "***fields***":
                    return Section.FIELDS;
            }
            return Section.INVALID;
        }

        /// <summary>
        /// Handle a not INVALID section
        /// </summary>
        /// <param name="section"></param>
        private static void HandleSection(Section section, ref StreamReader reader)
        {
            switch (section)
            {
                case Section.ENDIANESS:

                    break;
                case Section.HEADER:

                    break;
                case Section.FIELDS:

                    break;
            }
        }

        public static Package GeneratePackageFromFile(string file)
        {
            Section section = Section.NONE;
            var reader = new StreamReader(file);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // ignore comments and empty lines
                if (!line.StartsWith("#") && line != "") 
                {
                    if (section == Section.NONE)
                    {
                        section = StringToSection(line);

                        if (section == Section.INVALID)
                        {
                            reader.Close();
                            var argExp = new ArgumentException("A section name must come before data attributes", line); 
                            throw argExp;
                        }

                        HandleSection(section, ref reader);
                    }
                        
                }

            }
            reader.Close();

            return null;
        }

        public static string ParseBytesPackage(ref Package pkg, byte [] bytes)
        {

        }
    }
}
