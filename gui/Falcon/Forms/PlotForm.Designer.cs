namespace Falcon.Forms
{
    partial class PlotForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("index 0", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("index 1", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("index 2", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("index 3", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("index 4", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("index 5", new System.Windows.Forms.TreeNode[] {
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("index 6", new System.Windows.Forms.TreeNode[] {
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("index 7", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("index 8", new System.Windows.Forms.TreeNode[] {
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("null");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("null", new System.Windows.Forms.TreeNode[] {
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("index 9", new System.Windows.Forms.TreeNode[] {
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Incoming Data", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode9,
            treeNode12,
            treeNode15,
            treeNode18,
            treeNode21,
            treeNode24,
            treeNode27,
            treeNode30});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotForm));
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphTimer = new System.Windows.Forms.Timer(this.components);
            this.applyBtn = new System.Windows.Forms.Button();
            this.addRmBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tailTxt = new System.Windows.Forms.NumericUpDown();
            this.treeView = new System.Windows.Forms.TreeView();
            this.invalidDataLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailTxt)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.chart.Location = new System.Drawing.Point(171, -1);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart.Size = new System.Drawing.Size(811, 561);
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
            // applyBtn
            // 
            this.applyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyBtn.ForeColor = System.Drawing.Color.Black;
            this.applyBtn.Location = new System.Drawing.Point(908, 8);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(65, 27);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // addRmBtn
            // 
            this.addRmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addRmBtn.ForeColor = System.Drawing.Color.Black;
            this.addRmBtn.Location = new System.Drawing.Point(5, 5);
            this.addRmBtn.Name = "addRmBtn";
            this.addRmBtn.Size = new System.Drawing.Size(86, 35);
            this.addRmBtn.TabIndex = 6;
            this.addRmBtn.Text = "Add / Remove Series";
            this.addRmBtn.UseVisualStyleBackColor = true;
            this.addRmBtn.Click += new System.EventHandler(this.addRmBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(746, 15);
            this.label2.MaximumSize = new System.Drawing.Size(86, 0);
            this.label2.MinimumSize = new System.Drawing.Size(50, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tail Length:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tailTxt
            // 
            this.tailTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tailTxt.BackColor = System.Drawing.Color.LightGreen;
            this.tailTxt.Location = new System.Drawing.Point(814, 12);
            this.tailTxt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tailTxt.Name = "tailTxt";
            this.tailTxt.Size = new System.Drawing.Size(86, 20);
            this.tailTxt.TabIndex = 5;
            this.tailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tailTxt.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tailTxt.ValueChanged += new System.EventHandler(this.tailTxt_ValueChanged);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView.BackColor = System.Drawing.Color.Black;
            this.treeView.ForeColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(1, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "data";
            treeNode1.Text = "null";
            treeNode2.Name = "name";
            treeNode2.Text = "null";
            treeNode3.Name = "index0";
            treeNode3.Text = "index 0";
            treeNode4.Name = "data";
            treeNode4.Text = "null";
            treeNode5.Name = "name";
            treeNode5.Text = "null";
            treeNode6.Name = "index1 ";
            treeNode6.Text = "index 1";
            treeNode7.Name = "data";
            treeNode7.Text = "null";
            treeNode8.Name = "name";
            treeNode8.Text = "null";
            treeNode9.Name = "index2";
            treeNode9.Text = "index 2";
            treeNode10.Name = "data";
            treeNode10.Text = "null";
            treeNode11.Name = "name";
            treeNode11.Text = "null";
            treeNode12.Name = "index3";
            treeNode12.Text = "index 3";
            treeNode13.Name = "data";
            treeNode13.Text = "null";
            treeNode14.Name = "name";
            treeNode14.Text = "null";
            treeNode15.Name = "index4";
            treeNode15.Text = "index 4";
            treeNode16.Name = "data";
            treeNode16.Text = "null";
            treeNode17.Name = "name";
            treeNode17.Text = "null";
            treeNode18.Name = "index5";
            treeNode18.Text = "index 5";
            treeNode19.Name = "data";
            treeNode19.Text = "null";
            treeNode20.Name = "name";
            treeNode20.Text = "null";
            treeNode21.Name = "index6";
            treeNode21.Text = "index 6";
            treeNode22.Name = "data";
            treeNode22.Text = "null";
            treeNode23.Name = "name";
            treeNode23.Text = "null";
            treeNode24.Name = "index7";
            treeNode24.Text = "index 7";
            treeNode25.Name = "data";
            treeNode25.Text = "null";
            treeNode26.Name = "name";
            treeNode26.Text = "null";
            treeNode27.Name = "index8";
            treeNode27.Text = "index 8";
            treeNode28.Name = "data";
            treeNode28.Text = "null";
            treeNode29.Name = "name";
            treeNode29.Text = "null";
            treeNode30.Name = "index9";
            treeNode30.Text = "index 9";
            treeNode31.Name = "dataIndexes";
            treeNode31.Text = "Incoming Data";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode31});
            this.treeView.Size = new System.Drawing.Size(178, 560);
            this.treeView.TabIndex = 8;
            // 
            // invalidDataLbl
            // 
            this.invalidDataLbl.AutoSize = true;
            this.invalidDataLbl.BackColor = System.Drawing.Color.Red;
            this.invalidDataLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidDataLbl.ForeColor = System.Drawing.Color.White;
            this.invalidDataLbl.Location = new System.Drawing.Point(187, 6);
            this.invalidDataLbl.Name = "invalidDataLbl";
            this.invalidDataLbl.Size = new System.Drawing.Size(111, 16);
            this.invalidDataLbl.TabIndex = 8;
            this.invalidDataLbl.Text = "INVALID DATA";
            this.invalidDataLbl.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.addRmBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tailTxt);
            this.panel1.Controls.Add(this.applyBtn);
            this.panel1.Location = new System.Drawing.Point(1, 515);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(981, 45);
            this.panel1.TabIndex = 9;
            // 
            // PlotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.invalidDataLbl);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PlotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plot";
            this.Activated += new System.EventHandler(this.GraphForm_Activated);
            this.Deactivate += new System.EventHandler(this.GraphForm_Deactivate);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GraphForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tailTxt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Timer graphTimer;
        private System.Windows.Forms.NumericUpDown tailTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addRmBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Label invalidDataLbl;
        private System.Windows.Forms.Panel panel1;
    }
}