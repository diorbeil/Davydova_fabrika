using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Davydova_fabrika
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mebelnayafabrika_davydovaDataSet.material". При необходимости она может быть перемещена или удалена.
            this.materialTableAdapter.Fill(this.mebelnayafabrika_davydovaDataSet.material);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                materialTableAdapter.Update(mebelnayafabrika_davydovaDataSet);
                {
                    MessageBox.Show("Изменения успешно сохранены!");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-4BGD6JJ; Initial Catalog = mebelnayafabrika_davydova; Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("Select * FROM mebel Order By name asc");
            con1.Open();
            da.Fill(ds, "mebelnayafabrika_davydova");
            dataGridView1.DataSource = ds.Tables[0];
            da.Dispose();
            con1.Dispose();
            ds.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet asc = new DataSet();
            SqlConnection con1 = new SqlConnection(@"Data Source=DESKTOP-4BGD6JJ; Initial Catalog = mebelnayafabrika_davydova; Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("Select * FROM mebel Order By name ds");
            con1.Open();
            da.Fill(asc, "mebelnayafabrika_davydova");
            dataGridView1.DataSource = asc.Tables[0];
            da.Dispose();
            con1.Dispose();
            asc.Dispose();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mebelDataS.mebel;
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{textBox1.Text}%'";
        }
    }
}
