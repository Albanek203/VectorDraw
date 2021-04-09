using System.Drawing;
namespace WinFormVectorDraw {
    public abstract class MyFilledShape: MyShape {
        public    int    TypeFill    { set; get; }
        public    string ImagePath   { set; get; }
        public    string Text        { set; get; }
        public    Color  FirstColor  { set; get; }
        public    Color  SecondColor { set; get; }
        public    Font   Font        { set; get; }
        protected SizeF  Size        { set; get; }
    }
}