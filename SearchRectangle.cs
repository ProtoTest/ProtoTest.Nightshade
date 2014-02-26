using System.Drawing;

namespace ProtoTest.Nightshade
{
    public class SearchRectangle
    {
        public Rectangle? searchRectangle = null;
        public Point upperLeft;
        public Point lowerRight;
        public int width;
        public int height;

        public SearchRectangle(Rectangle rectangle)
        {
            this.searchRectangle = rectangle;
            this.upperLeft = rectangle.Location;
            this.width = upperLeft.X - lowerRight.X;
            this.height = upperLeft.Y - lowerRight.Y;
            this.lowerRight = new Point(upperLeft.X+width,upperLeft.Y+height);
        }

        public SearchRectangle(Point upperLeft, Point lowerRight)
        {
            this.width = upperLeft.X - lowerRight.X;
            this.height = upperLeft.Y - lowerRight.Y;
            this.searchRectangle = new Rectangle(upperLeft,new Size(width, height));
            this.lowerRight = new Point(upperLeft.X + width, upperLeft.Y + height);
            this.searchRectangle = new Rectangle(upperLeft,new Size(width,height));
        }

        
    }
}
