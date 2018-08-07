namespace Falcon.Forms
{
    partial class PackageWizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageWizardForm));
            this.cellTypeCmBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cellNameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.cellsLstBx = new System.Windows.Forms.ListBox();
            this.cellSizeLbl = new System.Windows.Forms.Label();
            this.sizeTxt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // cellTypeCmBx
            // 
            this.cellTypeCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cellTypeCmBx.FormattingEnabled = true;
            this.cellTypeCmBx.Items.AddRange(new object[] {
            "uint8",
            "int8",
            "uint16",
            "int16",
            "uint32",
            "int32",
            "uint64",
            "int64",
            "float32",
            "float64",
            "string"});
            this.cellTypeCmBx.Location = new System.Drawing.Point(86, 6);
            this.cellTypeCmBx.Name = "cellTypeCmBx";
            this.cellTypeCmBx.Size = new System.Drawing.Size(94, 21);
            this.cellTypeCmBx.TabIndex = 36;
            this.cellTypeCmBx.SelectedIndexChanged += new System.EventHandler(this.cellTypeCmBx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Cell Type:";
            // 
            // cellNameTxt
            // 
            this.cellNameTxt.Location = new System.Drawing.Point(86, 33);
            this.cellNameTxt.MaxLength = 14;
            this.cellNameTxt.Name = "cellNameTxt";
            this.cellNameTxt.Size = new System.Drawing.Size(94, 20);
            this.cellNameTxt.TabIndex = 33;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(12, 36);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(58, 13);
            this.nameLbl.TabIndex = 32;
            this.nameLbl.Text = "Cell Name:";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(14, 143);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(66, 23);
            this.addBtn.TabIndex = 31;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(14, 170);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(166, 23);
            this.removeAllBtn.TabIndex = 30;
            this.removeAllBtn.Text = "Remove All";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            this.removeAllBtn.Click += new System.EventHandler(this.removeAllBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(114, 143);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(66, 23);
            this.removeBtn.TabIndex = 29;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // cellsLstBx
            // 
            this.cellsLstBx.FormattingEnabled = true;
            this.cellsLstBx.Location = new System.Drawing.Point(187, 6);
            this.cellsLstBx.Name = "cellsLstBx";
            this.cellsLstBx.Size = new System.Drawing.Size(140, 186);
            this.cellsLstBx.TabIndex = 28;
            // 
            // cellSizeLbl
            // 
            this.cellSizeLbl.AutoSize = true;
            this.cellSizeLbl.Location = new System.Drawing.Point(13, 61);
            this.cellSizeLbl.Name = "cellSizeLbl";
            this.cellSizeLbl.Size = new System.Drawing.Size(50, 13);
            this.cellSizeLbl.TabIndex = 39;
            this.cellSizeLbl.Text = "Cell Size:";
            this.cellSizeLbl.Visible = false;
            // 
            // sizeTxt
            // 
            this.sizeTxt.Location = new System.Drawing.Point(86, 59);
            this.sizeTxt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sizeTxt.Name = "sizeTxt";
            this.sizeTxt.Size = new System.Drawing.Size(94, 20);
            this.sizeTxt.TabIndex = 38;
            this.sizeTxt.Visible = false;
            // 
            // PackageWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 199);
            this.Controls.Add(this.cellSizeLbl);
            this.Controls.Add(this.sizeTxt);
            this.Controls.Add(this.cellTypeCmBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cellNameTxt);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.removeAllBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.cellsLstBx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PackageWizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Package Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.sizeTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cellTypeCmBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cellNameTxt;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox cellsLstBx;
        private System.Windows.Forms.Label cellSizeLbl;
        private System.Windows.Forms.NumericUpDown sizeTxt;
    }
}