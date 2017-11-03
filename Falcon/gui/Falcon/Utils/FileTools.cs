using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Falcon.Utils
{
    public class FileTools
    {

        // public static Properties.Settings GetSettings()
        //{
        //   return Properties.Settings.Default;
        //}
        public static string ChooseFolderPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Save at";
            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;
            return null;
        }

        public static string ChooseFilePath(string file_filter)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = file_filter;//"All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true      
                return choofdlog.FileName;
            }
            else return "";
        }

        public static int CreateFolder(string path)
        {
            int state = 0; //success
            try
            {
                if (Directory.Exists(@path))
                {
                    Console.WriteLine("That path exists already.");
                    state = 1; //directory was not created but it's existed
                }

                // Try to create the directory.
                Directory.CreateDirectory(@path);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                state = 2; //directory was not created beacuse of some error
            }
            return state;
        }

        /// <summary>
        /// Take a path and returns file name
        /// </summary>
        /// <param name="path">string path. e.g. "a\b\c.txt"</param>
        /// <returns>file name (no postfix/file type). e.g. "c"</returns>
        public static string GetFileName(string file_path)
        {
            string[] splited_file_path = file_path.Split('\\');
            string[] splited_file_name = splited_file_path.Last<string>().Split('.');
            return splited_file_name[0];
        }
    }
}