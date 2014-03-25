﻿using System.Drawing;
using MbUnit.Framework;
using Gallio.Runtime.Loader;

namespace ProtoTest.Nightshade
{
    public class By : EggplantTestBase
    {
        private string locator;
        private static string _path;
        public string Path { get { return _path; } }

        public By(string locator)
        {
            this.locator = locator;
        }

        public override string ToString()
        {
            return locator;
        }

        public By InRectangle(SearchRectangle rectangle)
        {
            this.locator = this.locator.TrimEnd(')');
            locator += string.Format(", SearchRectangle: (({0},{1}),({2},{3})))",rectangle.upperLeft.X,rectangle.upperLeft.Y,rectangle.lowerRight.X,rectangle.lowerRight.Y);
            return this;
        }

        public By BetweenImages(EggplantElement topLeft, EggplantElement bottomRight)
        {
            this.locator = this.locator.TrimEnd(')');
            this.locator += string.Format(", SearchRectangle: ((\"{0}\"),(\"{1}\")))",topLeft.locator,bottomRight.locator);
            return this;
        }

        public static By Image(string path, string options=null)
        {
            _path = path;
            string endstring = string.Format("(image: \"{0}\"", path);
            if (options != null)
            {
                foreach (var option in options)
                {
                    endstring += string.Format(",{0}", option);
                }
            
            }
            endstring += ")";
            return new By(endstring);
        }

        public static By TextAtLocation(string path)
        {
            _path = path;
            string endstring = EggplantTestBase.Driver.ReadText(path);
            if(endstring != null)
            {
                EggplantTestBase.Log("Text read at target location: (" + endstring + ").");
            }
            else
            {
                EggplantTestBase.Log("No text present at target location.");
                Assert.Fail();
            }
            return new By(endstring);
        }

        public static By Text(string text, string[] options=null)
        {
            string endstring = string.Format("(text: \"{0}\"", text);
            if (options != null)
            {
                foreach (var option in options)
                {
                    endstring += string.Format(",{0}", option);
                }
                
            }
            endstring += ")";
            return new By(endstring);
        }

        public static By Text(string text, Point topLeft, Point bottomRight)
        {
            string endstring = string.Format("(text: \"{0}\"", text);
            endstring += string.Format(", SearchRectangle:(({0},{1}),({2},{3})))", topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
            return new By(endstring);
        }

    }
}