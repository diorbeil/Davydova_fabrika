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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void добавить_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string id = textBox1.Text.Trim(); //id код
                string name = textBox2.Text.Trim(); // название материала
                string opisanie = textBox3.Text.Trim(); //описание материала 
                string kolichestvo = textBox4.Text.Trim(); // количество
                string data_postupleniya = dateTimePicker1.Value.ToString(); //дата поступление
                string data_ispolzovaniya = dateTimePicker2.Value.ToString(); // дата использования
        

                SqlConnection DavidovaConnectionString = new SqlConnection(@"Data Source=DESKTOP-4BGD6JJ; Initial Catalog = mebelnayafabrika_davydova; Integrated Security=True");
                string inserquery = "INSERT INTO material (id, name, opisanie, kolichestvo, data_postupleniya, data_ispolzovaniya) VALUES ('" + id + "','" + name + "','" + opisanie + "','" + kolichestvo + "','" + data_postupleniya + "','" + data_ispolzovaniya + "')";
                SqlCommand cmd2 = new SqlCommand(inserquery, DavidovaConnectionString);
                DavidovaConnectionString.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Материал успешно добавлен!");
                DavidovaConnectionString.Close();
            }

        }

        private void назад_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
