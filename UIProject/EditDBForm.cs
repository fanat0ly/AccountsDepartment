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
    public partial class EditDBForm : Form
    {
        private DbContext _db;
        private DataTable _empDT, _paymentsDT;
       
        public EditDBForm(string connectionString)
        {
            InitializeComponent();
            _db = new DbContext(connectionString);            
        }

        private void EditDBForm_Load(object sender, EventArgs e)
        {
            FillTables();
        }

        private void FillTables()
        {  
            // Получаем таблицу сотрудников
            if (!_db.RetriveEmployees())
                throw _db.Exception;
            else
                _empDT = _db.DataTable;

            // заполняем таблицу сотрудников
            dgvEmployees.DataSource = _empDT;
            // делаем недоступным столбец id для изменения
            dgvEmployees.Columns["Id"].ReadOnly = true;

            // Получаем таблицу выплат
            if (!_db.RetrivePayments())
                throw _db.Exception;
            else
                _paymentsDT = _db.DataTable;

            // заполняем таблицу выплат
            dgvPayments.DataSource = _paymentsDT;
            // делаем недоступным столбец id для изменения
            dgvPayments.Columns["Id"].ReadOnly = true;
        }

        private void dgvEmployees_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // значение по умолчанию для поля "Active"
            e.Row.Cells["Active"].Value = true;
        }
            
        private void dgvPayments_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            // значение по умолчанию для поля "Datetime"
            e.Row.Cells["Datetime"].Value = DateTime.Now;
        }

        // Сохранить изменения в БД
        private void btnSave_Click(object sender, EventArgs e)
        {
            //var OkCancel = MessageBox.Show("Cохранить изменения в БД?", Application.ProductName, MessageBoxButtons.OKCancel);
            //if (OkCancel == DialogResult.Cancel)
            //    return;
            
            if (_empDT != null)
            {
                if (!_db.UpdateEmployees(_empDT))
                    throw _db.Exception;
            }

            if (_paymentsDT != null)
            {
                if (!_db.UpdatePayments(_paymentsDT))
                    throw _db.Exception;
                
                if (!_db.RetrivePayments())
                    throw _db.Exception;
                else
                    _paymentsDT = _db.DataTable;

                // обновляем таблицу выплат
                dgvPayments.DataSource = _paymentsDT;
            }
        }
    }
}
