using System.Drawing;
using MbUnit.Framework;
using Gallio.Runtime.Loader;

namespace ProtoTest.Nightshade
{
    /// <summary>
    /// By class contains knowledge about how to build a locator for EggPlant. 
    /// Eggplant supports a number of different ways to identify elements.
    /// Example (image: 'path.to.image') (text: 'Text to find')
    /// Can add optional params such as SearchRectangle.
    /// By.Image("path/to/image").InRectangle(SearchRectangle.TopQuarter)
    /// </summary>
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

        /// <summary>
        /// Adjusts a locator to include a SearchRectangle.
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public By InRectangle(SearchRectangle rectangle)
        {
            this.locator = this.locator.TrimEnd(')');
            locator += string.Format(", SearchRectangle: (({0},{1}),({2},{3})))",rectangle.upperLeft.X,rectangle.upperLeft.Y,rectangle.lowerRight.X,rectangle.lowerRight.Y);
            return this;
        }

        /// <summary>
        /// Adjusts a locator to look between two images
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="bottomRight"></param>
        /// <returns></returns>
        public By BetweenImages(EggplantElement topLeft, EggplantElement bottomRight)
        {
            this.locator = this.locator.TrimEnd(')');
            this.locator += string.Format(", SearchRectangle: ((\"{0}\"),(\"{1}\")))",topLeft.locator,bottomRight.locator);
            return this;
        }

        /// <summary>
        /// Looks for an image using the path found.  A list of optional params can be included
        /// </summary>
        /// Example: By.Image("path/to/image")
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static By Image(string path, string[] options=null)
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

        /// <summary>
        /// Look for an element based upon its text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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

    }
}