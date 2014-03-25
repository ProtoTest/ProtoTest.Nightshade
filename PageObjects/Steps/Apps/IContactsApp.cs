

namespace ProtoTest.Nightshade.PageObjects.Steps.Apps
{
    public interface IContactsApp
    {
        IContactsApp VerifyElements();
        IContactsApp AddContact(string handle, string first, string last, string company, string phone1, string phone2, string phone3, string email1, string email2, string email3, string im1, string im2, string im3);
        IContactsApp DeleteContact(string handle, string first);
        IContactsApp DeleteSpecifiedContacts(string contactHandle, string contactFirst);
        IContactsApp RestoreDelectedContacts(string handle, string first, string last, string company, string phone1, string phone2, string phone3, string email1, string email2, string email3, string im1, string im2, string im3);
        IContactsApp DeleteAllContacts();
        IContactsApp ExitApp();

    }
}
