using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OrionBanque.Classe
{
    public class Param
    {
        public int Id { get; set; }
        public string Ident { get; set; }
        public string Val1 { get; set; }
        public string Val2 { get; set; }
        public string Val3 { get; set; }
        public int Int1 { get; set; }
        public int Int2 { get; set; }
        public int Int3 { get; set; }
        public double Dec1 { get; set; }
        public double Dec2 { get; set; }
        public double Dec3 { get; set; }
        public DateTime Dat1 { get; set; }
        public DateTime Dat2 { get; set; }
        public DateTime Dat3 { get; set; }

        public Param()
        {
            this.Ident = string.Empty;
            this.Val1 = string.Empty;
            this.Val2 = string.Empty;
            this.Val3 = string.Empty;
            this.Int1 = Int32.MinValue;
            this.Int2 = Int32.MinValue;
            this.Int3 = Int32.MinValue;
            this.Dec1 = Double.MinValue;
            this.Dec2 = Double.MinValue;
            this.Dec3 = Double.MinValue;
            this.Dat1 = DateTime.MinValue;
            this.Dat2 = DateTime.MinValue;
            this.Dat3 = DateTime.MinValue;
        }

        static public Param Charge(Int32 id)
        {
            Param p = new Param();
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    p = OrionBanque.Classe.SQLite.Param.Charge(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return p;
        }

        static public List<Param> Charge(String ident)
        {
            List<Param> p = new List<Param>();
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    p = OrionBanque.Classe.SQLite.Param.Charge(ident);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
            return p;
        }

        static public void Delete(int id)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Param.Delete(id);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Delete(String ident)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Param.Delete(ident);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Maj(Classe.Param p)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Param.Maj(p);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }

        static public void Sauve(Classe.Param p)
        {
            switch(ConfigurationManager.AppSettings["typeConnection"])
            {
                case Configuration.BD_SQLITE:
                    OrionBanque.Classe.SQLite.Param.Sauve(p);
                    break;
                default:
                    throw new Exception(String.Format("Ce mode de connection({0}) n'est pas autorisé.", ConfigurationManager.AppSettings["typeConnection"]));
            }
        }
    }
}
