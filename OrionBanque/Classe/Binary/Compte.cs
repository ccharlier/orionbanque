using System;
using System.Collections.Generic;
using System.Linq;

namespace OrionBanque.Classe.Binary
{
    public class Compte
    {
        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                ob.Comptes.RemoveAll((c) => c.Id == id);
                ob.Operations.RemoveAll((c) => c.Compte.Id == id);
                ob.Echeanciers.RemoveAll((c) => c.Compte.Id == id);
                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            Log.Logger.Debug("Fin Compte.Delete");
        }

        public static void Delete(Classe.Compte c)
        {
            Log.Logger.Debug("Debut Compte.Delete(Compte : id=" + c.Id + ")");
            Compte.Delete(c.Id);
            Log.Logger.Debug("Fin Compte.Delete()");
        }

        public static Classe.Compte Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Classe.Compte c = new Classe.Compte();
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                c = ob.Comptes.Where(ct => ct.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }

        public static List<Classe.Compte> ChargeTout()
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Classe.Compte> lc = new List<Classe.Compte>();
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                lc = ob.Comptes.OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Classe.Compte> ChargeTout(Classe.Utilisateur u)
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Classe.Compte> lc = new List<Classe.Compte>();
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                lc = ob.Comptes.Where(c => c.Utilisateur.Id == u.Id).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static Classe.Compte Maj(Classe.Compte cA)
        {
            Log.Logger.Debug("Debut Compte.Maj(" + cA.Id + ")");
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);

                Classe.Compte c = ob.Comptes.Find((ctemp) => ctemp.Id == cA.Id);
                c.Libelle = cA.Libelle;
                c.SoldeInitial = cA.SoldeInitial;
                c.Banque = cA.Banque;
                c.Guichet = cA.Guichet;
                c.NoCompte = cA.NoCompte;
                c.Clef = cA.Clef;
                c.MinGraphSold = cA.MinGraphSold;
                c.MaxGraphSold = cA.MaxGraphSold;
                c.SeuilAlerte = cA.SeuilAlerte;
                c.SeuilAlerteFinal = cA.SeuilAlerteFinal;
                c.TypEvol = cA.TypEvol;
                c.Utilisateur = cA.Utilisateur;

                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        static public Classe.Compte Sauve(Classe.Compte c)
        {
            Log.Logger.Debug("Debut Copmpte.Sauve(" + c.Libelle + ")");
            try
            {
                Classe.OB ob = Outils.GestionFichier.Charge(Classe.KEY.BINARY_PATH_COMPLETE);
                c.Id = ob.Comptes.Count != 0 ? ob.Comptes.Max(u => u.Id) + 1 : 1;
                ob.Comptes.Add(c);
                Outils.GestionFichier.Sauvegarde(Classe.KEY.BINARY_PATH_COMPLETE, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }
    }
}
