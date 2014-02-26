using CookComputing.XmlRpc;

namespace ProtoTest.TestRunner.Nightshade
{
    /// <summary>
    ///     This class executes service calls against Drive's XmlRpc service.  All logic for calling the service is included
    ///     automatically.
    ///     Because the URL of our service is an attribute, it is hard coded and not configurable via the config file.
    /// </summary>
    [XmlRpcUrl("http://127.0.0.1:5400")]
    public interface IEggplantDriveService : IXmlRpcProxy
    {
        [XmlRpcMethod("StartSession")]
        dynamic StartSession(string suitePath);

        [XmlRpcMethod("Execute")]
        XmlRpcStruct Execute(string command);

        [XmlRpcMethod("EndSession")]
        dynamic EndSession();
    }
}