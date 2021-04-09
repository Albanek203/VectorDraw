using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
namespace WinFormVectorDraw {
    public class MyLine: MyShape {
        public override void Draw(Graphics gr) {
            using (var blackPen = new Pen(ShapeColor, Thickness)) { gr.DrawLine(blackPen, StartPoint, EndPoint); }
        }
        public override bool Contains(Point point) {
            var distant =
                Math.Abs((StartPoint.Y - EndPoint.Y) * point.X + (EndPoint.X - StartPoint.X) * point.Y +
                         StartPoint.X * EndPoint.Y - EndPoint.X * StartPoint.Y) / Math.Sqrt(
                    Math.Pow(StartPoint.Y - EndPoint.Y, 2) + Math.Pow(EndPoint.X - StartPoint.X, 2));
            return distant <= 2;
        }
        public override void Save(XmlTextWriter textWriter) {
            textWriter.WriteStartElement(TypeShape, "");
            textWriter.WriteElementString("StartPoint", $"{StartPoint.X};{StartPoint.Y}");
            textWriter.WriteElementString("EndPoint", $"{EndPoint.X};{EndPoint.Y}");
            textWriter.WriteElementString("Color", $"{ShapeColor.Name}");
            textWriter.WriteElementString("Thickness ", $"{Thickness}");
            textWriter.WriteEndElement();
        }
        public override void Load(XmlNode item, List<MyShape> data) {
            var xmlNodeList = item.ChildNodes;
            var pts1 = xmlNodeList[0].InnerText.Split(';');
            var pts2 = xmlNodeList[1].InnerText.Split(';');
            data.Add(new MyLine {
                TypeShape  = "Line"
              , StartPoint = new Point(int.Parse(pts1[0]), int.Parse(pts1[1]))
              , EndPoint   = new Point(int.Parse(pts2[0]), int.Parse(pts2[1]))
              , ShapeColor = Color.FromName(xmlNodeList[2].InnerText)
              , Thickness  = int.Parse(xmlNodeList[3].InnerText)
            });
        }
    }
}