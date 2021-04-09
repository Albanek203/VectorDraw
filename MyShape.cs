using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace WinFormVectorDraw {
    public abstract class MyShape {
        public string TypeShape { set; get; }
        public Point StartPoint { set; get; }
        public Point EndPoint { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public Color ShapeColor { set; get; }
        public int Thickness { set; get; }
        public abstract void Draw(Graphics gr);
        public abstract bool Contains(Point pt);
        public abstract void Save(XmlTextWriter textWriter);
        public abstract void Load(XmlNode item, List<MyShape> data);
    }
}
