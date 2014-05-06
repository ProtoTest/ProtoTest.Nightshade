using MbUnit.Framework;
using ProtoTest.Golem.Core;
using ProtoTest.Golem.WebDriver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using GolemWebScripts.PageObjects;

namespace GolemWebScripts.Scripts
{
    public class AddOutlookContacts : WebDriverTestBase
    {
        //Microsoft Live Connect Developer Center - App Settings (Nightshade)
        string clientId = "00000000481175C9";
        string authUrl = "https://login.live.com/oauth20_authorize.srf?client_id={0}&scope=wl.signin%20wl.basic%20wl.contacts_create&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf";

        //Account to modify
        string userEmail = Config.GetConfigValue("HotmailEmail", "APPCONFIG_ERROR");
        string userPassword = Config.GetConfigValue("HotmailPassword", "");


        //RESTful commands
        //Run DeleteAllHotmailContacts.cs first
        [Test]
        public void AddAllOutlookContacts()
        {
            var url = string.Format(authUrl, clientId);
            var loginPage = OpenPage<LoginPage>(url);
            var token = loginPage.login(userEmail, userPassword).Accept();
            var client = new RestClient("https://apis.live.net");
            var requestUrl = string.Format("/v5.0/me/contacts?access_token={0}", token);

            int iterationsStart = int.Parse(Config.GetConfigValue("FirstContactNum", "APPCONFIG_ERROR"));
            int iterationsMax = int.Parse(Config.GetConfigValue("LastContactNum", "APPCONFIG_ERROR"));
            for (int i = iterationsStart; i < iterationsMax + 1; i++)
            {
                string firstN;
                if (i < 10)
                {
                    firstN = Config.GetConfigValue("ContactTemplate_FirstName", "APPCONFIG_ERROR") + "0" + i;
                }
                else
                {
                    firstN = Config.GetConfigValue("ContactTemplate_FirstName", "APPCONFIG_ERROR") + i;
                }
                var firstName = firstN;
                string company = Config.GetConfigValue("ContactMasterCompany", "APPCONFIG_ERROR");
                string email = Config.GetConfigValue("ContactMasterEmail", "APPCONFIG_ERROR");
                string phoneMobile = Config.GetConfigValue("ContactMasterPhone", "APPCONFIG_ERROR");

                //Common.Log("LOADING CONTACT INFO...");
                //Common.Log("Contact First Name: (" + firstName + ").");
                //Common.Log("Contact Company: (" + company + ").");
                //Common.Log("Contact Email: (" + email + ").");
                //Common.Log("Contact Phone: (" + phoneMobile + ").");

                var request = new RestRequest(requestUrl, Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddBody(new
                    {
                        first_name = firstName,
                        work = new [] { new { employer = new { name = company } } },
                        emails = new { personal = email },
                        phones = new { mobile = phoneMobile }
                    });

                var response = client.Execute(request);

                Common.Log(response.Content);
            }
        }
    }
}
