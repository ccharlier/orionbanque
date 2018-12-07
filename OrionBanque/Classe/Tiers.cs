using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    public class Tiers
    {
        public static List<string> ChargeTout()
        {
            Log.Logger.Debug("Debut Tiers.ChargeTout()");
            List<string> lt = new List<string>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lt = ob.Tiers ?? new List<string>();
                lt.Sort();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lt;
        }
    }
}
