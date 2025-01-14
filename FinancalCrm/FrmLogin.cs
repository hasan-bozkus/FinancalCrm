using FinancalCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            using (var db = new FinancalCrmDbEntities())
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Text;


                var user = db.Users.Where(u => u.UserName == txtUserName.Text).FirstOrDefault();

                if (user != null && user.Password == txtPassword.Text)
                {
                    FrmDashboard frm = new FrmDashboard();
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}
