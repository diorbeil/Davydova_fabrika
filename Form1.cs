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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection DavidovaConnectionString = new SqlConnection(@"Data Source=DESKTOP-4BGD6JJ; Initial Catalog = mebelnayafabrika_davydova; Integrated Security=True");
            string query = "Select * FROM polzovateli WHERE login='" + comboBox1.Text + "'and password='" + textBox2.Text + "'";
            DavidovaConnectionString.Open();

            SqlCommand cmd = new SqlCommand(query, DavidovaConnectionString);
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    object Login = rdr.GetValue(0);
                    object Password = rdr.GetValue(1);

                    string login = Login.ToString();
                    string password = Password.ToString();
                    if (login == "admin")
                    {
                        Form6 frm6 = new Form6();
                        frm6.Show();
                        this.Hide();
                    }
                    else if (login == "user ")
                    {
                        Form3 frm3 = new Form3();
                        frm3.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильный пароль", "Ошибка!", "Пароль должен быть не менее 6 символов", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxIcon., MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "davydovaDataSet.polzovateli". При необходимости она может быть перемещена или удалена.
            this.polzovateliTableAdapter.Fill(this.davydovaDataSet.polzovateli);

        }
    }
}
