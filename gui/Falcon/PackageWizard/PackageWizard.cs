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
        /// Handle a valid section
        /// </summary>
        /// <param name="section"></param>
        //private static bool HandleSection(Section section, ref StreamReader reader, ref Package pkg)
        //{
        //    switch (section)
        //    {
        //        case Section.ENDIANESS:
        //            return HandleEndianess(ref reader, ref pkg);

        //        case Section.HEADER:


        //        case Section.FIELDS:


        //    }
        //}

        private static bool HandleEndianess(ref StreamReader reader, ref Package pkg)
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                if (line == "big-endian")
                {
                    // TODO: update package endian
                    return true;
                }
                if (line == "small-endian")
                {
                    // TODO: update package endian
                    return true;
                }

            }
            return false;
        }

        //private static bool HandleHeader(ref StreamReader reader, ref Package pkg)
        //{
        //    string line = reader.ReadLine();
        //    while ((line = reader.ReadLine()) != null)
        //    {
                
        //    }
        //}

        //private static bool HandleFields(ref StreamReader reader, ref Package pkg)
        //{
        //    string line = reader.ReadLine();
        //    while ((line = reader.ReadLine()) != null)
        //    {

        //    }
        //}

        //public static Package GeneratePackageFromFile(string file)
        //{
        //    var package = new Package();
        //    Section section = Section.NONE;
        //    var reader = new StreamReader(file);
        //    string line;
        //    while ((line = reader.ReadLine()) != null)
        //    {
        //        // ignore comments and empty lines
        //        if (!line.StartsWith("#") && line != "") 
        //        {
        //            if (section == Section.NONE)
        //            {
        //                section = StringToSection(line);

        //                if (section == Section.INVALID)
        //                {
        //                    reader.Close();
        //                    var argExp = new ArgumentException("A section name must come before data attributes", line); 
        //                    throw argExp;
        //                }

        //                HandleSection(section, ref reader);

        //                section = Section.NONE;
        //            }
                        
        //        }

        //    }
        //    reader.Close();

        //    return null;
        //}

        //public static string ParseBytesPackage(ref Package pkg, byte [] bytes)
        //{

        //}
    }
}
