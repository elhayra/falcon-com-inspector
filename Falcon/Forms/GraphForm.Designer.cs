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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graphManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRemoveBtn = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackColor = System.Drawing.Color.Black;
            chartArea8.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisX.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX.Title = "Time (seconds)";
            chartArea8.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea8.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea8.AxisY.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY.Title = "Bytes Per Second";
            chartArea8.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea8.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea8.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea8.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea8.BackColor = System.Drawing.Color.Black;
            chartArea8.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea8);
            legend8.BackColor = System.Drawing.Color.Black;
            legend8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            legend8.IsTextAutoFit = false;
            legend8.Name = "Legend";
            this.chart.Legends.Add(legend8);
            this.chart.Location = new System.Drawing.Point(0, 27);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series8.BorderWidth = 4;
            series8.ChartArea = "ChartArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series8.LabelBackColor = System.Drawing.Color.Black;
            series8.LabelForeColor = System.Drawing.Color.Wheat;
            series8.Legend = "Legend";
            series8.MarkerColor = System.Drawing.Color.White;
            series8.Name = "Bytes Rate";
            this.chart.Series.Add(series8);
            this.chart.Size = new System.Drawing.Size(879, 463);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphManagerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(862, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graphManagerToolStripMenuItem
            // 
            this.graphManagerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleRateToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.addRemoveBtn});
            this.graphManagerToolStripMenuItem.Name = "graphManagerToolStripMenuItem";
            this.graphManagerToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.graphManagerToolStripMenuItem.Text = "Graph";
            // 
            // sampleRateToolStripMenuItem
            // 
            this.sampleRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.sampleRateToolStripMenuItem.Name = "sampleRateToolStripMenuItem";
            this.sampleRateToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.sampleRateToolStripMenuItem.Text = "Sample Rate";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "1 Hz",
            "2 Hz",
            "10 Hz",
            "20 Hz",
            "50 Hz"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            // 
            // addRemoveBtn
            // 
            this.addRemoveBtn.Name = "addRemoveBtn";
            this.addRemoveBtn.Size = new System.Drawing.Size(177, 22);
            this.addRemoveBtn.Text = "Add/Remove Series";
            this.addRemoveBtn.Click += new System.EventHandler(this.addRemoveBtn_Click);
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 487);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GraphForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            this.Activated += new System.EventHandler(this.GraphForm_Activated);
            this.Deactivate += new System.EventHandler(this.GraphForm_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer graphTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graphManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sampleRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRemoveBtn;
    }
}