using MbUnit.Framework;
using ProtoTest.Golem.WebDriver;
using GolemWebScripts.PageObjects;

namespace GolemWebScripts.Scripts
{
    public class DeleteAllHotmailContacts : WebDriverTestBase
    {
        [Test]
        public void DeleteHotmailAccountContacts()
        {
            HotmailPage.LaunchHotmail().LoginToHotmail().GoToPeopleMainPage().DeleteAllContacts().LogOut();
        }

        // REPLACED BY "AddOutlookContacts"
        //[Test]
        //public void AddContactsToHotmailAccount()
        //{
        //    HotmailPage.LaunchHotmail().LoginToHotmail().GoToPeopleMainPage().IterativelyAddContacts(1,50).LogOut();
        //}
    }
}
