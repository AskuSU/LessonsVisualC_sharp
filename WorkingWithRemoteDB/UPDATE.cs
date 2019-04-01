using System;

using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WorkingWithRemoteDB
{
    public partial class UPDATE : Form
    {
        private SqlConnection sqlConnection = null;

        private int id;


        public UPDATE(SqlConnection connection, int id)
        {
            InitializeComponent();

            sqlConnection = connection;

            this.id = id;
        }

        private async void UPDATE_Load(object sender, EventArgs e)
        {
            SqlCommand getStudentInfoCommand = new SqlCommand("SELECT [Name], [Surname], [Birthday] FROM [Students] WHERE [Id]=@Id", sqlConnection);

            getStudentInfoCommand.Parameters.AddWithValue("Id", id);

            SqlDataReader sqlReader = null;

            try
            {
                sqlReader = await getStudentInfoCommand.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    textBox1.Text = Convert.ToString(sqlReader["Name"]);

                    textBox2.Text = Convert.ToString(sqlReader["Surname"]);

                    textBox3.Text = Convert.ToString(sqlReader["Birthday"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand updateStudentComand = new SqlCommand("UPDATE [Students] SET [Name]=@Name, [Surname]=@Surname, [Birthday]=@Birthday WHERE [Id]=@Id",sqlConnection);

            updateStudentComand.Parameters.AddWithValue("Id", id);
            updateStudentComand.Parameters.AddWithValue("Name", textBox1.Text);
            updateStudentComand.Parameters.AddWithValue("Surname", textBox2.Text);
            updateStudentComand.Parameters.AddWithValue("Birthday", Convert.ToDateTime(textBox3.Text));

            try
            {
                await updateStudentComand.ExecuteNonQueryAsync();

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
