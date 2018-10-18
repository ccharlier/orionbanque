using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OrionBanque.Forms
{
    public partial class Aide : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Aide(string titre, string aide)
        {
            InitializeComponent();
            kryptonRichTextBox1.Text = aide;
            this.Text = titre;
        }
    }
}
