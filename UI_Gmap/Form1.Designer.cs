namespace UI_Gmap
{
    partial class Form1
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
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.clearPoint = new System.Windows.Forms.Button();
            this.getRoute = new System.Windows.Forms.Button();
            this.mapSize = new System.Windows.Forms.TrackBar();
            this.findByKeyText = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.mapSize)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(229, 12);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(559, 426);
            this.map.TabIndex = 1;
            this.map.Zoom = 0D;
            this.map.DoubleClick += new System.EventHandler(this.map_MouseDoubleClick);
            // 
            // clearPoint
            // 
            this.clearPoint.Location = new System.Drawing.Point(146, 44);
            this.clearPoint.Name = "clearPoint";
            this.clearPoint.Size = new System.Drawing.Size(63, 23);
            this.clearPoint.TabIndex = 5;
            this.clearPoint.Text = "Clear";
            this.clearPoint.UseVisualStyleBackColor = true;
            this.clearPoint.Click += new System.EventHandler(this.clearPoint_Click);
            // 
            // getRoute
            // 
            this.getRoute.Location = new System.Drawing.Point(12, 84);
            this.getRoute.Name = "getRoute";
            this.getRoute.Size = new System.Drawing.Size(75, 23);
            this.getRoute.TabIndex = 7;
            this.getRoute.Text = "Get Route";
            this.getRoute.UseVisualStyleBackColor = true;
            this.getRoute.Click += new System.EventHandler(this.getRoute_Click);
            // 
            // mapSize
            // 
            this.mapSize.Location = new System.Drawing.Point(12, 131);
            this.mapSize.Maximum = 20;
            this.mapSize.Minimum = 1;
            this.mapSize.Name = "mapSize";
            this.mapSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mapSize.Size = new System.Drawing.Size(45, 293);
            this.mapSize.TabIndex = 8;
            this.mapSize.Value = 13;
            this.mapSize.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // findByKeyText
            // 
            this.findByKeyText.Location = new System.Drawing.Point(12, 12);
            this.findByKeyText.Name = "findByKeyText";
            this.findByKeyText.Size = new System.Drawing.Size(197, 20);
            this.findByKeyText.TabIndex = 9;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(12, 44);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 10;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(218, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(582, 450);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.findByKeyText);
            this.Controls.Add(this.mapSize);
            this.Controls.Add(this.getRoute);
            this.Controls.Add(this.clearPoint);
            this.Controls.Add(this.map);
            this.Controls.Add(this.splitter1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mapSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Button clearPoint;
        private System.Windows.Forms.Button getRoute;
        private System.Windows.Forms.TrackBar mapSize;
        private System.Windows.Forms.TextBox findByKeyText;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Splitter splitter1;
    }
}

