using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace WorkingWithRemoteDB
{
    public partial class INSERT : Form
    {
        private SqlConnection SqlConnection = null;

        public INSERT(SqlConnection connection)
        {
            InitializeComponent();

            SqlConnection = connection;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand insertStudentComand = new SqlCommand("INSERT INTO [Students] (Name, Surname, Birthday) VALUES(@Name, @Surname, @Birthday)", SqlConnection);

            insertStudentComand.Parameters.AddWithValue("Name", textBox1.Text);
            insertStudentComand.Parameters.AddWithValue("Surname", textBox2.Text);
            insertStudentComand.Parameters.AddWithValue("Birthday", Convert.ToDateTime(textBox3.Text));

            try
            {
                await insertStudentComand.ExecuteNonQueryAsync();

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
