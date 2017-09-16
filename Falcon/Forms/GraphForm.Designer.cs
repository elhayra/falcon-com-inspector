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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graphManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRateitem = new System.Windows.Forms.ToolStripMenuItem();
            this.sampleRateCmBx = new System.Windows.Forms.ToolStripComboBox();
            this.tailLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tailCmBx = new System.Windows.Forms.ToolStripComboBox();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRmSeriesBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.resetGraphBtn = new System.Windows.Forms.ToolStripMenuItem();
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
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.Title = "Time (seconds)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.Title = "Bytes Per Second";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Black;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 27);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
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
            this.settingsToolStripMenuItem,
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
            this.sampleRateitem,
            this.tailLengthToolStripMenuItem});
            this.graphManagerToolStripMenuItem.Name = "graphManagerToolStripMenuItem";
            this.graphManagerToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.graphManagerToolStripMenuItem.Text = "Settings";
            // 
            // sampleRateitem
            // 
            this.sampleRateitem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sampleRateCmBx});
            this.sampleRateitem.Name = "sampleRateitem";
            this.sampleRateitem.Size = new System.Drawing.Size(152, 22);
            this.sampleRateitem.Text = "Sample Rate";
            // 
            // sampleRateCmBx
            // 
            this.sampleRateCmBx.Items.AddRange(new object[] {
            "1 Hz",
            "2 Hz",
            "10 Hz",
            "20 Hz",
            "50 Hz"});
            this.sampleRateCmBx.Name = "sampleRateCmBx";
            this.sampleRateCmBx.Size = new System.Drawing.Size(121, 23);
            this.sampleRateCmBx.Text = "1 Hz";
            this.sampleRateCmBx.SelectedIndexChanged += new System.EventHandler(this.sampleRateCmBx_SelectedIndexChanged);
            // 
            // tailLengthToolStripMenuItem
            // 
            this.tailLengthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tailCmBx});
            this.tailLengthToolStripMenuItem.Name = "tailLengthToolStripMenuItem";
            this.tailLengthToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tailLengthToolStripMenuItem.Text = "Tail Length";
            // 
            // tailCmBx
            // 
            this.tailCmBx.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "200",
            "500"});
            this.tailCmBx.Name = "tailCmBx";
            this.tailCmBx.Size = new System.Drawing.Size(121, 23);
            this.tailCmBx.Text = "10";
            this.tailCmBx.SelectedIndexChanged += new System.EventHandler(this.tailCmBx_SelectedIndexChanged);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRmSeriesBtn,
            this.resetGraphBtn});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.settingsToolStripMenuItem.Text = "Graph";
            // 
            // addRmSeriesBtn
            // 
            this.addRmSeriesBtn.Name = "addRmSeriesBtn";
            this.addRmSeriesBtn.Size = new System.Drawing.Size(183, 22);
            this.addRmSeriesBtn.Text = "Add / Remove Series";
            this.addRmSeriesBtn.Click += new System.EventHandler(this.addRmSeriesBtn_Click);
            // 
            // resetGraphBtn
            // 
            this.resetGraphBtn.Name = "resetGraphBtn";
            this.resetGraphBtn.Size = new System.Drawing.Size(183, 22);
            this.resetGraphBtn.Text = "Reset";
            this.resetGraphBtn.Click += new System.EventHandler(this.resetGraphBtn_Click);
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
        private System.Windows.Forms.ToolStripMenuItem sampleRateitem;
        private System.Windows.Forms.ToolStripComboBox sampleRateCmBx;
        private System.Windows.Forms.ToolStripMenuItem tailLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tailCmBx;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRmSeriesBtn;
        private System.Windows.Forms.ToolStripMenuItem resetGraphBtn;
    }
}