namespace ArcGISTool
{
    partial class ArcGISWindows
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
        {            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.byFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractionByMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.defineProjectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hydrolofyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamReachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.dataSetsToolStripMenuItem,
            this.hydrolofyToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(497, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // dataSetsToolStripMenuItem
            // 
            this.dataSetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preparationToolStripMenuItem,
            this.conversionToolStripMenuItem1,
            this.extractionToolStripMenuItem,
            this.projectionToolStripMenuItem1,
            this.setPropertiesToolStripMenuItem});
            this.dataSetsToolStripMenuItem.Name = "dataSetsToolStripMenuItem";
            this.dataSetsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.dataSetsToolStripMenuItem.Text = "DataSets";
            // 
            // preparationToolStripMenuItem
            // 
            this.preparationToolStripMenuItem.Name = "preparationToolStripMenuItem";
            this.preparationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.preparationToolStripMenuItem.Text = "Preparation";
            // 
            // conversionToolStripMenuItem1
            // 
            this.conversionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byFolderToolStripMenuItem,
            this.byToolStripMenuItem});
            this.conversionToolStripMenuItem1.Name = "conversionToolStripMenuItem1";
            this.conversionToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.conversionToolStripMenuItem1.Text = "Conversion";
            // 
            // byFolderToolStripMenuItem
            // 
            this.byFolderToolStripMenuItem.Name = "byFolderToolStripMenuItem";
            this.byFolderToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.byFolderToolStripMenuItem.Text = "Raster";
            this.byFolderToolStripMenuItem.Click += new System.EventHandler(this.byFolderToolStripMenuItem_Click);
            // 
            // byToolStripMenuItem
            // 
            this.byToolStripMenuItem.Name = "byToolStripMenuItem";
            this.byToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.byToolStripMenuItem.Text = "By ";
            // 
            // extractionToolStripMenuItem
            // 
            this.extractionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractionByMaskToolStripMenuItem});
            this.extractionToolStripMenuItem.Name = "extractionToolStripMenuItem";
            this.extractionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.extractionToolStripMenuItem.Text = "Extraction";
            // 
            // extractionByMaskToolStripMenuItem
            // 
            this.extractionByMaskToolStripMenuItem.Name = "extractionByMaskToolStripMenuItem";
            this.extractionByMaskToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.extractionByMaskToolStripMenuItem.Text = "Extraction by mask";
            this.extractionByMaskToolStripMenuItem.Click += new System.EventHandler(this.extractionByMaskToolStripMenuItem_Click);
            // 
            // projectionToolStripMenuItem1
            // 
            this.projectionToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineProjectionToolStripMenuItem,
            this.projectionToolStripMenuItem});
            this.projectionToolStripMenuItem1.Name = "projectionToolStripMenuItem1";
            this.projectionToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.projectionToolStripMenuItem1.Text = "Projection";
            // 
            // defineProjectionToolStripMenuItem
            // 
            this.defineProjectionToolStripMenuItem.Name = "defineProjectionToolStripMenuItem";
            this.defineProjectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.defineProjectionToolStripMenuItem.Text = "Define projection";
            this.defineProjectionToolStripMenuItem.Click += new System.EventHandler(this.defineProjectionToolStripMenuItem_Click);
            // 
            // projectionToolStripMenuItem
            // 
            this.projectionToolStripMenuItem.Name = "projectionToolStripMenuItem";
            this.projectionToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.projectionToolStripMenuItem.Text = "Projection";
            this.projectionToolStripMenuItem.Click += new System.EventHandler(this.projectionToolStripMenuItem_Click);
            // 
            // hydrolofyToolStripMenuItem
            // 
            this.hydrolofyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamReachToolStripMenuItem});
            this.hydrolofyToolStripMenuItem.Name = "hydrolofyToolStripMenuItem";
            this.hydrolofyToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.hydrolofyToolStripMenuItem.Text = "Hydrology";
            // 
            // streamReachToolStripMenuItem
            // 
            this.streamReachToolStripMenuItem.Name = "streamReachToolStripMenuItem";
            this.streamReachToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.streamReachToolStripMenuItem.Text = "StreamReach";
            this.streamReachToolStripMenuItem.Click += new System.EventHandler(this.streamReachToolStripMenuItem_Click);
            // 
            // setPropertiesToolStripMenuItem
            // 
            this.setPropertiesToolStripMenuItem.Name = "setPropertiesToolStripMenuItem";
            this.setPropertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.setPropertiesToolStripMenuItem.Text = "Set Properties";
            this.setPropertiesToolStripMenuItem.Click += new System.EventHandler(this.setPropertiesToolStripMenuItem_Click);
            // 
            // ArcGISWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 345);
            this.Controls.Add(this.MainMenu);
            this.Name = "ArcGISWindows";
            this.Text = "ArcGISWindows";
            this.Load += new System.EventHandler(this.ArcGISWindows_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hydrolofyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem defineProjectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem extractionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractionByMaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preparationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamReachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPropertiesToolStripMenuItem;

    }
}

