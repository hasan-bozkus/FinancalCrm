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

namespace FinancalCrm
{
    public partial class FrmBankProcess : Form
    {
        public FrmBankProcess()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db = new FinancalCrmDbEntities();
        private void FrmBankProcess_Load(object sender, EventArgs e)
        {
            var lastBill = db.Bills.OrderByDescending(x => x.BillId).Take(1).Select(y => y.BillTitle).FirstOrDefault();
            lblLastBill.Text = lastBill;

            var currentBalance = db.Banks.Sum(x => x.BankBalance);
            lblCurrentBalance.Text = currentBalance.ToString() + " ₺";

            var lastBankProcessAmonut = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmonut.ToString() + " ₺";

            //son Gelen 5 hareket
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

            //son Giden 5 hareket

            var lastBillProcess1 = db.Bills.OrderByDescending(x => x.BillId).Take(1).FirstOrDefault();
            lblBillProcess1.Text = lastBillProcess1.BillTitle + " " + lastBillProcess1.BillAmount + " ₺" + " " + lastBillProcess1.BillPeriod;

            var lastBillProcess2 = db.Bills.OrderByDescending(x => x.BillId).Take(2).Skip(1).FirstOrDefault();
            lblBillProcess2.Text = lastBillProcess2.BillTitle + " " + lastBillProcess2.BillAmount + " ₺" + " " + lastBillProcess2.BillPeriod;

            var lastBillProcess3 = db.Bills.OrderByDescending(x => x.BillId).Take(3).Skip(2).FirstOrDefault();
            lblBillProcess3.Text = lastBillProcess3.BillTitle + " " + lastBillProcess3.BillAmount + " ₺" + " " + lastBillProcess3.BillPeriod;

            var lastBillProcess4 = db.Bills.OrderByDescending(x => x.BillId).Take(4).Skip(3).FirstOrDefault();
            lblBillProcess4.Text = lastBillProcess4.BillTitle + " " + lastBillProcess4.BillAmount + " ₺" + " " + lastBillProcess4.BillPeriod;

            var lastBillProcess5 = db.Bills.OrderByDescending(x => x.BillId).Take(5).Skip(4).FirstOrDefault();
            lblBillProcess5.Text = lastBillProcess5.BillTitle + " " + lastBillProcess5.BillAmount + " ₺" + " " + lastBillProcess5.BillPeriod;

        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpending frm = new FrmSpending();
            frm.Show();
            this.Hide();
        }

        private void btnCategoryForm_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            frm.Show();
            this.Hide();
        }

        private void btnBankForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {
            FrmBankProcess frm = new FrmBankProcess();
            frm.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
