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
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("index 0", new System.Windows.Forms.TreeNode[] {
            treeNode33});
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("index 1", new System.Windows.Forms.TreeNode[] {
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode38});
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("index 2", new System.Windows.Forms.TreeNode[] {
            treeNode39});
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode41});
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("index 3", new System.Windows.Forms.TreeNode[] {
            treeNode42});
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("index 4", new System.Windows.Forms.TreeNode[] {
            treeNode45});
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode47});
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("index 5", new System.Windows.Forms.TreeNode[] {
            treeNode48});
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode50});
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("index 6", new System.Windows.Forms.TreeNode[] {
            treeNode51});
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode53});
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("index 7", new System.Windows.Forms.TreeNode[] {
            treeNode54});
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("index 8", new System.Windows.Forms.TreeNode[] {
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode59});
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("index 9", new System.Windows.Forms.TreeNode[] {
            treeNode60});
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("Incoming Data", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode37,
            treeNode40,
            treeNode43,
            treeNode46,
            treeNode49,
            treeNode52,
            treeNode55,
            treeNode58,
            treeNode61});
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
            this.chart.Location = new System.Drawing.Point(171, -1);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart.Size = new System.Drawing.Size(971, 561);
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
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.applyBtn);
            this.groupBox1.Controls.Add(this.addRmBtn);
            this.groupBox1.Controls.Add(this.sampleRateTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.resetBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tailTxt);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(179, 493);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(963, 67);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // applyBtn
            // 
            this.applyBtn.ForeColor = System.Drawing.Color.Black;
            this.applyBtn.Location = new System.Drawing.Point(222, 15);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(64, 43);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // addRmBtn
            // 
            this.addRmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addRmBtn.ForeColor = System.Drawing.Color.Black;
            this.addRmBtn.Location = new System.Drawing.Point(771, 15);
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
            this.tailTxt.Location = new System.Drawing.Point(118, 38);
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
            this.label2.Location = new System.Drawing.Point(115, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tail Length (Points):";
            // 
            // sampleRateTxt
            // 
            this.sampleRateTxt.BackColor = System.Drawing.Color.LightGreen;
            this.sampleRateTxt.Location = new System.Drawing.Point(17, 38);
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
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sample Rate (Hz):";
            // 
            // resetBtn
            // 
            this.resetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resetBtn.ForeColor = System.Drawing.Color.Black;
            this.resetBtn.Location = new System.Drawing.Point(867, 15);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(90, 43);
            this.resetBtn.TabIndex = 0;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.BackColor = System.Drawing.Color.Black;
            this.treeView.ForeColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(1, 0);
            this.treeView.Name = "treeView";
            treeNode32.Name = "data";
            treeNode32.Text = "null";
            treeNode33.Name = "name";
            treeNode33.Text = "null";
            treeNode34.Name = "index0";
            treeNode34.Text = "index 0";
            treeNode35.Name = "data";
            treeNode35.Text = "null";
            treeNode36.Name = "name";
            treeNode36.Text = "null";
            treeNode37.Name = "index1 ";
            treeNode37.Text = "index 1";
            treeNode38.Name = "data";
            treeNode38.Text = "null";
            treeNode39.Name = "name";
            treeNode39.Text = "null";
            treeNode40.Name = "index2";
            treeNode40.Text = "index 2";
            treeNode41.Name = "data";
            treeNode41.Text = "null";
            treeNode42.Name = "name";
            treeNode42.Text = "null";
            treeNode43.Name = "index3";
            treeNode43.Text = "index 3";
            treeNode44.Name = "data";
            treeNode44.Text = "null";
            treeNode45.Name = "name";
            treeNode45.Text = "null";
            treeNode46.Name = "index4";
            treeNode46.Text = "index 4";
            treeNode47.Name = "data";
            treeNode47.Text = "null";
            treeNode48.Name = "name";
            treeNode48.Text = "null";
            treeNode49.Name = "index5";
            treeNode49.Text = "index 5";
            treeNode50.Name = "data";
            treeNode50.Text = "null";
            treeNode51.Name = "name";
            treeNode51.Text = "null";
            treeNode52.Name = "index6";
            treeNode52.Text = "index 6";
            treeNode53.Name = "data";
            treeNode53.Text = "null";
            treeNode54.Name = "name";
            treeNode54.Text = "null";
            treeNode55.Name = "index7";
            treeNode55.Text = "index 7";
            treeNode56.Name = "data";
            treeNode56.Text = "null";
            treeNode57.Name = "name";
            treeNode57.Text = "null";
            treeNode58.Name = "index8";
            treeNode58.Text = "index 8";
            treeNode59.Name = "data";
            treeNode59.Text = "null";
            treeNode60.Name = "name";
            treeNode60.Text = "null";
            treeNode61.Name = "index9";
            treeNode61.Text = "index 9";
            treeNode62.Name = "dataIndexes";
            treeNode62.Text = "Incoming Data";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode62});
            this.treeView.Size = new System.Drawing.Size(178, 560);
            this.treeView.TabIndex = 8;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 558);
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
    }
}