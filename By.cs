using System.Drawing;

namespace ProtoTest.Nightshade
{
    public class By
    {
        
        private readonly string locator;

        public By(string locator)
        {
            this.locator = locator;
        }

        public override string ToString()
        {
            return locator;
        }

        public static By Image(string path)
        {
            return new By(path);
        }

        public static By Image(string path, Point topLeft, Point bottomRight)
        {
            string endstring = string.Format("(image: \"{0}\"", path);
            endstring += string.Format(", SearchRectangle:(({0},{1}),({2},{3})))",topLeft.X,topLeft.Y,bottomRight.X,bottomRight.Y);
            return new By(endstring);
        }

        public static By Image(string path, string options=null)
        {
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