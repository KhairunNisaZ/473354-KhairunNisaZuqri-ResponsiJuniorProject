using Npgsql;
using System.Data;

namespace KNZresponsi
{
    public partial class Form1 : Form
    {
        public static NpgsqlCommand cmd;

        public DataTable dt;
        private DataGridViewRow r;

        private Employee emp;
        private EmployeeRepository employeeRepository;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            employeeRepository = new EmployeeRepository(dgvData);
            emp = new Employee();
            btnLoad.PerformClick();
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            employeeRepository.Insert(tbNama, cbDept, btnLoad);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            employeeRepository.Edit(tbNama, cbDept, btnLoad);
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];
                tbNama.Text = r.Cells["_nama"].Value.ToString();
                cbDept.Text = r.Cells["_id_dept"].Value.ToString();
                employeeRepository.Row = r;
                emp.Nama = tbNama.Text;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            employeeRepository.Delete(tbNama, cbDept, btnLoad);
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            employeeRepository.Load();
        }
    }
}