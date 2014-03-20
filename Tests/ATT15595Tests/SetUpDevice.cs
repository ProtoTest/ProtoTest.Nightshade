using Gallio.Framework;
using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Set Up Device Scripts")]
    [Category("Setup")]
    
    public class SetUpDevice : EggplantTestBase
    {
        [CsvData(FilePath = ".\\Tests\\Data.csv", HasHeader = true)]
        [Test]
        public void TestCSV(string handle, string first, string last, string company, string phone1, string phone2, string phone3, string email1, string email2, string email3, string im1, string im2, string im3)
        {
            ConnectToHost1();
            Command.NavigateTheMenu().GoToContactsApp().AddAllContactsFromSetupFile();
            
            
            //DiagnosticLog.WriteLine(handle + " " + first + " " + last + " " + phone1);
        }
    }
}
