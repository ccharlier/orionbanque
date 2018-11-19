namespace OrionBanque.Forms
{
    public partial class AideForm : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public AideForm(string titre, string aide)
        {
            InitializeComponent();
            kRTBText.Text = aide;
            Text = titre;
        }
    }
}
