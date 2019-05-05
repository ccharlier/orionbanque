using System;
using System.Reflection;

namespace OrionBanque.Forms
{
    partial class AboutBoxForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public AboutBoxForm()
        {
            InitializeComponent();
            Text = $"À propos de {GetAssemblyTitle()}";
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Version {0}", GetAssemblyVersion());
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
        }

        #region Accesseurs d'attribut de l'assembly

        public string GetAssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (string.IsNullOrEmpty(titleAttribute.Title))
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        public string GetAssemblyVersion()
        {
            return "2.0.0.0";
        }

        public static string AssemblyDescription
        {
            get
            {
                return "OrionBanque  - Logiciel de gestion bancaire." + Environment.NewLine +
"Copyright (C) 2018 Cyril Charlier — Tous droits réservés." + Environment.NewLine +
"Pour me contacter : cyril.charlier+orionbanque@gmail.com" + Environment.NewLine +
"Site : http://www.orionbanque.fr/" + Environment.NewLine +
"" + Environment.NewLine +
"Ce programme est un logiciel libre ; vous pouvez le redistribuer ou le " +
"modifier suivant les termes de la “GNU General Public License” telle que " +
"publiée par la Free Software Foundation : soit la version 2.1 de cette " +
"licence, soit (à votre gré) toute version ultérieure." + Environment.NewLine +
"" + Environment.NewLine +
"Ce programme est distribué dans l’espoir qu’il vous sera utile, mais SANS " +
"AUCUNE GARANTIE : sans même la garantie implicite de COMMERCIALISABILITÉ " +
"ni d’ADÉQUATION À UN OBJECTIF PARTICULIER. Consultez la Licence Générale " +
"Publique GNU pour plus de détails." + Environment.NewLine +
"" + Environment.NewLine +
"Vous devriez avoir reçu une copie de la Licence Générale Publique GNU avec " +
"ce programme ; si ce n’est pas le cas, consultez : " +
"http://www.gnu.org/licenses/";
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                return "OrionBanque";
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
