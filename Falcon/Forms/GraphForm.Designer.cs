namespace Falcon.Forms
{
    partial class GraphForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.addRmBtn = new System.Windows.Forms.Button();
            this.tailTxt = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.sampleRateTxt = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tailTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.Black;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.Title = "Time (seconds)";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.Title = "Bytes Per Second";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Black;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(136, -1);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart.Size = new System.Drawing.Size(701, 471);
            this.chart.TabIndex = 2;
            this.chart.Text = "chart";
            this.chart.MouseEnter += new System.EventHandler(this.chart_MouseEnter);
            this.chart.MouseLeave += new System.EventHandler(this.chart_MouseLeave);
            // 
            // graphTimer
            // 
            this.graphTimer.Enabled = true;
            this.graphTimer.Interval = 1000;
            this.graphTimer.Tick += new System.EventHandler(this.graphTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.addRmBtn);
            this.groupBox1.Controls.Add(this.tailTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sampleRateTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(832, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 493);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // applyBtn
            // 
            this.applyBtn.ForeColor = System.Drawing.Color.Black;
            this.applyBtn.Location = new System.Drawing.Point(11, 113);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(90, 23);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // addRmBtn
            // 
            this.addRmBtn.ForeColor = System.Drawing.Color.Black;
            this.addRmBtn.Location = new System.Drawing.Point(11, 174);
            this.addRmBtn.Name = "addRmBtn";
            this.addRmBtn.Size = new System.Drawing.Size(90, 43);
            this.addRmBtn.TabIndex = 6;
            this.addRmBtn.Text = "Add / Remove Series";
            this.addRmBtn.UseVisualStyleBackColor = true;
            this.addRmBtn.Click += new System.EventHandler(this.addRmBtn_Click);
            // 
            // tailTxt
            // 
            this.tailTxt.BackColor = System.Drawing.Color.LightGreen;
            this.tailTxt.Location = new System.Drawing.Point(11, 87);
            this.tailTxt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tailTxt.Name = "tailTxt";
            this.tailTxt.Size = new System.Drawing.Size(90, 20);
            this.tailTxt.TabIndex = 5;
            this.tailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tailTxt.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tailTxt.ValueChanged += new System.EventHandler(this.tailTxt_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tail Length (Points):";
            // 
            // sampleRateTxt
            // 
            this.sampleRateTxt.BackColor = System.Drawing.Color.LightGreen;
            this.sampleRateTxt.Location = new System.Drawing.Point(11, 40);
            this.sampleRateTxt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sampleRateTxt.Name = "sampleRateTxt";
            this.sampleRateTxt.Size = new System.Drawing.Size(90, 20);
            this.sampleRateTxt.TabIndex = 3;
            this.sampleRateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sampleRateTxt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sampleRateTxt.ValueChanged += new System.EventHandler(this.sampleRateTxt_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sample Rate (Hz):";
            // 
            // resetBtn
            // 
            this.resetBtn.ForeColor = System.Drawing.Color.Black;
            this.resetBtn.Location = new System.Drawing.Point(11, 225);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(90, 23);
            this.resetBtn.TabIndex = 0;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.BackColor = System.Drawing.Color.Black;
            this.treeView.ForeColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(1, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(143, 488);
            this.treeView.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 473);
            this.label3.MinimumSize = new System.Drawing.Size(690, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(690, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "label3";
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 490);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            this.Activated += new System.EventHandler(this.GraphForm_Activated);
            this.Deactivate += new System.EventHandler(this.GraphForm_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tailTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer graphTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.NumericUpDown tailTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sampleRateTxt;
        private System.Windows.Forms.Button addRmBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label label3;
    }
}