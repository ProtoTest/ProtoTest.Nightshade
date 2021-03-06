﻿using System;
using System.Drawing;
using ProtoTest.TestRunner.Nightshade;

namespace ProtoTest.Nightshade
{
    /// <summary>
    /// Builds rectangles to narrow the search area.
    /// Includes some predefined SearchRectangles, or can be built using points
    /// SearchRectangle.FullScreen, SearchRectangle.TopHalf, etc.
    /// </summary>
    public class SearchRectangle
    {
        public Rectangle? searchRectangle = null;
        public Point upperLeft;
        public Point lowerRight;
        public int width;
        public int height;
        private static SearchRectangle _fullScreen;
        public static string xPoint;
        public static string yPoint;

        public static SearchRectangle FullScreen 
        {
            get { return _fullScreen ?? (_fullScreen = EggplantTestBase.Driver.GetScreenRectangle()); }
            set { _fullScreen = value; }
        }

        public static void FullScreenPercentagesToPoints(int xPercent, int yPercent)
        {
            var xPointInt = (FullScreen.width) - (FullScreen.width* ((100 - xPercent) / 100));
            var yPointInt = (FullScreen.height) - (FullScreen.height * ((100 - yPercent) / 100));
            xPoint = xPointInt.ToString();
            yPoint = yPointInt.ToString();
        }
        
        public static SearchRectangle TopHalf
        {
            get { return new SearchRectangle(new Point(0,0),new Point(FullScreen.width,FullScreen.height/2)); }
        }

        public static SearchRectangle BottomHalf
        {
            get { return new SearchRectangle(new Point(0, FullScreen.height/2), new Point(FullScreen.width, FullScreen.height)); }
        }

        public static SearchRectangle MiddleHalf
        {
            get
            {
                var value = (int) Math.Floor(FullScreen.height*.25);
                return new SearchRectangle(new Point(0, value), new Point(FullScreen.width, (int)Math.Floor(FullScreen.height * .75))); 
            }
        }

        public static SearchRectangle TopQuarter
        {
            get { return new SearchRectangle(new Point(0, 0), new Point(FullScreen.width, FullScreen.height / 4)); }
        }

        public static SearchRectangle BottomQuarter
        {
            get
            {
                int value = (int) Math.Floor(FullScreen.height*.75);
                return new SearchRectangle(new Point(0, value), new Point(FullScreen.width, FullScreen.height));
            }
        }

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
            this.upperLeft = upperLeft;
            this.lowerRight = lowerRight;
            this.width = Math.Abs(upperLeft.X - lowerRight.X);
            this.height = Math.Abs(upperLeft.Y - lowerRight.Y);
            this.searchRectangle = new Rectangle(upperLeft, new Size(width, height));
        }
        
    }
}
