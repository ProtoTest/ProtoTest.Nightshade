using MbUnit.Framework;
using ProtoTest.Golem.WebDriver;
using Setup_Files.Golem_Web_Scripts.PageObjects;

namespace Setup_Files.Golem_Web_Scripts.Scripts
{
    public class SetUpHotmailContacts : WebDriverTestBase
    {
        [Test]
        public void DeleteHotmailAccountContacts()
        {
            HotmailPage.LaunchHotmail().LoginToHotmail().GoToPeopleMainPage().DeleteAllContacts().LogOut();
        }

        [Test]
        public void AddContactsToHotmailAccount()
        {
            HotmailPage.LaunchHotmail().LoginToHotmail().GoToPeopleMainPage().IterativelyAddContacts(50,50).LogOut();
        }
    }
}
