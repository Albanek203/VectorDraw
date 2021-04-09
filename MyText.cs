using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
namespace WinFormVectorDraw {
    public class MyText: MyFilledShape {
            public override void Draw(Graphics gr) {
                Brush brush = new SolidBrush(ShapeColor);
                Font = new Font(Font.Name, Thickness);
                Size = gr.MeasureString(Text, Font);
                if (TypeFill == 2)
                    brush = new HatchBrush(HatchStyle.Cross, FirstColor);
                else if (TypeFill == 3)
                    brush = new TextureBrush(new Bitmap(ImagePath));
                else if (TypeFill == 4)
                    brush = new LinearGradientBrush(
                        StartPoint, new Point(StartPoint.X + (int) Size.Width, StartPoint.Y + (int) Size.Height)
                      , FirstColor, SecondColor);
                gr.DrawString(Text, Font, brush, StartPoint);
            }
            public override bool Contains(Point point) {
                return point.X >= StartPoint.X && point.X <= StartPoint.X + Size.Width && point.Y >= StartPoint.Y &&
                       point.Y <= StartPoint.Y + Size.Height;
            }
            public override void Save(XmlTextWriter textWriter) {
                textWriter.WriteStartElement(TypeShape, "");
                textWriter.WriteElementString("StartPoint", $"{StartPoint.X};{StartPoint.Y}");
                textWriter.WriteElementString("ShapeColor", $"{ShapeColor.Name}");
                textWriter.WriteElementString("Thickness ", $"{Thickness}");
                textWriter.WriteElementString("TypeFill", $"{TypeFill}");
                textWriter.WriteElementString("FirstColor", $"{FirstColor.Name}");
                textWriter.WriteElementString("SecondColor", $"{SecondColor.Name}");
                textWriter.WriteElementString("Text", $"{Text}");
                textWriter.WriteElementString("Font", $"{Font.Name}");
                textWriter.WriteElementString("ImagePath", $"{ImagePath}");
                textWriter.WriteEndElement();
            }
            public override void Load(XmlNode item, List<MyShape> data) {
                var xmlNodeList = item.ChildNodes;
                var pts1 = xmlNodeList[0].InnerText.Split(';');
                data.Add(new MyText {
                    TypeShape   = "Text"
                  , StartPoint  = new Point(int.Parse(pts1[0]), int.Parse(pts1[1]))
                  , ShapeColor  = Color.FromName(xmlNodeList[1].InnerText)
                  , Thickness   = int.Parse(xmlNodeList[2].InnerText)
                  , TypeFill    = int.Parse(xmlNodeList[3].InnerText)
                  , FirstColor  = Color.FromName(xmlNodeList[4].InnerText)
                  , SecondColor = Color.FromName(xmlNodeList[5].InnerText)
                  , Text        = xmlNodeList[6].InnerText
                  , Font        = new Font(xmlNodeList[7].Name, int.Parse(xmlNodeList[2].InnerText))
                  , ImagePath   = xmlNodeList[8].InnerText
                });
            }
        }
}