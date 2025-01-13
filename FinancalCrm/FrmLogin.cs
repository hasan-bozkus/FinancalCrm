using FinancalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinancalCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db = new FinancalCrmDbEntities();
        public static string KullaniciAdi { get; set; }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var kullanici = db.Users.FirstOrDefault(k => k.UserName == txtUserName.Text && k.Password == txtPassword.Text);

            if (kullanici != null)
            {
                
                MessageBox.Show("Giriş Başarılı!");
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Giriş başarısız
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }
        }
    }
}
