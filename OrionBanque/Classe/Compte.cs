using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;

namespace OrionBanque.Classe
{
    [DataContract(Name = "Compte", Namespace = "https://www.orionbanque.com")]
    [Serializable]
    public class Compte
    {
        [DataMember()]
        public int Id { get; set; }
        [DataMember()]
        public string Libelle { get; set; }
        [DataMember()]
        public double SoldeInitial { get; set; }
        [DataMember()]
        public Utilisateur Utilisateur { get; set; }
        [DataMember()]
        public string Banque { get; set; }
        [DataMember()]
        public string Guichet { get; set; }
        [DataMember()]
        public string NoCompte { get; set; }
        [DataMember()]
        public string Clef { get; set; }
        [DataMember()]
        public DateTime MinGraphSold { get; set; }
        [DataMember()]
        public DateTime MaxGraphSold { get; set; }
        [DataMember()]
        public double SeuilAlerte { get; set; }
        [DataMember()]
        public double SeuilAlerteFinal { get; set; }
        [DataMember()]
        public string TypEvol { get; set; }
        [DataMember()]
        public bool? EstDansTotalCompte { get; set; }

        public static void Delete(int id)
        {
            Log.Logger.Debug("Debut Compte.Delete(" + id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                ob.Operations.RemoveAll((c) => c.Compte.Id == id);
                ob = (OB)CallContext.GetData(KEY.OB);
                ob.Echeanciers.RemoveAll((c) => c.Compte.Id == id);
                ob = (OB)CallContext.GetData(KEY.OB);
                ob.Comptes.RemoveAll((c) => c.Id == id);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
        }

        public static void Delete(Compte c)
        {
            Delete(c.Id);
        }

        public static Compte Charge(int id)
        {
            Log.Logger.Debug("Debut Compte.Charge(" + id + ")");
            Compte c = new Compte();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                c = ob.Comptes.Where(ct => ct.Id == id).First();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return c;
        }

        public static List<Compte> ChargeTout()
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Compte> lc = new List<Compte>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Comptes.OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static List<Compte> ChargeTout(Utilisateur u)
        {
            Log.Logger.Debug("Debut Compte.ChargeTout()");
            List<Compte> lc = new List<Compte>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lc = ob.Comptes.Where(c => c.Utilisateur.Id == u.Id).OrderBy(c => c.Libelle).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lc;
        }

        public static Compte Maj(Compte cA)
        {
            Log.Logger.Debug("Debut Compte.Maj(" + cA.Id + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);

                Compte c = ob.Comptes.Find((ctemp) => ctemp.Id == cA.Id);
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
                c.EstDansTotalCompte = cA.EstDansTotalCompte;

                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        public static Compte Sauve(Compte cA)
        {
            Log.Logger.Debug("Debut Copmpte.Sauve(" + cA.Libelle + ")");
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                cA.Id = ob.Comptes.Count != 0 ? ob.Comptes.Max(u => u.Id) + 1 : 1;
                ob.Comptes.Add(cA);
                CallContext.SetData(KEY.OB, ob);
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return cA;
        }

        public List<Operation> Operations()
        {
            Log.Logger.Debug("Debut Operations()");
            List<Operation> lo = new List<Operation>();
            try
            {
                OB ob = (OB)CallContext.GetData(KEY.OB);
                lo = ob.Operations.Where(ot => ot.Compte.Id == Id).OrderByDescending(x => x.Date).ToList();
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex.Message);
                throw;
            }
            return lo;
        }

        public double AVenir()
        {
            return CalculSoldeOperation(Operations().Where(o => o.DatePointage is null).ToList(), false);
        }

        public double SoldeOperationPointee()
        {
            return CalculSoldeOperation(Operations().Where(o => o.DatePointage != null).ToList(), true);
        }

        private double CalculSoldeOperation(List<Operation> lo, Boolean prendreSoldeInitiale = false)
        {
            double rPositif = 0.0;
            double rNegatif = 0.0;

            foreach (Operation o in lo)
            {
                switch(o.ModePaiement.Type)
                {
                    case KEY.MODEPAIEMENTDEBIT:
                        rNegatif += o.Montant;
                        break;
                    case KEY.MODEPAIEMENTCREDIT:
                        rPositif += o.Montant;
                        break;
                }
            }

            return rPositif - rNegatif + (prendreSoldeInitiale ? SoldeInitial : 0);
        }

        public static DataSet DataSetTotalComptes(TotalCompte tc)
        {
            double totPointe = 0.0;
            double totaVenir = 0.0;
            double totSolde = 0.0;

            Type elementType = typeof(Operation);
            DataSet ds = new DataSet();
            DataTable t = new DataTable("TotalComptes");
            ds.Tables.Add(t);

            t.Columns.Add("Compte", typeof(string));
            t.Columns.Add("Pointé", typeof(double));
            t.Columns.Add("A venir", typeof(double));
            t.Columns.Add("Solde", typeof(double));
            
            List<Compte> list = tc.Comptes;

            //go through each property on T and add each value to the table
            foreach (Compte item in list)
            {
                DataRow row = t.NewRow();
                double soldOpePoint = item.SoldeOperationPointee();
                double aVenir = item.AVenir();
                double soldFinal = soldOpePoint + aVenir;

                row["Compte"] = item.Libelle;
                row["Pointé"] = soldOpePoint;
                row["A venir"] = aVenir;
                row["Solde"] = soldFinal;

                totPointe += soldOpePoint;
                totaVenir += aVenir;
                totSolde += soldFinal;
                
                t.Rows.Add(row);
            }

            DataRow rowTot = t.NewRow();
            rowTot["Compte"] = "Total";
            rowTot["Pointé"] = totPointe;
            rowTot["A venir"] = totaVenir;
            rowTot["Solde"] = totSolde;

            t.Rows.Add(rowTot);

            return ds;
        }
    }
}
