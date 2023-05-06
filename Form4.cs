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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                string id = textBox1.Text.Trim(); //id код
                string name = textBox2.Text.Trim(); // название мебели
                string opisanie = textBox3.Text.Trim(); //описание мебели
                string price = textBox4.Text.Trim(); //цена мебели
                string kolichestvo = textBox5.Text.Trim(); // количество
                string data_postupleniya = dateTimePicker1.Value.ToString(); //дата поступление
                string data_manufacturi= dateTimePicker2.Value.ToString(); // дата мануфактуры
                string material_id1 = textBox6.Text.Trim(); //вид комплектации
                string material_id2 = textBox7.Text.Trim();
                string material_id3 = textBox8.Text.Trim();

                SqlConnection DavidovaConnectionString = new SqlConnection(@"Data Source=DESKTOP-4BGD6JJ; Initial Catalog = mebelnayafabrika_davydova; Integrated Security=True");
                string inserquery = "INSERT INTO mebel (id, name, opisanie, price, kolichestvo, data_postupleniya, data_manufacturi, material_id1, material_id2, material_id3) VALUES ('" + id + "','" + name + "','" + opisanie + "','" + kolichestvo + "','" + price + "','" + data_postupleniya + "','" + data_manufacturi + "','" + material_id1 + "','" + material_id2 + "','" + material_id3 + "')";
                SqlCommand cmd2 = new SqlCommand(inserquery, DavidovaConnectionString);
                DavidovaConnectionString.Open();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Мебель успешна добавлена!");
                DavidovaConnectionString.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }
    }
}
