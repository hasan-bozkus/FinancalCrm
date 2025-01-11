using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancalCrm.Models;

namespace FinancalCrm
{
    public partial class FrmBanks : Form
    {

        //FinancalCrmDbEntities veri tabanı için adı
        public FrmBanks()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db = new FinancalCrmDbEntities();

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            //Banka Bakiyeleri
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıfbank").Select(y => y.BankBalance).FirstOrDefault();
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();

            lblİsBankasiBalance.Text = isBankBalance.ToString() + " ₺";
            lblVakifbankBalance.Text = vakifBankBalance.ToString() + " ₺";
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";

            //banka hareketleri
            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(1).FirstOrDefault();
            lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + DateTime.Parse(bankProcess1.ProcessDate.ToString()).ToString("dd-MMM-yyyy");

            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(2).Skip(1).FirstOrDefault();
            lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + DateTime.Parse(bankProcess2.ProcessDate.ToString()).ToString("dd-MMM-yyyy");

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(3).Skip(2).FirstOrDefault();
            lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + DateTime.Parse(bankProcess3.ProcessDate.ToString()).ToString("dd-MMM-yyyy");

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(4).Skip(3).FirstOrDefault();
            lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + DateTime.Parse(bankProcess4.ProcessDate.ToString()).ToString("dd-MMM-yyyy");

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.ProcessDate).Take(5).Skip(4).FirstOrDefault();
            lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + DateTime.Parse(bankProcess5.ProcessDate.ToString()).ToString("dd-MMM-yyyy");
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }
    }
}
