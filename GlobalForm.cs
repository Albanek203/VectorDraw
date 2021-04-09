using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Timers;

namespace WinFormVectorDraw {
    public partial class GlobalForm: Form {
        private          Point                 _startPoint;
        private          Point                 _curPoint;
        private readonly List<MyShape>         _data = new List<MyShape>();
        private readonly List<ToolStripButton> _buts;
        private readonly List<Color>           _colors;
        private readonly List<string>          _fonts = new List<string>();
        private          bool                  _isDrawing;
        private          EditMode              _editMode;
        private          int                   _nSelected = -1;
        public GlobalForm() {
            InitializeComponent();
            _editMode           = EditMode.Select;
            butRemoveEl.Enabled = false;
            _buts = new List<ToolStripButton>() {
                butSelect
              , butLine
              , butSquare
              , butRectangle
              , butCircle
              , butEllipse
              , butText
            };
            _colors = new List<Color>() {
                Color.Black
              , Color.Red
              , Color.Orange
              , Color.Yellow
              , Color.Green
              , Color.LightBlue
              , Color.Blue
              , Color.Violet
              , Color.Purple
              , Color.Pink
            };
            foreach (var item in _colors) {
                cmbColors.Items.Add(item.Name);
                cmbFillColors_1.Items.Add(item.Name);
                cmbFillColors_2.Items.Add(item.Name);
            }
            for (var i = 0; i < 10; i++) {
                _fonts.Add(FontFamily.Families[i].Name);
                cmbFont.Items.Add(FontFamily.Families[i].Name);
            }
            cmbTypeFill.Items.Add("None");
            cmbTypeFill.Items.Add("Solid color");
            cmbTypeFill.Items.Add("Hatch pattern");
            cmbTypeFill.Items.Add("Image texture");
            cmbTypeFill.Items.Add("Color gradient");
            cmbColors.SelectedIndex = 0;
        }
        private void drawBox_MouseUp(object sender, MouseEventArgs e) {
            if (!_isDrawing) return;
            _curPoint = e.Location;
            int.TryParse(txtThickness.Text, out var thickness);
            if (thickness <= 0) {
                ErrorMessage("Size must be bigger then 0", "Error size");
                txtThickness.Text = @"1";
                _isDrawing        = false;
                drawBox.Refresh();
                return;
            }
            switch (_editMode) {
                case EditMode.AddLine:
                    _data.Add(new MyLine() {
                        StartPoint = _startPoint
                      , EndPoint   = _curPoint
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Thickness  = thickness
                      , TypeShape  = "Line"
                    }); break;
                case EditMode.AddRectangle:
                    _data.Add(new MyRectange() {
                        StartPoint = _startPoint
                      , Width      = _curPoint.X - _startPoint.X
                      , Height     = _curPoint.Y - _startPoint.Y
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Thickness  = thickness
                      , TypeShape  = "Rectangle"
                    }); break;
                case EditMode.AddEllipse:
                    _data.Add(new MyEllipse() {
                        StartPoint = _startPoint
                      , Width      = _curPoint.X - _startPoint.X
                      , Height     = _curPoint.Y - _startPoint.Y
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Thickness  = thickness
                      , TypeShape  = "Ellipse"
                    });
                    break;
                case EditMode.AddCircle:
                    _data.Add(new MyEllipse {
                        TypeShape  = "Circle"
                      , StartPoint = _startPoint
                      , Width      = _curPoint.X - _startPoint.X
                      , Height     = _curPoint.X - _startPoint.X
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Thickness  = thickness
                    }); break;
                case EditMode.AddSquare:
                    _data.Add(new MyRectange() {
                        TypeShape  = "Square"
                      , StartPoint = _startPoint
                      , Width      = _curPoint.X - _startPoint.X
                      , Height     = _curPoint.X - _startPoint.X
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Thickness  = thickness
                    }); break;
                case EditMode.AddText:
                    _data.Add(new MyText {
                        TypeShape  = "Text"
                      , StartPoint = _startPoint
                      , ShapeColor = _colors[cmbColors.SelectedIndex]
                      , Font       = new Font(_fonts[cmbFont.SelectedIndex], thickness)
                      , Thickness  = thickness
                      , Text       = txtText.Text
                    }); break;
            }
            _isDrawing = false;
            drawBox.Refresh();
        }
        private void drawBox_MouseDown(object sender, MouseEventArgs e) {
            if (cmbColors.SelectedIndex < 0) { ErrorMessage(@"Choose color!", @"Error color"); return; }
            _isDrawing  = _editMode != EditMode.Select;
            _startPoint = e.Location;
        }
        private void drawBox_MouseMove(object sender, MouseEventArgs e) {
            txtCoordinate.Text = $@"{MousePosition.X};{MousePosition.Y}";
            if (!_isDrawing || (_curPoint == e.Location)) return;
            _curPoint = e.Location;
            drawBox.Refresh();
        }
        private void drawBox_Paint(object sender, PaintEventArgs e) {
            foreach (var item in _data) { item.Draw(e.Graphics); }
            using (var grayPen = new Pen(Color.Gray)) {
                switch (_isDrawing) {
                    case true when EditMode.AddLine == _editMode:
                        e.Graphics.DrawLine(grayPen, _startPoint, _curPoint); break;
                    case true when EditMode.AddRectangle == _editMode:
                        e.Graphics.DrawRectangle(grayPen, _startPoint.X, _startPoint.Y, _curPoint.X - _startPoint.X, _curPoint.Y - _startPoint.Y); break;
                    case true when EditMode.AddEllipse == _editMode:
                        e.Graphics.DrawEllipse(grayPen, _startPoint.X, _startPoint.Y, _curPoint.X - _startPoint.X, _curPoint.Y - _startPoint.Y); break;
                    case true when EditMode.AddCircle == _editMode:
                        e.Graphics.DrawEllipse(grayPen, _startPoint.X, _startPoint.Y, _curPoint.X - _startPoint.X, _curPoint.X - _startPoint.X); break;
                    case true when EditMode.AddSquare == _editMode:
                        e.Graphics.DrawRectangle(grayPen, _startPoint.X, _startPoint.Y, _curPoint.X - _startPoint.X, _curPoint.X - _startPoint.X); break;
                }
            }
        }
        private void drawBox_MouseClick(object sender, MouseEventArgs e) {
            if (_editMode != EditMode.Select) return;
            _nSelected = -1;
            for (var i = 0; i < _data.Count; i++) {
                if (!_data[i].Contains(_startPoint)) continue;
                if (_data[i].TypeShape == "Text") {
                    txtText.Visible = true;
                    cmbFont.Visible = true;
                }
                txtInfo.Visible = true;
                txtInfo.Text    = @"Selected " + _data[i].TypeShape;
                _nSelected      = i;
            }
            if (_nSelected < 0 || _nSelected >= _data.Count) return;
            butRemoveEl.Enabled = true;
            drawBox.Refresh();
        }
        private void ChangeChacked(int index) {
            for (var i = 0; i < _buts.Count; i++) { _buts[i].Checked = index == i; }
            if (index != 6) txtThickness.Text = @"1";
            txtText.Visible     = false;
            cmbFont.Visible     = false;
            butRemoveEl.Enabled = false;
            _nSelected          = -1;
        }
        private void butSelect_Click(object sender, EventArgs e) {
            ChangeChacked(0);
            _editMode = EditMode.Select;
        }
        private void butLine_Click(object sender, EventArgs e) {
            ChangeChacked(1);
            _editMode  = EditMode.AddLine;
            drawBox.Refresh();
        }
        private void butSquare_Click(object sender, EventArgs e) {
            ChangeChacked(2);
            _editMode = EditMode.AddSquare;
            drawBox.Refresh();
        }
        private void butRectangle_Click(object sender, EventArgs e) {
            ChangeChacked(3);
            _editMode = EditMode.AddRectangle;
            drawBox.Refresh();
        }
        private void butCircle_Click(object sender, EventArgs e) {
            ChangeChacked(4);
            _editMode = EditMode.AddCircle;
            drawBox.Refresh();
        }
        private void butEllipse_Click(object sender, EventArgs e) {
            ChangeChacked(5);
            _editMode = EditMode.AddEllipse;
            drawBox.Refresh();
        }
        private void butText_Click(object sender, EventArgs e) {
            ChangeChacked(6);
            cmbFont.SelectedIndex = 0;
            txtThickness.Text     = @"20";
            txtText.Visible       = true;
            cmbFont.Visible       = true;
            _editMode             = EditMode.AddText;
            drawBox.Refresh();
        }
        private void butDelLine_Click(object sender, EventArgs e) {
            if (_nSelected == -1) return;
            _data.RemoveAt(_nSelected);
            txtInfo.Visible     = true;
            txtInfo.Text        = txtInfo.Text.Split(' ')[1] + @" deleted";
            butRemoveEl.Enabled = false;
            _nSelected          = -1;
            drawBox.Refresh();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            var filePath = saveFileDialog.FileName.Split('.')[0];
            using (XmlTextWriter textWriter = new XmlTextWriter(filePath + ".xml", null)) {
                var PI = "type='text/xsl' href='Figures.xsl'";
                textWriter.Formatting = Formatting.Indented;
                textWriter.WriteStartDocument();
                textWriter.WriteProcessingInstruction("xml-stylesheet", PI);
                textWriter.WriteStartElement("Root", "");
                foreach (var item in _data) item.Save(textWriter);
                textWriter.WriteEndElement();
                textWriter.WriteEndDocument();
            }
            txtInfo.Visible = true;
            txtInfo.Text    = @"Success Save";
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;            
            _data.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(openFileDialog.FileName);
            if (xmlDocument.DocumentElement != null)
                foreach (XmlNode item in xmlDocument.DocumentElement) {
                    if (item.Name == "Line") { new MyLine().Load(item, _data); } 
                    else if (item.Name == "Rectangle" || item.Name == "Square") { new MyRectange().Load(item, _data); } 
                    else if (item.Name == "Ellipse" || item.Name == "Circle") { new MyEllipse().Load(item, _data); } 
                    else if (item.Name == "Text") { new MyText().Load(item, _data); }
                }
            drawBox.Refresh();
            txtInfo.Visible = true;
            txtInfo.Text    = @"Success Load";
        }
        private void timer1_Elapsed(object sender, ElapsedEventArgs e) {
            if (butRemoveEl.Enabled) return;
            txtInfo.Visible = false;
        }
        private void cmbColors_DropDownClosed(object sender, EventArgs e) {
            if (_nSelected < 0) return;
            _data[_nSelected].ShapeColor = Color.FromName(_colors[cmbColors.SelectedIndex].Name);
            drawBox.Refresh();
        }
        private void txtThickness_TextChanged(object sender, EventArgs e) {
            if (_nSelected < 0) return;
            int.TryParse(txtThickness.Text, out var thickness);
            if (thickness <= 0) {
                ErrorMessage("Size must be bigger then 0", "Error size");
                txtThickness.Text = @"1";
                return;
            }
            _data[_nSelected].Thickness = thickness;
            drawBox.Refresh();
        }
        private void txtText_TextChanged(object sender, EventArgs e) {
            if (_nSelected < 0) return;
            var obj = (MyFilledShape) _data[_nSelected];
            obj.Text          = txtText.Text;
            _data[_nSelected] = obj;
            drawBox.Refresh();
        }
        private void cmbFillColors_1_DropDownClosed(object sender, EventArgs e) {
            if (_nSelected < 0 || _data[_nSelected].TypeShape == "Line" || cmbFillColors_1.SelectedIndex < 0) return;
            var obj = (MyFilledShape) _data[_nSelected];
            if (obj.TypeShape == "Text") obj.ShapeColor = _colors[cmbFillColors_1.SelectedIndex];
            obj.FirstColor    = _colors[cmbFillColors_1.SelectedIndex];
            _data[_nSelected] = obj;
            drawBox.Refresh();
        }
        private void cmbFillColors_2_DropDownClosed(object sender, EventArgs e) {
            if (_nSelected < 0 || _data[_nSelected].TypeShape == "Line") return;
            var obj = (MyFilledShape) _data[_nSelected];
            obj.SecondColor   = _colors[cmbFillColors_2.SelectedIndex];
            _data[_nSelected] = obj;
            drawBox.Refresh();
        }
        private void cmbFont_DropDownClosed(object sender, EventArgs e) {
            if (_nSelected < 0) return;
            var obj = (MyFilledShape) _data[_nSelected];
            int.TryParse(txtThickness.Text, out var thickness);
            obj.Font          = new Font(_fonts[cmbFont.SelectedIndex], thickness);
            _data[_nSelected] = obj;
            drawBox.Refresh();
        }
        private void cmbTypeFill_DropDownClosed(object sender, EventArgs e) {
            if (_nSelected < 0 || _data[_nSelected].TypeShape == "Line" || cmbFillColors_1.SelectedIndex < 0) return;
            var obj = (MyFilledShape) _data[_nSelected];
            cmbFillColors_2.Visible = false;
            switch (cmbTypeFill.SelectedIndex) {
                case 0:
                    cmbFillColors_1.SelectedIndex = -1;
                    cmbFillColors_1.Text          = @"Color Fill"; break;
                case 3:
                    openFileDialog.ShowDialog();
                    obj.ImagePath = openFileDialog.FileName; break;
                case 4:
                    cmbFillColors_2.Visible       = true;
                    cmbFillColors_2.SelectedIndex = cmbFillColors_1.SelectedIndex;
                    obj.SecondColor               = _colors[cmbFillColors_1.SelectedIndex]; break;
            }
            obj.TypeFill      = cmbTypeFill.SelectedIndex;
            _data[_nSelected] = obj;
            drawBox.Refresh();
        }
        private void cmbTypeFill_Click(object sender, EventArgs e) {
            if (cmbFillColors_1.SelectedIndex < 0) ErrorMessage(@"Choose color!", @"Error color");
        }
        private void cmbFillColors_Click(object sender, EventArgs e) {
            if (_nSelected < 0) { ErrorMessage(@"Select item!", @"Error select"); return; }
            if (_data[_nSelected].TypeShape == "Line") ErrorMessage(@"Line dont have solid", @"Error Line");
        }
        private static void ErrorMessage(string txt, string cap) {
            MessageBox.Show(txt, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void GlobalForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.S || !e.Control) return;
            saveToolStripMenuItem_Click(sender, e);
            txtInfo.Visible = true;
            txtInfo.Text    = @"Success Save";
        }
    }
}