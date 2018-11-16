using OrionBanque.Classe;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace OrionBanque.Forms
{
    public partial class GraphiqueForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        int idC;
        int idColor = 0;
        List<Color> lC = new List<Color>();

        public GraphiqueForm(string typeGraph, int id)
        {
            lC.Add(Color.Navy);
            lC.Add(Color.Purple);
            lC.Add(Color.LimeGreen);
            lC.Add(Color.SandyBrown);
            lC.Add(Color.Red);
            lC.Add(Color.Blue);
            lC.Add(Color.Green);
            lC.Add(Color.Yellow);
            lC.Add(Color.White);
            idC = id;
            InitializeComponent();
            switch(typeGraph)
            {
                case Classe.KEY.GRAPH_TIERS:
                    cbTypeGraph.SelectedItem = Classe.KEY.GRAPH_TIERS_LIB;
                    break;
                case Classe.KEY.GRAPH_TIERS_DC:
                    cbTypeGraph.SelectedItem = Classe.KEY.GRAPH_TIERS_DC_LIB;
                    break;
                case Classe.KEY.GRAPH_CATEGORIES:
                    cbTypeGraph.SelectedItem = Classe.KEY.GRAPH_CATEGORIES_LIB;
                    break;
                case Classe.KEY.GRAPH_CATEGORIES_DC:
                    cbTypeGraph.SelectedItem = Classe.KEY.GRAPH_CATEGORIES_DC_LIB;
                    break;
            }
        }

        private void ChoixGraphique(string typeGraph)
        {
            xGraph.MasterPane = new MasterPane();
            xGraph.Invalidate();
            try
            {
                string title = string.Empty;
                string xBar = string.Empty;
                switch (typeGraph)
                {
                    case KEY.GRAPH_TIERS:
                    case KEY.GRAPH_TIERS_LIB:
                        title = "Par tiers";
                        xBar = "Tiers";
                        if(kBtnHisto.Checked)
                        {
                            CreateChartSingle(xGraph, title, xBar, Operation.GroupByTiers(idC));
                        }
                        else if (kbtnCam.Checked)
                        {
                            CreateChartCam(xGraph, title, Operation.GroupByTiers(idC));
                        }

                        break;
                    case KEY.GRAPH_TIERS_DC:
                    case KEY.GRAPH_TIERS_DC_LIB:
                        title = "Par tiers";
                        xBar = "Tiers";
                        if (kBtnHisto.Checked)
                        {
                            CreateChartDouble(xGraph, title, xBar, Operation.GroupByTiersDC(idC));
                        }
                        else if (kbtnCam.Checked)
                        {
                            CreateChartCamDouble(xGraph, title, Operation.GroupByTiersDC(idC));
                        }

                        break;
                    case KEY.GRAPH_CATEGORIES:
                    case KEY.GRAPH_CATEGORIES_LIB:
                        title = "Par catégories";
                        xBar = "Catégories";
                        if (kBtnHisto.Checked)
                        {
                            CreateChartSingle(xGraph, title, xBar, Operation.GroupByCategories(idC));
                        }
                        else if (kbtnCam.Checked)
                        {
                            CreateChartCam(xGraph, title, Operation.GroupByCategories(idC));
                        }

                        break;
                    case KEY.GRAPH_CATEGORIES_DC:
                    case KEY.GRAPH_CATEGORIES_DC_LIB:
                        title = "Par Catégories";
                        xBar = "Catégories";
                        if (kBtnHisto.Checked)
                        {
                            CreateChartDouble(xGraph, title, xBar, Operation.GroupByCategoriesDC(idC));
                        }
                        else if (kbtnCam.Checked)
                        {
                            CreateChartCamDouble(xGraph, title, Operation.GroupByCategoriesDC(idC));
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void SetSize()
        {
            // Leave a small margin around the outside of the control
            xGraph.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 20);
        }

        private Color GetNextColor()
        {
            Color retour = lC[idColor];
            idColor++;
            if (idColor >= lC.Count())
            {
                idColor = 0;
            }
            return retour;
        }

        /// <summary>
        /// Une bar en cumul
        /// </summary>
        /// <param name="zgc"></param>
        /// <param name="title"></param>
        /// <param name="xBar"></param>
        private void CreateChartSingle(ZedGraphControl zgc, string title, string xBar, List<string[]> ls)
        {
            GraphPane myPane = new GraphPane();

            // Set the titles and axis labels
            myPane.Title.Text = title;
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Times New Roman";
            myPane.XAxis.Title.Text = xBar;
            myPane.XAxis.Scale.FontSpec.Size = 10f;
            myPane.YAxis.Title.Text = title;

            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);

            double[] y = new double[ls.Count];
            string[] str = new string[ls.Count];
            int i = 0;
            foreach (string[] s in ls)
            {
                y[i] = double.Parse(s[1]);
                str[i] = s[0];
                i++;
            }

            // Add a bar to the graph
            BarItem myCurve = myPane.AddBar("Curve 1", null, y, GetNextColor());
            // turn off the bar border
            myCurve.Bar.Border.IsVisible = true;

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = str;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            // disable the legend
            myPane.Legend.IsVisible = false;

            zgc.GraphPane = myPane;

            SetSize();

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

        /// <summary>
        /// Deux barres : une pour les Entrées et l'autres pour les Sorties. 
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateChartDouble(ZedGraphControl zgc, string title, string xBar, List<string[]> ls)
        {
            GraphPane myPane = new GraphPane();

            // Set the titles and axis labels
            myPane.Title.Text = title;
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Times New Roman";
            myPane.XAxis.Title.Text = xBar;
            myPane.XAxis.Scale.FontSpec.Size = 8f;
            myPane.YAxis.Title.Text = title;

            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);

            // Make up some random data points
            double[] y = new double[ls.Count];
            double[] y2 = new double[ls.Count];
            string[] str = new string[ls.Count];

            int i = 0;
            foreach (string[] s in ls)
            {
                y[i] = double.Parse(s[1]);
                y2[i] = double.Parse(s[2]);
                str[i] = s[0];
                i++;
            }

            // Add a bar to the graph
            BarItem myCurve = myPane.AddBar(title + " en Débit", null, y, GetNextColor());
            // turn off the bar border
            myCurve.Bar.Border.IsVisible = false;

            // Add a second bar to the graph
            myCurve = myPane.AddBar(title + " en Crédit", null, y2, GetNextColor());
            // turn off the bar border
            myCurve.Bar.Border.IsVisible = false;

            // Draw the X tics between the labels instead of at the labels
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = str;

            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            myPane.IsIgnoreMissing = true;

            // Fill the axis background with a color gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.SteelBlue, 45.0f);

            // disable the legend
            myPane.Legend.IsVisible = true;

            xGraph.GraphPane = myPane;

            SetSize();

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

        private void CreateChartCam(ZedGraphControl zgc, string title, List<string[]> ls)
        {
            GraphPane myPane = new GraphPane();

            // Set the GraphPane title
            myPane.Title.Text = title;
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Times New Roman";

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            // Set the legend to an arbitrary location
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction,
                           AlignH.Right, AlignV.Top);
            myPane.Legend.FontSpec.Size = 10f;
            myPane.Legend.IsHStack = false;

            // Add some pie slices
            foreach (string[] s in ls)
            {
                myPane.AddPieSlice(double.Parse(s[1]), GetNextColor(), Color.White, 45f, 0, s[0]);
            }

            xGraph.GraphPane = myPane;

            SetSize();

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
        }

        public void CreateChartCamDouble(ZedGraphControl zgc, string title, List<string[]> ls)
        {
            MasterPane myMaster = zgc.MasterPane;

            myMaster.PaneList.Clear();

            // Set the master pane title
            myMaster.Title.Text = title;
            myMaster.Title.IsVisible = true;

            // Fill the masterpane background with a color gradient
            myMaster.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);

            // Set the margins and the space between panes to 10 points
            myMaster.Margin.All = 10;
            myMaster.InnerPaneGap = 10;

            // Enable the masterpane legend
            myMaster.Legend.IsVisible = true;
            myMaster.Legend.Position = LegendPos.TopCenter;
            myMaster.IsUniformLegendEntries = true;

            // Create some GraphPanes
            int i = 1;
            for (int x = 0; x < 2; x++)
            {
                // Create the GraphPane
                GraphPane myPane = new GraphPane();
                if(i == 1)
                    myPane.Title.Text = title + " en Débit";
                else
                    myPane.Title.Text = title + " en Crédit";

                // Fill the pane background with a solid color
                myPane.Fill = new Fill(Color.Cornsilk);
                // Fill the chart background with a solid color
                myPane.Chart.Fill = new Fill(Color.Cornsilk);

                // Hide the GraphPane legend
                myPane.Legend.IsVisible = false;

                myPane.IsIgnoreMissing = true;
                // Add some pie slices
                int j = 0;
                foreach (string[] s in ls)
                {
                    myPane.AddPieSlice(double.Parse(s[i]), lC[j], Color.White, 45f, 0, s[0]).LabelDetail.IsVisible = false;
                    j++;
                    if (j >= lC.Count())
                    {
                        j = 0;
                    }
                }
                i++;

                // Add the graphpane to the masterpane
                myMaster.Add(myPane);
            }

            // Tell ZedGraph to auto layout the graphpanes
            using (Graphics g = CreateGraphics())
            {
                SetSize();
                myMaster.SetLayout(g, PaneLayout.SingleRow);
                zgc.AxisChange();
            }
        }

        private void CbTypeGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTypeGraph.SelectedItem.ToString() == "Par Catégories" ||
               cbTypeGraph.SelectedItem.ToString() == "Par Tiers")
            {
                kbtnCam.Checked = false;
                kbtnCam.Enabled = false;
                kBtnHisto.Checked = true;
            }
            else
            {
                kbtnCam.Enabled = true;
            }

            ChoixGraphique(cbTypeGraph.SelectedItem.ToString());
        }

        private void KbtnCam_Click(object sender, EventArgs e)
        {
            kbtnCam.Checked = true;
            kBtnHisto.Checked = false;
            ChoixGraphique(cbTypeGraph.SelectedItem.ToString());
        }

        private void KBtnHisto_Click(object sender, EventArgs e)
        {
            kBtnHisto.Checked = true;
            kbtnCam.Checked = false;
            ChoixGraphique(cbTypeGraph.SelectedItem.ToString());
        }

        private void XGraph_MouseMove(object sender, MouseEventArgs e)
        {
            ZedGraphControl xG = (ZedGraphControl)sender;
            // Save the mouse location
            PointF mousePt = new PointF(e.X, e.Y);

            // Find the Chart rect that contains the current mouse location
            GraphPane pane = xG.MasterPane.FindChartRect(mousePt);

            // If pane is non-null, we have a valid location.  Otherwise, the mouse is not
            // within any chart rect.
            if (pane != null)
            {
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out double x, out double y);
                // Format the status label text
                kPosition.Text = "(" + x.ToString("f2") + ", " + y.ToString("f2") + ")";
            }
            else
                // If there is no valid data, then clear the status label text
                kPosition.Text = "Position";
        }
    }
}
