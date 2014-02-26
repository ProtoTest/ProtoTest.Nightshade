namespace ProtoTest.Nightshade.PageObjects
{
    public class PageObjectExample
    {
        public EggplantElement firsTElement = new EggplantElement(By.Image("path/to/element"));
        public EggplantElement secondElement = new EggplantElement(By.Text("Text Of Element"));

        public PageObjectExample DoSomething()
        {
            firsTElement.Click();
            secondElement.Click();
            return this;
        }
    }
}