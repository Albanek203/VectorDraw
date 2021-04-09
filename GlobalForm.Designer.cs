namespace WinFormVectorDraw {
    partial class GlobalForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalForm));
            this.drawBox                = new System.Windows.Forms.Panel();
            this.txtInfo                = new System.Windows.Forms.Label();
            this.butSelect              = new System.Windows.Forms.ToolStripButton();
            this.butLine                = new System.Windows.Forms.ToolStripButton();
            this.butRemoveEl            = new System.Windows.Forms.ToolStripButton();
            this.toolStrip              = new System.Windows.Forms.ToolStrip();
            this.butSquare              = new System.Windows.Forms.ToolStripButton();
            this.butRectangle           = new System.Windows.Forms.ToolStripButton();
            this.butCircle              = new System.Windows.Forms.ToolStripButton();
            this.butEllipse             = new System.Windows.Forms.ToolStripButton();
            this.butText                = new System.Windows.Forms.ToolStripButton();
            this.menuStrip              = new System.Windows.Forms.MenuStrip();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem  = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem  = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbColors              = new System.Windows.Forms.ToolStripComboBox();
            this.txtThickness           = new System.Windows.Forms.ToolStripTextBox();
            this.txtText                = new System.Windows.Forms.ToolStripTextBox();
            this.cmbFont                = new System.Windows.Forms.ToolStripComboBox();
            this.cmbTypeFill            = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFillColors_1        = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFillColors_2        = new System.Windows.Forms.ToolStripComboBox();
            this.saveFileDialog         = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog         = new System.Windows.Forms.OpenFileDialog();
            this.GlTime                 = new System.Timers.Timer();
            this.txtCoordinate          = new System.Windows.Forms.Label();
            this.drawBox.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GlTime)).BeginInit();
            this.SuspendLayout();
            // 
            // drawBox
            // 
            this.drawBox.Anchor    = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.drawBox.BackColor = System.Drawing.Color.White;
            this.drawBox.Controls.Add(this.txtInfo);
            this.drawBox.Location   =  new System.Drawing.Point(0, 27);
            this.drawBox.Name       =  "drawBox";
            this.drawBox.Size       =  new System.Drawing.Size(860, 534);
            this.drawBox.TabIndex   =  0;
            this.drawBox.Paint      += new System.Windows.Forms.PaintEventHandler(this.drawBox_Paint);
            this.drawBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseClick);
            this.drawBox.MouseDown  += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseDown);
            this.drawBox.MouseMove  += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseMove);
            this.drawBox.MouseUp    += new System.Windows.Forms.MouseEventHandler(this.drawBox_MouseUp);
            // 
            // txtInfo
            // 
            this.txtInfo.Anchor    = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtInfo.AutoSize  = true;
            this.txtInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtInfo.Font      = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.txtInfo.Location  = new System.Drawing.Point(12, 509);
            this.txtInfo.Name      = "txtInfo";
            this.txtInfo.Size      = new System.Drawing.Size(0, 16);
            this.txtInfo.TabIndex  = 3;
            this.txtInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtInfo.Visible   = false;
            // 
            // butSelect
            // 
            this.butSelect.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butSelect.Image                 =  global::WinFormVectorDraw.Properties.Resources.@select;
            this.butSelect.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butSelect.Name                  =  "butSelect";
            this.butSelect.Size                  =  new System.Drawing.Size(21, 20);
            this.butSelect.Text                  =  "Select";
            this.butSelect.Click                 += new System.EventHandler(this.butSelect_Click);
            // 
            // butLine
            // 
            this.butLine.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butLine.Image                 =  global::WinFormVectorDraw.Properties.Resources.line;
            this.butLine.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butLine.Name                  =  "butLine";
            this.butLine.Size                  =  new System.Drawing.Size(21, 20);
            this.butLine.Text                  =  "Line";
            this.butLine.Click                 += new System.EventHandler(this.butLine_Click);
            // 
            // butRemoveEl
            // 
            this.butRemoveEl.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRemoveEl.Image                 =  global::WinFormVectorDraw.Properties.Resources.trash;
            this.butRemoveEl.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butRemoveEl.Name                  =  "butRemoveEl";
            this.butRemoveEl.Size                  =  new System.Drawing.Size(21, 20);
            this.butRemoveEl.Text                  =  "Remove Element";
            this.butRemoveEl.Click                 += new System.EventHandler(this.butDelLine_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip.Dock      = System.Windows.Forms.DockStyle.Right;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.butSelect, this.butLine, this.butSquare, this.butRectangle, this.butCircle, this.butEllipse, this.butText, this.butRemoveEl});
            this.toolStrip.Location = new System.Drawing.Point(860, 27);
            this.toolStrip.Name     = "toolStrip";
            this.toolStrip.Size     = new System.Drawing.Size(24, 534);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text     = "Tool Bar";
            // 
            // butSquare
            // 
            this.butSquare.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butSquare.Image                 =  global::WinFormVectorDraw.Properties.Resources.square;
            this.butSquare.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butSquare.Name                  =  "butSquare";
            this.butSquare.Size                  =  new System.Drawing.Size(21, 20);
            this.butSquare.Text                  =  "Square";
            this.butSquare.Click                 += new System.EventHandler(this.butSquare_Click);
            // 
            // butRectangle
            // 
            this.butRectangle.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butRectangle.Image                 =  global::WinFormVectorDraw.Properties.Resources.rectangle;
            this.butRectangle.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butRectangle.Name                  =  "butRectangle";
            this.butRectangle.Size                  =  new System.Drawing.Size(21, 20);
            this.butRectangle.Text                  =  "Rectangle";
            this.butRectangle.Click                 += new System.EventHandler(this.butRectangle_Click);
            // 
            // butCircle
            // 
            this.butCircle.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butCircle.Image                 =  global::WinFormVectorDraw.Properties.Resources.circle;
            this.butCircle.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butCircle.Name                  =  "butCircle";
            this.butCircle.Size                  =  new System.Drawing.Size(21, 20);
            this.butCircle.Text                  =  "Circle";
            this.butCircle.Click                 += new System.EventHandler(this.butCircle_Click);
            // 
            // butEllipse
            // 
            this.butEllipse.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butEllipse.Image                 =  global::WinFormVectorDraw.Properties.Resources.ellipse;
            this.butEllipse.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butEllipse.Name                  =  "butEllipse";
            this.butEllipse.Size                  =  new System.Drawing.Size(21, 20);
            this.butEllipse.Text                  =  "Ellipse";
            this.butEllipse.Click                 += new System.EventHandler(this.butEllipse_Click);
            // 
            // butText
            // 
            this.butText.DisplayStyle          =  System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butText.Image                 =  global::WinFormVectorDraw.Properties.Resources._string;
            this.butText.ImageTransparentColor =  System.Drawing.Color.Magenta;
            this.butText.Name                  =  "butText";
            this.butText.Size                  =  new System.Drawing.Size(21, 20);
            this.butText.Text                  =  "Text";
            this.butText.Click                 += new System.EventHandler(this.butText_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.imageToolStripMenuItem, this.cmbColors, this.txtThickness, this.txtText, this.cmbFont, this.cmbTypeFill, this.cmbFillColors_1, this.cmbFillColors_2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name     = "menuStrip";
            this.menuStrip.Size     = new System.Drawing.Size(884, 27);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text     = "Menu";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.saveToolStripMenuItem, this.loadToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 23);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name  =  "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size  =  new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text  =  "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name  =  "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size  =  new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text  =  "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // cmbColors
            // 
            this.cmbColors.AccessibleRole =  System.Windows.Forms.AccessibleRole.Cursor;
            this.cmbColors.DropDownStyle  =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColors.FlatStyle      =  System.Windows.Forms.FlatStyle.System;
            this.cmbColors.Name           =  "cmbColors";
            this.cmbColors.Size           =  new System.Drawing.Size(75, 23);
            this.cmbColors.DropDownClosed += new System.EventHandler(this.cmbColors_DropDownClosed);
            // 
            // txtThickness
            // 
            this.txtThickness.BorderStyle =  System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThickness.Name        =  "txtThickness";
            this.txtThickness.Size        =  new System.Drawing.Size(100, 23);
            this.txtThickness.Text        =  "1";
            this.txtThickness.TextChanged += new System.EventHandler(this.txtThickness_TextChanged);
            // 
            // txtText
            // 
            this.txtText.BorderStyle =  System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtText.Name        =  "txtText";
            this.txtText.Size        =  new System.Drawing.Size(100, 23);
            this.txtText.Text        =  "Text";
            this.txtText.Visible     =  false;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            // 
            // cmbFont
            // 
            this.cmbFont.DropDownStyle  =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFont.FlatStyle      =  System.Windows.Forms.FlatStyle.System;
            this.cmbFont.Name           =  "cmbFont";
            this.cmbFont.Size           =  new System.Drawing.Size(121, 23);
            this.cmbFont.Visible        =  false;
            this.cmbFont.DropDownClosed += new System.EventHandler(this.cmbFont_DropDownClosed);
            // 
            // cmbTypeFill
            // 
            this.cmbTypeFill.DropDownStyle  =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeFill.FlatStyle      =  System.Windows.Forms.FlatStyle.System;
            this.cmbTypeFill.Name           =  "cmbTypeFill";
            this.cmbTypeFill.Size           =  new System.Drawing.Size(90, 23);
            this.cmbTypeFill.DropDownClosed += new System.EventHandler(this.cmbTypeFill_DropDownClosed);
            this.cmbTypeFill.Click          += new System.EventHandler(this.cmbTypeFill_Click);
            // 
            // cmbFillColors_1
            // 
            this.cmbFillColors_1.DropDownStyle  =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFillColors_1.FlatStyle      =  System.Windows.Forms.FlatStyle.System;
            this.cmbFillColors_1.Name           =  "cmbFillColors_1";
            this.cmbFillColors_1.Size           =  new System.Drawing.Size(75, 23);
            this.cmbFillColors_1.DropDownClosed += new System.EventHandler(this.cmbFillColors_1_DropDownClosed);
            this.cmbFillColors_1.Click          += new System.EventHandler(this.cmbFillColors_Click);
            // 
            // cmbFillColors_2
            // 
            this.cmbFillColors_2.DropDownStyle  =  System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFillColors_2.FlatStyle      =  System.Windows.Forms.FlatStyle.System;
            this.cmbFillColors_2.Name           =  "cmbFillColors_2";
            this.cmbFillColors_2.Size           =  new System.Drawing.Size(75, 23);
            this.cmbFillColors_2.Visible        =  false;
            this.cmbFillColors_2.DropDownClosed += new System.EventHandler(this.cmbFillColors_2_DropDownClosed);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            // 
            // GlTime
            // 
            this.GlTime.Enabled             =  true;
            this.GlTime.Interval            =  3000D;
            this.GlTime.SynchronizingObject =  this;
            this.GlTime.Elapsed             += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // txtCoordinate
            // 
            this.txtCoordinate.Anchor    = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCoordinate.AutoSize  = true;
            this.txtCoordinate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtCoordinate.Font      = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.txtCoordinate.Location  = new System.Drawing.Point(799, 4);
            this.txtCoordinate.Name      = "txtCoordinate";
            this.txtCoordinate.Size      = new System.Drawing.Size(0, 20);
            this.txtCoordinate.TabIndex  = 3;
            this.txtCoordinate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize          = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.txtCoordinate);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.drawBox);
            this.Icon          =  ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip =  this.menuStrip;
            this.MinimumSize   =  new System.Drawing.Size(900, 600);
            this.Name          =  "GlobalForm";
            this.StartPosition =  System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          =  "Drawing";
            this.KeyDown       += new System.Windows.Forms.KeyEventHandler(this.GlobalForm_KeyDown);
            this.drawBox.ResumeLayout(false);
            this.drawBox.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GlTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label             txtCoordinate;
        private System.Windows.Forms.ToolStripTextBox  txtText;
        private System.Windows.Forms.ToolStripComboBox cmbFont;
        private System.Windows.Forms.ToolStripButton   butText;
        private System.Windows.Forms.ToolStripButton   butCircle;
        private System.Windows.Forms.ToolStripButton   butSquare;
        private System.Windows.Forms.ToolStripComboBox cmbFillColors_2;
        private System.Windows.Forms.ToolStripComboBox cmbTypeFill;
        private System.Windows.Forms.ToolStripComboBox cmbFillColors_1;
        private System.Timers.Timer                    GlTime;
        private System.Windows.Forms.Label             txtInfo;
        private System.Windows.Forms.ToolStripTextBox  txtThickness;
        private System.Windows.Forms.ToolStripComboBox cmbColors;
        private System.Windows.Forms.ToolStripButton   butEllipse;

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.MenuStrip         menuStrip;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

        private System.Windows.Forms.ToolStripButton butLine;
        private System.Windows.Forms.ToolStripButton butRemoveEl;
        private System.Windows.Forms.ToolStripButton butSelect;
        private System.Windows.Forms.ToolStrip       toolStrip;

        private System.Windows.Forms.Panel drawBox;

        #endregion

        private System.Windows.Forms.ToolStripButton butRectangle;
    }
}