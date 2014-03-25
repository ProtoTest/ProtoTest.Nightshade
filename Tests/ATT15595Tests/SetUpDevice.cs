using Gallio.Framework;
using MbUnit.Framework;

namespace ProtoTest.Nightshade.Tests.ATT15595Tests
{
    [Description("ATT 15595 Suite - Set Up Device Scripts")]
    [Category("Setup All")]
    
    public class SetUpDevice : EggplantTestBase
    {
        [CsvData(FilePath = ".\\Setup Files\\Contacts.csv", HasHeader = true)]
        [Test]
        [Description("Iteratively adds contacts from CSV file to device")]
        [Category("Setup Contacts")]
        public void AddContacts(string handle, string first, string last, string company, string phone1, string phone2, string phone3, string email1, string email2, string email3, string im1, string im2, string im3)
        {
            ConnectToHost1();
            Command.NavigateTheMenu()
                .GoToContactsApp()
                .AddContact(handle, first, last, company, phone1, phone2, phone3, email1, email2, email3, im1, im2, im3)
                .ExitApp();

        }


    }
}
