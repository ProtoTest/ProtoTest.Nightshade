

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IContactsApp
    {
        IContactsApp VerifyElements();
        IContactsApp AddContact(string first, string company, string phone1);
        IContactsApp DeleteContact(string first, string company, string phone1);
        IContactsApp AddContactsToDelete(int totalNum);
        IContactsApp DeleteAddedContacts();
        IContactsApp DeleteAllContacts();
        IContactsApp ExitApp();

    }
}
