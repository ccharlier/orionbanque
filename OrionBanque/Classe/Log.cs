using System;
using System.Collections.Generic;
using System.Text;

using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
[assembly: log4net.Config.Repository()]

namespace OrionBanque.Classe
{
    class Log
    {
        #region Data Members
        public static readonly ILog Logger = LogManager.GetLogger("OrionBanqueApplication"); 
        #endregion

        public Log()
        { 
        }
    }
}
