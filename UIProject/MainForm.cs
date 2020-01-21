using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIProject
{
    public partial class MainForm : Form
    {
        private string _conStr;
        private DbContext _db;
        const decimal _minSalary = 20000; // минимальная ЗП
       

        public MainForm()
        {
            InitializeComponent();

            monthPicker1.Format = DateTimePickerFormat.Custom;
            monthPicker1.CustomFormat = "MMMM yyyy";
            monthPicker1.ShowUpDown = true;
            monthPicker1.Value = DateTime.Now.AddMonths(-2);

            monthPicker2.Format = DateTimePickerFormat.Custom;
            monthPicker2.CustomFormat = "MMMM yyyy";
            monthPicker2.ShowUpDown = true;
            monthPicker2.Value = DateTime.Now;

            cbSelectSalaryParam.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // получаем строку соединения из конфигурационного файла
            _conStr = Properties.Settings.Default.ConnectionString;
            // создаем объект для работы с БД
            _db = new DbContext(_conStr);           
        }

        #region Text Name Filter
        private void txtNameFilter_Enter(object sender, EventArgs e)
        {
            if (txtNameFilter.Text == "Имя сотрудника для поиска")
            {
                txtNameFilter.Text = "";
                txtNameFilter.Font = new Font (txtNameFilter.Font, FontStyle.Regular);
                txtNameFilter.ForeColor = Color.Black;   
                
            }
        }
        private void txtNameFilter_Leave(object sender, EventArgs e)
        {
            if (txtNameFilter.Text == "")
            {
                txtNameFilter.Text = "Имя сотрудника для поиска";
                txtNameFilter.Font = new Font(txtNameFilter.Font, FontStyle.Italic);
                txtNameFilter.ForeColor = Color.Silver;
            }
        }
        private void txtNameFilter_TextChanged(object sender, EventArgs e)
        {
            FilterRowsByName(_db.DataTable, txtNameFilter.Text);
        }
        // Отображать только те строки, которые удовлетворяют условию фильтрации по полю "Name"
        private void FilterRowsByName(DataTable dt, string name)
        {
            if (name == "Имя сотрудника для поиска")
                return;

            if (dt != null)
               dt.DefaultView.RowFilter = string.Format("[Name] LIKE '%{0}%'", name);
        }
        #endregion

        // Показать результаты запроса
        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime beginDate = monthPicker1.Value, endDate = monthPicker2.Value;
            if (beginDate > endDate)
                throw new Exception("Нижняя граница диапазона дат не может быть больше верхней границы");

            if (!_db.RetrieveEmployeeSalaries(beginDate, endDate, (SalaryTypes)cbSelectSalaryParam.SelectedIndex, flgShowAll.Checked))
                throw _db.Exception;

            FilterRowsByName(_db.DataTable, txtNameFilter.Text);
            dgvResults.DataSource = _db.DataTable;      
        }
              
        private void dgvResults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // все столбцы - не сортируемые
            dgvResults.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.SortMode = DataGridViewColumnSortMode.NotSortable);
            
            // выделяем цветом тех сотрудников, у которых ЗП < _minSalary
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                if ((decimal)row.Cells["Salary"].Value < _minSalary)
                {
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        private void menuEditDb_Click(object sender, EventArgs e)
        {
            new EditDBForm(_conStr).ShowDialog();
        }

        private void menuPayments_Click(object sender, EventArgs e)
        {
            new PaymentsHistory(_conStr).Show();
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {
            string info = "Пример\n\nСотрудник Вадим получил следующие выплаты:\n"
                + "\tза ноябрь 2019 - 25000 и 31000,\n\tза декабрь 2019 - 29000 и 21000.\n\n"
                + "Зарплата\n\tноябрь:  25 + 31 = 56 т.р.\n\tдекабрь: 29 + 21 = 50 т.р.\n"
                + "\nСредняя за два месяца: (56 + 50) / 2 = 53 т.р.\n"
                + "Максимальная за два месяца: 56 т.р.\n\n"
                + "В январе 2020 выплат не было (сотрудник был уволен)";
            
            MessageBox.Show(info);
        }
    }
}
