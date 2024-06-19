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

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        DataBase dataBase = new DataBase();
        public Form10()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var book_id = textBox1.Text;
            var reader_id = textBox2.Text;
            var vidacha = textBox3.Text;
            var bron = textBox4.Text;
            int vozvrat;

            if (int.TryParse(textBox5.Text, out vozvrat))
            {
                var addQuery = $"insert into _db (Шифр книги, Номер карточки, Дата выдачи, Код брони, Дата возврата) values ('{book_id}', '{reader_id}', '{vidacha}', '{bron}', '{vozvrat}')";

                var command = new SqlCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Запись должна иметь цифровой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            dataBase.closeConnection();
        }
    }
}
