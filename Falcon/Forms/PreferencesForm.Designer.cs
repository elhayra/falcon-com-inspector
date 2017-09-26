namespace Falcon.Forms
{
    partial class PreferencesForm
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
            this.components = new System.ComponentModel.Container();
            this.applyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdCharCmBx = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(397, 370);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 0;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cmd Char";
            this.toolTip.SetToolTip(this.label1, "Start Command Character - when written inside send text box, the text written aft" +
        "er it will be treated as a Falcon command");
            // 
            // cmdCharCmBx
            // 
            this.cmdCharCmBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdCharCmBx.FormattingEnabled = true;
            this.cmdCharCmBx.Items.AddRange(new object[] {
            "!",
            "@",
            "#",
            "$",
            "%",
            "^",
            "&",
            "*",
            ">",
            "~",
            "`"});
            this.cmdCharCmBx.Location = new System.Drawing.Point(73, 10);
            this.cmdCharCmBx.MaxLength = 1;
            this.cmdCharCmBx.Name = "cmdCharCmBx";
            this.cmdCharCmBx.Size = new System.Drawing.Size(49, 21);
            this.cmdCharCmBx.TabIndex = 2;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 414);
            this.Controls.Add(this.cmdCharCmBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreferencesForm";
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox cmdCharCmBx;
    }
}