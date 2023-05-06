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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mebelDataSet.mebel". При необходимости она может быть перемещена или удалена.
            this.mebelTableAdapter.Fill(this.mebelDataSet.mebel);

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

        private void button4_Click(object sender, EventArgs e)
        {
            {
                mebelTableAdapter.Update(mebelDataSet);
                {
                    MessageBox.Show("Изменения успешно сохранены!");
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mebelDataSet.mebel;
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"name LIKE '%{textBox1.Text}%'";

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.CurrentCell = null;
                dataGridView1.Rows[i].Visible = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }
    }
}
    

