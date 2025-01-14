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
    public partial class FrmSpending : Form
    {
        public FrmSpending()
        {
            InitializeComponent();
        }

        FinancalCrmDbEntities db = new FinancalCrmDbEntities();

        public void CategoryList()
        {
            var values = db.Categories.ToList();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
            cmbCategory.DataSource = values;
        }

        public void SpendingListWithCategoryName()
        {
            var values = db.Spendings.Select(y => new
            {
                y.SpendingTitle,
                y.SpendingDate,
                y.SpendingId,
                y.CategoryId,
                y.Categories.CategoryName
            }).ToList();
            dataGridView1.DataSource = values;
        }

        private void FrmSpending_Load(object sender, EventArgs e)
        {
            SpendingListWithCategoryName();
            CategoryList();
        }

        private void btnSpendingList_Click(object sender, EventArgs e)
        {
            SpendingListWithCategoryName();
            CategoryList();
        }

        private void btnCreateSpending_Click(object sender, EventArgs e)
        {
            string spendingTitle = txtSpendingTitle.Text;
            decimal spendingAmount = decimal.Parse(txtSpendingAmount.Text);
            int selectedCategory = int.Parse(cmbCategory.SelectedValue.ToString()); 

            Spendings spendings = new Spendings();
            spendings.SpendingTitle = spendingTitle;
            spendings.SpendingDate = DateTime.Parse(DateTime.UtcNow.ToString("dd-MMM-yyyy"));
            spendings.CategoryId = selectedCategory;
            db.Spendings.Add(spendings);
            db.SaveChanges();
            MessageBox.Show("Harcama Eklendi");
            SpendingListWithCategoryName();
            CategoryList();
        }

        private void btnRemoveSpending_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);

            var removedValue = db.Spendings.Find(id);
            db.Spendings.Remove(removedValue);
            db.SaveChanges();
            MessageBox.Show("Harcama Silindi");
            SpendingListWithCategoryName();
            CategoryList();
        }

        private void btnUpdateSpending_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSpendingId.Text);
            string title = txtSpendingTitle.Text;
            decimal amount = decimal.Parse(txtSpendingAmount.Text);

            var values = db.Spendings.Find(id);
            values.SpendingTitle = title;
            values.SpendingAmount = amount;
            db.SaveChanges();
            MessageBox.Show("Harcama Güncellendi");
            SpendingListWithCategoryName();
            CategoryList();
        }

        private void btnCategoryForm_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            frmCategory.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void btnSpendingForm_Click(object sender, EventArgs e)
        {
            FrmSpending frmSpending = new FrmSpending();
            frmSpending.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void btnBankProcessForm_Click(object sender, EventArgs e)
        {
            FrmBankProcess frmBankProcess = new FrmBankProcess();
            frmBankProcess.Show();
            this.Hide();
        }

        private void btnDashboardForm_Click(object sender, EventArgs e)
        {
            FrmDashboard frmDashboard = new FrmDashboard();
            frmDashboard.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
