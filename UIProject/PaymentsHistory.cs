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
    public partial class PaymentsHistory : Form
    {
        private DbContext _db;
        
        public PaymentsHistory(string connectionString)
        {
            InitializeComponent();
            _db = new DbContext(connectionString);
        }

        private void PaymentsHistory_Load(object sender, EventArgs e)
        {            
            if (!_db.RetrivePaymentsHistory())
                throw _db.Exception;
           
            dgvPayments.DataSource = _db.DataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_db.RetrivePaymentsHistory())
                throw _db.Exception;

            dgvPayments.DataSource = _db.DataTable;
        }
    }
}
