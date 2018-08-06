namespace Falcon.Forms
{
    partial class SeriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesForm));
            this.dataIndexLbl = new System.Windows.Forms.Label();
            this.setpointTxt = new System.Windows.Forms.NumericUpDown();
            this.seriesLstBx = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.nameLbl = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.setpointLbl = new System.Windows.Forms.Label();
            this.seriesTypeCmBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataIndexTxt = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.setpointTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataIndexTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // dataIndexLbl
            // 
            this.dataIndexLbl.AutoSize = true;
            this.dataIndexLbl.Location = new System.Drawing.Point(8, 62);
            this.dataIndexLbl.Name = "dataIndexLbl";
            this.dataIndexLbl.Size = new System.Drawing.Size(62, 13);
            this.dataIndexLbl.TabIndex = 11;
            this.dataIndexLbl.Text = "Data Index:";
            // 
            // setpointTxt
            // 
            this.setpointTxt.Location = new System.Drawing.Point(82, 86);
            this.setpointTxt.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.setpointTxt.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.setpointTxt.Name = "setpointTxt";
            this.setpointTxt.Size = new System.Drawing.Size(94, 20);
            this.setpointTxt.TabIndex = 2;
            // 
            // seriesLstBx
            // 
            this.seriesLstBx.FormattingEnabled = true;
            this.seriesLstBx.Location = new System.Drawing.Point(183, 6);
            this.seriesLstBx.Name = "seriesLstBx";
            this.seriesLstBx.Size = new System.Drawing.Size(140, 160);
            this.seriesLstBx.TabIndex = 16;
            this.seriesLstBx.SelectedIndexChanged += new System.EventHandler(this.seriesLstBx_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(11, 117);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(66, 23);
            this.addBtn.TabIndex = 19;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(11, 144);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(165, 23);
            this.removeAllBtn.TabIndex = 18;
            this.removeAllBtn.Text = "Remove All";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            this.removeAllBtn.Click += new System.EventHandler(this.removeAllBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(110, 117);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(66, 23);
            this.removeBtn.TabIndex = 17;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Location = new System.Drawing.Point(8, 36);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(52, 13);
            this.nameLbl.TabIndex = 20;
            this.nameLbl.Text = "Name ID:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(82, 33);
            this.nameTxt.MaxLength = 14;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(94, 20);
            this.nameTxt.TabIndex = 21;
            // 
            // setpointLbl
            // 
            this.setpointLbl.AutoSize = true;
            this.setpointLbl.Location = new System.Drawing.Point(9, 88);
            this.setpointLbl.Name = "setpointLbl";
            this.setpointLbl.Size = new System.Drawing.Size(49, 13);
            this.setpointLbl.TabIndex = 22;
            this.setpointLbl.Text = "Setpoint:";
            // 
            // seriesTypeCmBx
            // 
            this.seriesTypeCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seriesTypeCmBx.FormattingEnabled = true;
            this.seriesTypeCmBx.Items.AddRange(new object[] {
            "Data",
            "Setpoint",
            "Bytes Rate"});
            this.seriesTypeCmBx.Location = new System.Drawing.Point(82, 6);
            this.seriesTypeCmBx.Name = "seriesTypeCmBx";
            this.seriesTypeCmBx.Size = new System.Drawing.Size(94, 21);
            this.seriesTypeCmBx.TabIndex = 24;
            this.seriesTypeCmBx.SelectedIndexChanged += new System.EventHandler(this.seriesTypeCmBx_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Series Type:";
            // 
            // dataIndexTxt
            // 
            this.dataIndexTxt.Location = new System.Drawing.Point(82, 59);
            this.dataIndexTxt.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.dataIndexTxt.Name = "dataIndexTxt";
            this.dataIndexTxt.Size = new System.Drawing.Size(94, 20);
            this.dataIndexTxt.TabIndex = 25;
            // 
            // SeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 175);
            this.Controls.Add(this.dataIndexTxt);
            this.Controls.Add(this.seriesTypeCmBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.setpointLbl);
            this.Controls.Add(this.setpointTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.removeAllBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.seriesLstBx);
            this.Controls.Add(this.dataIndexLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Series Manager";
            ((System.ComponentModel.ISupportInitialize)(this.setpointTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataIndexTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dataIndexLbl;
        private System.Windows.Forms.NumericUpDown setpointTxt;
        private System.Windows.Forms.ListBox seriesLstBx;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label setpointLbl;
        private System.Windows.Forms.ComboBox seriesTypeCmBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown dataIndexTxt;
    }
}