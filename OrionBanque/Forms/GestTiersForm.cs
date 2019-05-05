using OrionBanque.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class GestTiersForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Utilisateur uA;
        private bool bMustSave = false;

        public bool BMustSave { get => bMustSave; set => bMustSave = value; }

        public GestTiersForm(Utilisateur u)
        {
            uA = u;
            InitializeComponent();
            kLBTiersSaisis.ListBox.DoubleClick += kLBTiersSaisis_DoubleClick;
            kLBTiersPredict.ListBox.DoubleClick += kLBTiersPredict_DoubleClick;
            ChargeCb();
        }

        private void ChargeCb()
        {
            kLBTiersPredict.DataSource = null;
            OB ob = (OB)CallContext.GetData(KEY.OB);
            List<string> ltemp = ob.Tiers ?? new List<string>();
            ltemp.Sort();
            kLBTiersPredict.DataSource = ltemp;

            List<string> ls = Operation.ChargeToutTiers(uA);
            foreach(string temp in ltemp)
            {
                ls.Remove(temp);
            }
            kLBTiersSaisis.DataSource = ls;
        }

        private void TiersToPredict()
        {
            string s = (string)kLBTiersSaisis.SelectedValue;
            OB ob = (OB)CallContext.GetData(KEY.OB);
            if(ob.Tiers is null)
            {
                ob.Tiers = new List<string>();
            }
            ob.Tiers.Add(s);
            CallContext.SetData(KEY.OB, ob);
            bMustSave = true;

            ChargeCb();
        }

        private void PredictToTiers()
        {
            string s = (string)kLBTiersPredict.SelectedValue;
            OB ob = (OB)CallContext.GetData(KEY.OB);
            ob.Tiers.Remove(s);
            CallContext.SetData(KEY.OB, ob);
            bMustSave = true;

            ChargeCb();
        }

        private void kBtnActiveOne_Click(object sender, EventArgs e)
        {
            TiersToPredict();
        }

        private void kBtnDesactiveOne_Click(object sender, EventArgs e)
        {
            PredictToTiers();
        }

        private void kLBTiersSaisis_DoubleClick(object sender, EventArgs e)
        {
            TiersToPredict();
        }

        private void kLBTiersPredict_DoubleClick(object sender, EventArgs e)
        {
            PredictToTiers();
        }
    }
}