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
            this.tailSizeCmBx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSourceCmBx = new System.Windows.Forms.ComboBox();
            this.sdf = new System.Windows.Forms.Label();
            this.setpointTxt = new System.Windows.Forms.NumericUpDown();
            this.seriesLstBx = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.seriesTypeCmBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.setpointTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // tailSizeCmBx
            // 
            this.tailSizeCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tailSizeCmBx.FormattingEnabled = true;
            this.tailSizeCmBx.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100",
            "300",
            "500"});
            this.tailSizeCmBx.Location = new System.Drawing.Point(82, 85);
            this.tailSizeCmBx.Name = "tailSizeCmBx";
            this.tailSizeCmBx.Size = new System.Drawing.Size(94, 21);
            this.tailSizeCmBx.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tail Size:";
            // 
            // dataSourceCmBx
            // 
            this.dataSourceCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataSourceCmBx.FormattingEnabled = true;
            this.dataSourceCmBx.Items.AddRange(new object[] {
            "Bytes Rate",
            "Index 0",
            "Index 1",
            "Index 2",
            "Index 3",
            "Index 4",
            "Index 5",
            "Index 6",
            "Index 7",
            "Index 8",
            "Index 9"});
            this.dataSourceCmBx.Location = new System.Drawing.Point(82, 59);
            this.dataSourceCmBx.Name = "dataSourceCmBx";
            this.dataSourceCmBx.Size = new System.Drawing.Size(94, 21);
            this.dataSourceCmBx.TabIndex = 12;
            // 
            // sdf
            // 
            this.sdf.AutoSize = true;
            this.sdf.Location = new System.Drawing.Point(8, 62);
            this.sdf.Name = "sdf";
            this.sdf.Size = new System.Drawing.Size(70, 13);
            this.sdf.TabIndex = 11;
            this.sdf.Text = "Data Source:";
            // 
            // setpointTxt
            // 
            this.setpointTxt.Enabled = false;
            this.setpointTxt.Location = new System.Drawing.Point(82, 112);
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
            this.seriesLstBx.Size = new System.Drawing.Size(140, 186);
            this.seriesLstBx.TabIndex = 16;
            this.seriesLstBx.SelectedIndexChanged += new System.EventHandler(this.seriesLstBx_SelectedIndexChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(12, 144);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(66, 23);
            this.addBtn.TabIndex = 19;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(12, 170);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(165, 23);
            this.removeAllBtn.TabIndex = 18;
            this.removeAllBtn.Text = "Remove All";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            this.removeAllBtn.Click += new System.EventHandler(this.removeAllBtn_Click);
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(111, 144);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(66, 23);
            this.removeBtn.TabIndex = 17;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            this.removeBtn.Click += new System.EventHandler(this.removeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name ID:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(82, 33);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(94, 20);
            this.nameTxt.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Setpoint:";
            // 
            // seriesTypeCmBx
            // 
            this.seriesTypeCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seriesTypeCmBx.FormattingEnabled = true;
            this.seriesTypeCmBx.Items.AddRange(new object[] {
            "Regular",
            "Setpoint"});
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
            // SeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 203);
            this.Controls.Add(this.seriesTypeCmBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.setpointTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.removeAllBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.seriesLstBx);
            this.Controls.Add(this.tailSizeCmBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataSourceCmBx);
            this.Controls.Add(this.sdf);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeriesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeriesForm";
            ((System.ComponentModel.ISupportInitialize)(this.setpointTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tailSizeCmBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dataSourceCmBx;
        private System.Windows.Forms.Label sdf;
        private System.Windows.Forms.NumericUpDown setpointTxt;
        private System.Windows.Forms.ListBox seriesLstBx;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox seriesTypeCmBx;
        private System.Windows.Forms.Label label4;
    }
}