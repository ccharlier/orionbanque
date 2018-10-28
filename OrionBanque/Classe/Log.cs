using log4net;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: log4net.Config.Repository()]

namespace OrionBanque.Classe
{
    public class Log
    {
        #region Data Members
        public static readonly ILog Logger = LogManager.GetLogger("OrionBanqueApplication"); 
        #endregion
    }
}