using System.IO;

namespace ProtoTest.Nightshade.PageObjects
{
    public class PageObjectExample
    {
        public EggplantElement firsTElement = new EggplantElement(By.Image("path/to/element"));
        public EggplantElement secondElement = new EggplantElement(By.Image("path/to/element"));

        public enum elementStates
        {
            Battery,
            Charging,
            NotCharging,
            LowBattery
        };

        public PageObjectExample DoSomething()
        {
            firsTElement.Click();
            secondElement.Click();
            return this;
        }
    }
}