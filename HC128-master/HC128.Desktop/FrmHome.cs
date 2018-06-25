using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC128.Desktop
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            FrmHC128 frmHC128 = new FrmHC128();
            frmHC128.Show();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            FrmDecrypt frmDecrypt = new FrmDecrypt();
            frmDecrypt.Show();
        }
    }
}
