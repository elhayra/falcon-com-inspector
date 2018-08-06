namespace Falcon.Forms
{
    partial class CommandLineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandLineForm));
            this.cliDisplayTxtBx = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cliDisplayTxtBx
            // 
            this.cliDisplayTxtBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cliDisplayTxtBx.BackColor = System.Drawing.Color.Black;
            this.cliDisplayTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cliDisplayTxtBx.Font = new System.Drawing.Font("Miriam Fixed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cliDisplayTxtBx.ForeColor = System.Drawing.Color.White;
            this.cliDisplayTxtBx.Location = new System.Drawing.Point(0, 0);
            this.cliDisplayTxtBx.Name = "cliDisplayTxtBx";
            this.cliDisplayTxtBx.Size = new System.Drawing.Size(567, 458);
            this.cliDisplayTxtBx.TabIndex = 51;
            this.cliDisplayTxtBx.Text = "";
            this.cliDisplayTxtBx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cliDisplayTxtBx_MouseClick);
            this.cliDisplayTxtBx.TextChanged += new System.EventHandler(this.cliDisplayTxtBx_TextChanged);
            this.cliDisplayTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cliDisplayTxtBx_KeyPress);
            // 
            // CommandLineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 456);
            this.Controls.Add(this.cliDisplayTxtBx);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CommandLineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Falcon Command Line";
            this.Load += new System.EventHandler(this.CommandLineForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox cliDisplayTxtBx;
    }
}