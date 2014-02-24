using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProtoTest.Nightshade.PageObjects
{
    public class PageObjectExample
    {
        public EggplantElement firsTElement = new EggplantElement("path/to/element");
        public EggplantElement secondElement = new EggplantElement("(Text:\"Text Of Element\")");

        public PageObjectExample DoSomething()
        {
            firsTElement.Click();
            secondElement.Click();
            return this;
        }
    }
}
