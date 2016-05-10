namespace SS_OpenCV
{
    partial class MainForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastNegativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oneChannelGreyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x3MeanNoiseReductionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonUniformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosaoiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tAPDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aula1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aula2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aula3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentesLigadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watershedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byImmersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getGPLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aula4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houghTransformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houghLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hLinesWPreprocessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aula5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiplyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImageViewer = new System.Windows.Forms.PictureBox();
            this.aula7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images (*.png, *.bmp, *.jpg)|*.png;*.bmp;*.jpg";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.sinalToolStripMenuItem,
            this.tAPDIToolStripMenuItem,
            this.autoresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save As...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem,
            this.transformsToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.autoZoomToolStripMenuItem,
            this.erosaoiToolStripMenuItem,
            this.erodeToolStripMenuItem,
            this.dilateToolStripMenuItem,
            this.projectionToolStripMenuItem,
            this.findSignToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToToolStripMenuItem,
            this.negativeToolStripMenuItem,
            this.fastNegativeToolStripMenuItem,
            this.oneChannelGreyToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.colorToolStripMenuItem.Text = "Color";
            // 
            // convertToToolStripMenuItem
            // 
            this.convertToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayToolStripMenuItem,
            this.bWToolStripMenuItem});
            this.convertToToolStripMenuItem.Name = "convertToToolStripMenuItem";
            this.convertToToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.convertToToolStripMenuItem.Text = "Convert To";
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
            // 
            // bWToolStripMenuItem
            // 
            this.bWToolStripMenuItem.Name = "bWToolStripMenuItem";
            this.bWToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.bWToolStripMenuItem.Text = "B&W";
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.negativeToolStripMenuItem.Text = "Negative";
            this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negativeToolStripMenuItem_Click);
            // 
            // fastNegativeToolStripMenuItem
            // 
            this.fastNegativeToolStripMenuItem.Name = "fastNegativeToolStripMenuItem";
            this.fastNegativeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fastNegativeToolStripMenuItem.Text = "Fast Negative";
            this.fastNegativeToolStripMenuItem.Click += new System.EventHandler(this.fastNegativeToolStripMenuItem_Click);
            // 
            // oneChannelGreyToolStripMenuItem
            // 
            this.oneChannelGreyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueChannelToolStripMenuItem,
            this.greenChannelToolStripMenuItem,
            this.redChannelToolStripMenuItem});
            this.oneChannelGreyToolStripMenuItem.Name = "oneChannelGreyToolStripMenuItem";
            this.oneChannelGreyToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.oneChannelGreyToolStripMenuItem.Text = "One Channel (Grey)";
            // 
            // blueChannelToolStripMenuItem
            // 
            this.blueChannelToolStripMenuItem.Name = "blueChannelToolStripMenuItem";
            this.blueChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blueChannelToolStripMenuItem.Text = "Blue Channel";
            this.blueChannelToolStripMenuItem.Click += new System.EventHandler(this.blueChannelToolStripMenuItem_Click);
            // 
            // greenChannelToolStripMenuItem
            // 
            this.greenChannelToolStripMenuItem.Name = "greenChannelToolStripMenuItem";
            this.greenChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.greenChannelToolStripMenuItem.Text = "Green Channel";
            this.greenChannelToolStripMenuItem.Click += new System.EventHandler(this.greenChannelToolStripMenuItem_Click);
            // 
            // redChannelToolStripMenuItem
            // 
            this.redChannelToolStripMenuItem.Name = "redChannelToolStripMenuItem";
            this.redChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redChannelToolStripMenuItem.Text = "Red Channel";
            this.redChannelToolStripMenuItem.Click += new System.EventHandler(this.redChannelToolStripMenuItem_Click);
            // 
            // transformsToolStripMenuItem
            // 
            this.transformsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.transformsToolStripMenuItem.Name = "transformsToolStripMenuItem";
            this.transformsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.transformsToolStripMenuItem.Text = "Transforms";
            // 
            // translationToolStripMenuItem
            // 
            this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
            this.translationToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.translationToolStripMenuItem.Text = "Translation";
            this.translationToolStripMenuItem.Click += new System.EventHandler(this.translationToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3MeanNoiseReductionToolStripMenuItem,
            this.nonUniformToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.medianToolStripMenuItem,
            this.binarToolStripMenuItem,
            this.otsuToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // x3MeanNoiseReductionToolStripMenuItem
            // 
            this.x3MeanNoiseReductionToolStripMenuItem.Name = "x3MeanNoiseReductionToolStripMenuItem";
            this.x3MeanNoiseReductionToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.x3MeanNoiseReductionToolStripMenuItem.Text = "3x3 Mean Noise Reduction";
            this.x3MeanNoiseReductionToolStripMenuItem.Click += new System.EventHandler(this.x3MeanNoiseReductionToolStripMenuItem_Click);
            // 
            // nonUniformToolStripMenuItem
            // 
            this.nonUniformToolStripMenuItem.Name = "nonUniformToolStripMenuItem";
            this.nonUniformToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.nonUniformToolStripMenuItem.Text = "Non Uniform";
            this.nonUniformToolStripMenuItem.Click += new System.EventHandler(this.nonUniformToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sobelToolStripMenuItem.Text = "Sobel";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // binarToolStripMenuItem
            // 
            this.binarToolStripMenuItem.Name = "binarToolStripMenuItem";
            this.binarToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.binarToolStripMenuItem.Text = "Binar";
            this.binarToolStripMenuItem.Click += new System.EventHandler(this.binarToolStripMenuItem_Click);
            // 
            // otsuToolStripMenuItem
            // 
            this.otsuToolStripMenuItem.Name = "otsuToolStripMenuItem";
            this.otsuToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.otsuToolStripMenuItem.Text = "Otsu";
            this.otsuToolStripMenuItem.Click += new System.EventHandler(this.otsuToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // autoZoomToolStripMenuItem
            // 
            this.autoZoomToolStripMenuItem.Checked = true;
            this.autoZoomToolStripMenuItem.CheckOnClick = true;
            this.autoZoomToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoZoomToolStripMenuItem.Name = "autoZoomToolStripMenuItem";
            this.autoZoomToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.autoZoomToolStripMenuItem.Text = "Auto Zoom";
            this.autoZoomToolStripMenuItem.Click += new System.EventHandler(this.autoZoomToolStripMenuItem_Click);
            // 
            // erosaoiToolStripMenuItem
            // 
            this.erosaoiToolStripMenuItem.Name = "erosaoiToolStripMenuItem";
            this.erosaoiToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.erosaoiToolStripMenuItem.Text = "erosaoi";
            this.erosaoiToolStripMenuItem.Click += new System.EventHandler(this.erosaoiToolStripMenuItem_Click);
            // 
            // erodeToolStripMenuItem
            // 
            this.erodeToolStripMenuItem.Name = "erodeToolStripMenuItem";
            this.erodeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.erodeToolStripMenuItem.Text = "Erode";
            this.erodeToolStripMenuItem.Click += new System.EventHandler(this.erodeToolStripMenuItem_Click);
            // 
            // dilateToolStripMenuItem
            // 
            this.dilateToolStripMenuItem.Name = "dilateToolStripMenuItem";
            this.dilateToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dilateToolStripMenuItem.Text = "Dilate";
            this.dilateToolStripMenuItem.Click += new System.EventHandler(this.dilateToolStripMenuItem_Click);
            // 
            // projectionToolStripMenuItem
            // 
            this.projectionToolStripMenuItem.Name = "projectionToolStripMenuItem";
            this.projectionToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.projectionToolStripMenuItem.Text = "Projection";
            this.projectionToolStripMenuItem.Click += new System.EventHandler(this.projectionToolStripMenuItem_Click);
            // 
            // findSignToolStripMenuItem
            // 
            this.findSignToolStripMenuItem.Name = "findSignToolStripMenuItem";
            this.findSignToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.findSignToolStripMenuItem.Text = "Find Sign";
            this.findSignToolStripMenuItem.Click += new System.EventHandler(this.findSignToolStripMenuItem_Click);
            // 
            // sinalToolStripMenuItem
            // 
            this.sinalToolStripMenuItem.Name = "sinalToolStripMenuItem";
            this.sinalToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.sinalToolStripMenuItem.Text = "Sinal";
            this.sinalToolStripMenuItem.Click += new System.EventHandler(this.sinalToolStripMenuItem_Click);
            // 
            // tAPDIToolStripMenuItem
            // 
            this.tAPDIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aula1ToolStripMenuItem,
            this.aula2ToolStripMenuItem,
            this.aula3ToolStripMenuItem,
            this.aula4ToolStripMenuItem,
            this.aula5ToolStripMenuItem,
            this.aula7ToolStripMenuItem});
            this.tAPDIToolStripMenuItem.Name = "tAPDIToolStripMenuItem";
            this.tAPDIToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tAPDIToolStripMenuItem.Text = "TAPDI";
            // 
            // aula1ToolStripMenuItem
            // 
            this.aula1ToolStripMenuItem.Name = "aula1ToolStripMenuItem";
            this.aula1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula1ToolStripMenuItem.Text = "Aula 1";
            this.aula1ToolStripMenuItem.Click += new System.EventHandler(this.aula1ToolStripMenuItem_Click);
            // 
            // aula2ToolStripMenuItem
            // 
            this.aula2ToolStripMenuItem.Name = "aula2ToolStripMenuItem";
            this.aula2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula2ToolStripMenuItem.Text = "Aula 2";
            this.aula2ToolStripMenuItem.Click += new System.EventHandler(this.aula2ToolStripMenuItem_Click);
            // 
            // aula3ToolStripMenuItem
            // 
            this.aula3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentesLigadosToolStripMenuItem,
            this.watershedToolStripMenuItem,
            this.getGPLToolStripMenuItem});
            this.aula3ToolStripMenuItem.Name = "aula3ToolStripMenuItem";
            this.aula3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula3ToolStripMenuItem.Text = "Aula 3";
            // 
            // componentesLigadosToolStripMenuItem
            // 
            this.componentesLigadosToolStripMenuItem.Name = "componentesLigadosToolStripMenuItem";
            this.componentesLigadosToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.componentesLigadosToolStripMenuItem.Text = "Componentes Ligados";
            this.componentesLigadosToolStripMenuItem.Click += new System.EventHandler(this.componentesLigadosToolStripMenuItem_Click);
            // 
            // watershedToolStripMenuItem
            // 
            this.watershedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromLabelsToolStripMenuItem,
            this.byImmersionToolStripMenuItem});
            this.watershedToolStripMenuItem.Name = "watershedToolStripMenuItem";
            this.watershedToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.watershedToolStripMenuItem.Text = "Watershed";
            // 
            // fromLabelsToolStripMenuItem
            // 
            this.fromLabelsToolStripMenuItem.Name = "fromLabelsToolStripMenuItem";
            this.fromLabelsToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.fromLabelsToolStripMenuItem.Text = "From Labels";
            this.fromLabelsToolStripMenuItem.Click += new System.EventHandler(this.fromLabelsToolStripMenuItem_Click);
            // 
            // byImmersionToolStripMenuItem
            // 
            this.byImmersionToolStripMenuItem.Name = "byImmersionToolStripMenuItem";
            this.byImmersionToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.byImmersionToolStripMenuItem.Text = "By Immersion";
            this.byImmersionToolStripMenuItem.Click += new System.EventHandler(this.byImmersionToolStripMenuItem_Click);
            // 
            // getGPLToolStripMenuItem
            // 
            this.getGPLToolStripMenuItem.Name = "getGPLToolStripMenuItem";
            this.getGPLToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.getGPLToolStripMenuItem.Text = "GetGPL";
            this.getGPLToolStripMenuItem.Click += new System.EventHandler(this.getGPLToolStripMenuItem_Click);
            // 
            // aula4ToolStripMenuItem
            // 
            this.aula4ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.houghTransformsToolStripMenuItem,
            this.houghLinesToolStripMenuItem,
            this.hLinesWPreprocessingToolStripMenuItem,
            this.circlesToolStripMenuItem});
            this.aula4ToolStripMenuItem.Name = "aula4ToolStripMenuItem";
            this.aula4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula4ToolStripMenuItem.Text = "Aula 4";
            // 
            // houghTransformsToolStripMenuItem
            // 
            this.houghTransformsToolStripMenuItem.Name = "houghTransformsToolStripMenuItem";
            this.houghTransformsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.houghTransformsToolStripMenuItem.Text = "Hough Transforms";
            this.houghTransformsToolStripMenuItem.Click += new System.EventHandler(this.houghTransformsToolStripMenuItem_Click);
            // 
            // houghLinesToolStripMenuItem
            // 
            this.houghLinesToolStripMenuItem.Name = "houghLinesToolStripMenuItem";
            this.houghLinesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.houghLinesToolStripMenuItem.Text = "Hough Lines";
            this.houghLinesToolStripMenuItem.Click += new System.EventHandler(this.houghLinesToolStripMenuItem_Click);
            // 
            // hLinesWPreprocessingToolStripMenuItem
            // 
            this.hLinesWPreprocessingToolStripMenuItem.Name = "hLinesWPreprocessingToolStripMenuItem";
            this.hLinesWPreprocessingToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.hLinesWPreprocessingToolStripMenuItem.Text = "H. Lines w/Preprocessing";
            this.hLinesWPreprocessingToolStripMenuItem.Click += new System.EventHandler(this.hLinesWPreprocessingToolStripMenuItem_Click);
            // 
            // circlesToolStripMenuItem
            // 
            this.circlesToolStripMenuItem.Name = "circlesToolStripMenuItem";
            this.circlesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.circlesToolStripMenuItem.Text = "Circles";
            this.circlesToolStripMenuItem.Click += new System.EventHandler(this.circlesToolStripMenuItem_Click);
            // 
            // aula5ToolStripMenuItem
            // 
            this.aula5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getInfoToolStripMenuItem,
            this.multiplyToolStripMenuItem});
            this.aula5ToolStripMenuItem.Name = "aula5ToolStripMenuItem";
            this.aula5ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula5ToolStripMenuItem.Text = "Aula 5";
            // 
            // getInfoToolStripMenuItem
            // 
            this.getInfoToolStripMenuItem.Name = "getInfoToolStripMenuItem";
            this.getInfoToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.getInfoToolStripMenuItem.Text = "Get Info";
            this.getInfoToolStripMenuItem.Click += new System.EventHandler(this.getInfoToolStripMenuItem_Click);
            // 
            // multiplyToolStripMenuItem
            // 
            this.multiplyToolStripMenuItem.Name = "multiplyToolStripMenuItem";
            this.multiplyToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.multiplyToolStripMenuItem.Text = "Multiply";
            this.multiplyToolStripMenuItem.Click += new System.EventHandler(this.multiplyToolStripMenuItem_Click);
            // 
            // autoresToolStripMenuItem
            // 
            this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
            this.autoresToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.autoresToolStripMenuItem.Text = "Autores...";
            this.autoresToolStripMenuItem.Click += new System.EventHandler(this.autoresToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ImageViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 524);
            this.panel1.TabIndex = 6;
            // 
            // ImageViewer
            // 
            this.ImageViewer.Location = new System.Drawing.Point(0, 0);
            this.ImageViewer.Name = "ImageViewer";
            this.ImageViewer.Size = new System.Drawing.Size(576, 427);
            this.ImageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ImageViewer.TabIndex = 6;
            this.ImageViewer.TabStop = false;
            this.ImageViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageViewer_MouseClick);
            // 
            // aula7ToolStripMenuItem
            // 
            this.aula7ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoToolStripMenuItem});
            this.aula7ToolStripMenuItem.Name = "aula7ToolStripMenuItem";
            this.aula7ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aula7ToolStripMenuItem.Text = "Aula 7";
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.videoToolStripMenuItem.Text = "Video";
            this.videoToolStripMenuItem.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Sistemas Sensoriais 2015/2016 - Image processing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoZoomToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImageViewer;
        private System.Windows.Forms.ToolStripMenuItem fastNegativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oneChannelGreyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x3MeanNoiseReductionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonUniformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otsuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sinalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosaoiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dilateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tAPDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentesLigadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byImmersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watershedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getGPLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem houghTransformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem houghLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hLinesWPreprocessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiplyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aula7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
    }
}

