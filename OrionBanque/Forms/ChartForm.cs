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
    public partial class ChartForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private Compte cA;

        public ChartForm(Compte c)
        {
            cA = c;
            InitializeComponent();
            ChargeListeComptes();
            kListeComptes.SelectedItem = cA;
            kDTPDateMin.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            kDTPDateMax.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            UpdateGraph();
        }

        private void ChargeListeComptes()
        {
            kListeComptes.ValueMember = "Id";
            kListeComptes.DisplayMember = "Libelle";
            kListeComptes.DataSource = Compte.ChargeTout(cA.Utilisateur);
        }

        private void UpdateGraph()
        {
            List<string[]> ls = new List<string[]>();

            switch (kCS2D3D.CheckedButton.Name)
            {
                case "kCB2D":
                    chart.ChartAreas[0].Area3DStyle.Enable3D = false;
                    break;
                case "kCB3D":
                    chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                    break;
                default:
                    chart.ChartAreas[0].Area3DStyle.Enable3D = false;
                    break;
            }

            switch (kCSTypeGraph.CheckedButton.Name)
            {
                case "kCBBarre":
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    break;
                case "kCBCam":
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                    break;
                default:
                    chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    break;
            }

            switch (kCSChoixGroupe.CheckedButton.Name)
            {
                case "kCBChoixGroupTiers":
                    ls = Operation.GroupByTiers((Compte)kListeComptes.SelectedItem, kDTPDateMin.Value, kDTPDateMax.Value);
                    break;
                case "kCBChoixGroupCateg":
                    ls = Operation.GroupByCategories((Compte)kListeComptes.SelectedItem, kDTPDateMin.Value, kDTPDateMax.Value);
                    break;
                default:
                    ls = Operation.GroupByTiers((Compte)kListeComptes.SelectedItem, kDTPDateMin.Value, kDTPDateMax.Value);
                    break;
            }

            double groupMontant = 0.0;

            chart.Series[0].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chart.Series[0].Points.Clear();

            foreach (string[] s in ls)
            {
                double montant = double.Parse(s[1]);
                if (Math.Abs(montant) < double.Parse(kNUPVal.Value.ToString()))
                {
                    if(montant > 0 && kCBAfficheRecettes.Checked)
                    {
                        groupMontant += montant;
                    }
                    if (montant < 0 && kCBAfficheDepenses.Checked)
                    {
                        groupMontant += montant;
                    }
                }
                else
                {
                    if(montant > 0 && kCBAfficheRecettes.Checked)
                    {
                        chart.Series[0].Points.AddXY(s[0], montant);
                    }
                    if (montant < 0 && kCBAfficheDepenses.Checked)
                    {
                        chart.Series[0].Points.AddXY(s[0], montant);
                    }
                }
            }

            if(kCBGroupVal.Checked)
            {
                chart.Series[0].Points.AddXY("Autres", groupMontant);
            }
        }

        #region Event
        private void kCS_CheckedButtonChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBChoixGroupTiers_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBChoixGroupCateg_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBChoixGroupGdeCateg_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBGroupVal_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBMasqueVal_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBCam_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBBarre_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCB2S_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCB3D_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBAfficheRecettes_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kCBAfficheDepenses_Click(object sender, EventArgs e)
        {
            UpdateGraph();
        }

        private void kNUPVal_ValueChanged(object sender, EventArgs e)
        {
            UpdateGraph();
        }
        #endregion
    }
}
