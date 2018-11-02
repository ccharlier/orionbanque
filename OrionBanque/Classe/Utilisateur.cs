using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Utilisateur", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Utilisateur
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Login { get; set; }
        [DataMember()]
        public string Mdp { get; set; }

        public static void Delete(Utilisateur u)
        {
            Delete(u.Id);
        }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Utilisateur.Delete(" + id + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                ob.Utilisateurs.RemoveAll((u) => u.Id == id);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Utilisateur.Delete");
        }

        public static Classe.Utilisateur Charge(int id)
        {
            Log.Logger.Debug("Debut Utilisateur.Charge(" + id + ")");
            Classe.Utilisateur retour = new Classe.Utilisateur();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                retour = ob.Utilisateurs.Find((u) => u.Id == id);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static Classe.Utilisateur Charge(string login)
        {
            Log.Logger.Debug("Debut Utilisateur.Charge(" + login + ")");
            Classe.Utilisateur retour = new Classe.Utilisateur();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                retour = ob.Utilisateurs.Find((u) => u.Login == login);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static Classe.Utilisateur Maj(Classe.Utilisateur uA)
        {
            Log.Logger.Debug("Debut Utilisateur.Maj(" + uA.Id + ")");
            Classe.Utilisateur retour = new Classe.Utilisateur();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                Classe.Utilisateur u = ob.Utilisateurs.Find((utemp) => utemp.Id == uA.Id);
                u.Login = uA.Login;
                u.Mdp = uA.Mdp;

                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return retour;
        }

        public static Classe.Utilisateur Sauve(Classe.Utilisateur uA)
        {
            Log.Logger.Debug("Debut Utilisateur.Sauve(" + uA.Login + ")");
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                uA.Id = ob.Utilisateurs.Count != 0 ? ob.Utilisateurs.Max(u => u.Id) + 1 : 1;
                ob.Utilisateurs.Add(uA);
                CallContext.SetData(Classe.KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return uA;
        }

        public static List<Classe.Utilisateur> ChargeTout()
        {
            Log.Logger.Debug("Debut Utilisateur.ChargeTous()");
            List<Classe.Utilisateur> lu = new List<Classe.Utilisateur>();
            try
            {
                Classe.OB ob = (Classe.OB)CallContext.GetData(Classe.KEY.OB);
                lu = ob.Utilisateurs;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lu;
        }
    }
}
