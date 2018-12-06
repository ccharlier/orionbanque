using OrionBanque.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class GestTiersForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;

        public GestTiersForm(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            ChargeCb();
        }

        private void ChargeCb()
        {
            List<string> ls = Operation.ChargeToutTiers(uA);
            kLBTiersSaisis.DataSource = ls;
        }
    }
}
