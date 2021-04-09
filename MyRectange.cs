using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
namespace WinFormVectorDraw {
    public class MyRectange: MyFilledShape {
            public override void Draw(Graphics gr) {
                if (TypeFill == 0)
                    using (var blackPen = new Pen(ShapeColor, Thickness)) {
                        gr.DrawRectangle(blackPen, StartPoint.X, StartPoint.Y, Width, Height); }
                else if (TypeFill == 1)
                    using (var solidBrush = new SolidBrush(FirstColor)) {
                        gr.FillRectangle(solidBrush, StartPoint.X, StartPoint.Y, Width, Height); }
                else if (TypeFill == 2)
                    using (var hatchBrush = new HatchBrush(HatchStyle.Cross, FirstColor)) {
                        gr.FillRectangle(hatchBrush, StartPoint.X, StartPoint.Y, Width, Height); }
                else if (TypeFill == 3)
                    using (var textureBrush = new TextureBrush(new Bitmap(ImagePath))) {
                        gr.FillRectangle(textureBrush, StartPoint.X, StartPoint.Y, Width, Height); }
                else if (TypeFill == 4)
                    using (var linearGradientBrush = new LinearGradientBrush(
                        StartPoint, new Point(StartPoint.X + Width, StartPoint.Y + Height), FirstColor, SecondColor)) {
                        gr.FillRectangle(linearGradientBrush, StartPoint.X, StartPoint.Y, Width, Height); }
            }
            public override bool Contains(Point point) {
                return point.X >= StartPoint.X && point.X <= StartPoint.X + Width && point.Y >= StartPoint.Y &&
                       point.Y <= StartPoint.Y + Height;
            }
            public override void Save(XmlTextWriter textWriter) {
                textWriter.WriteStartElement(TypeShape, "");
                textWriter.WriteElementString("StartPoint", $"{StartPoint.X};{StartPoint.Y}");
                textWriter.WriteElementString("Width", $"{Width}");
                textWriter.WriteElementString("Height", $"{Height}");
                textWriter.WriteElementString("Color", $"{ShapeColor.Name}");
                textWriter.WriteElementString("Thickness ", $"{Thickness}");
                textWriter.WriteElementString("TypeFill ", $"{TypeFill}");
                textWriter.WriteElementString("FirstColor", $"{FirstColor.Name}");
                textWriter.WriteElementString("SecondColor", $"{SecondColor.Name}");
                textWriter.WriteElementString("ImagePath", $"{ImagePath}");
                textWriter.WriteEndElement();
            }
            public override void Load(XmlNode item, List<MyShape> data) {
                var xmlNodeList = item.ChildNodes;
                var pts1 = xmlNodeList[0].InnerText.Split(';');
                data.Add(new MyRectange {
                    TypeShape   = "Rectangle"
                  , StartPoint  = new Point(int.Parse(pts1[0]), int.Parse(pts1[1]))
                  , Width       = int.Parse(xmlNodeList[1].InnerText)
                  , Height      = int.Parse(xmlNodeList[2].InnerText)
                  , ShapeColor  = Color.FromName(xmlNodeList[3].InnerText)
                  , Thickness   = int.Parse(xmlNodeList[4].InnerText)
                  , TypeFill    = int.Parse(xmlNodeList[5].InnerText)
                  , FirstColor  = Color.FromName(xmlNodeList[6].InnerText)
                  , SecondColor = Color.FromName(xmlNodeList[7].InnerText)
                  , ImagePath   = xmlNodeList[8].InnerText
                });
            }
        }
}