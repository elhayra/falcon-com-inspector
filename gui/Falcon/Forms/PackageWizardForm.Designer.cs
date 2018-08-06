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
            this.seriesTypeCmBx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.seriesLstBx = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // seriesTypeCmBx
            // 
            this.seriesTypeCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seriesTypeCmBx.FormattingEnabled = true;
            this.seriesTypeCmBx.Items.AddRange(new object[] {
            "Data",
            "Setpoint",
            "Bytes Rate"});
            this.seriesTypeCmBx.Location = new System.Drawing.Point(86, 6);
            this.seriesTypeCmBx.Name = "seriesTypeCmBx";
            this.seriesTypeCmBx.Size = new System.Drawing.Size(94, 21);
            this.seriesTypeCmBx.TabIndex = 36;
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
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(86, 33);
            this.nameTxt.MaxLength = 14;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(94, 20);
            this.nameTxt.TabIndex = 33;
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
            this.addBtn.Location = new System.Drawing.Point(15, 62);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(66, 23);
            this.addBtn.TabIndex = 31;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(15, 89);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(165, 23);
            this.removeAllBtn.TabIndex = 30;
            this.removeAllBtn.Text = "Remove All";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(114, 62);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(66, 23);
            this.removeBtn.TabIndex = 29;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            // 
            // seriesLstBx
            // 
            this.seriesLstBx.FormattingEnabled = true;
            this.seriesLstBx.Location = new System.Drawing.Point(187, 6);
            this.seriesLstBx.Name = "seriesLstBx";
            this.seriesLstBx.Size = new System.Drawing.Size(140, 186);
            this.seriesLstBx.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PackageWizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 199);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.seriesTypeCmBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.removeAllBtn);
            this.Controls.Add(this.removeBtn);
            this.Controls.Add(this.seriesLstBx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PackageWizardForm";
            this.Text = "Package Wizard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox seriesTypeCmBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.ListBox seriesLstBx;
        private System.Windows.Forms.Button button1;
    }
}