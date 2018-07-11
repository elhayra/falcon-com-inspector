/*******************************************************************************
* Copyright (c) 2018 Elhay Rauper
* All rights reserved.
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted (subject to the limitations in the disclaimer
* below) provided that the following conditions are met:
*
*     * Redistributions of source code must retain the above copyright notice,
*     this list of conditions and the following disclaimer.
*
*     * Redistributions in binary form must reproduce the above copyright
*     notice, this list of conditions and the following disclaimer in the
*     documentation and/or other materials provided with the distribution.
*
*     * Neither the name of the copyright holder nor the names of its
*     contributors may be used to endorse or promote products derived from this
*     software without specific prior written permission.
*
* NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY
* THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
* CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
* LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
* PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
* CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
* EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR
* BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER
* IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************/

using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Falcon.Utils
{
    public class FileTools
    {

        public static string ChooseFolderPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Save at";
            if (fbd.ShowDialog() == DialogResult.OK)
                return fbd.SelectedPath;
            return null;
        }

        public static string ChooseFilePath(string fileFilter)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = fileFilter;//"All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                //string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true      
                return choofdlog.FileName;
            }
            return null;
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