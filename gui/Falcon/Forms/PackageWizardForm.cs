using Falcon.PackageWizard;
using Falcon.Utils;
using Kaveret.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falcon.Forms
{
    public partial class PackageWizardForm : Form
    {
        string chosenType;
        int chosenSize = 0;
        string chosenName;

        public PackageWizardForm()
        {
            InitializeComponent();
            cellTypeCmBx.SelectedIndex = 0;

            List<Cell> cellsList = Package.Inst.GetCells();
            foreach (Cell cell in cellsList)
            {
                string cellRecord = cell.GetTypeString() + " " + cell.GetName();
                cellsLstBx.Items.Add(cellRecord);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            chosenName = cellNameTxt.Text;
            if (Package.Inst.IsExist(chosenName))
            {
                MsgBox.ErrorMsg("Adding Cell Failed", "Cell name already exist. Name must be unique");
                return;
            }
            chosenSize = Convert.ToInt16(sizeTxt.Text);
            if (!Package.Inst.AddCell(chosenType, chosenName, chosenSize))
                throw new Exception("couldn't add cell to list - invalid string type");
            cellsLstBx.Items.Add(cellTypeCmBx.Text + " " + chosenName);
        }

        private void cellTypeCmBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenType = cellTypeCmBx.Text;
            if (chosenType == "string")
            {
                cellSizeLbl.Visible = true;
                sizeTxt.Visible = true;
            }
            else
            {
                cellSizeLbl.Visible = false;
                sizeTxt.Visible = false;
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (cellsLstBx.SelectedItem == null)
            {
                MsgBox.ErrorMsg("Removing Series Failed", "You must select a series to remove first");
                return;
            }
            string cellRecord = cellsLstBx.SelectedItem.ToString();
            string cellName = cellsLstBx.SelectedItem.ToString().Split(' ')[1];
            if (!Package.Inst.RemoveCell(cellName))
                throw new Exception("couldn't find selected cell in list object");
            
            cellsLstBx.Items.Remove(cellRecord);
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            Package.Inst.RemoveAllCells();
            cellsLstBx.Items.Clear();
        }

       
    }
}
