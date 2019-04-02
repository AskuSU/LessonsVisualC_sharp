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
using System.Configuration;



namespace WorkingWithRemoteDB
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {

                string connectionString = ConfigurationManager.ConnectionStrings["StudentsCS"].ConnectionString;
                //string connectionString = @"Server = localhost\SQLEXPRESS; Database = TestDB; Trusted_Connection = True;";

                sqlConnection = new SqlConnection(connectionString);

                await sqlConnection.OpenAsync();

                listView1.GridLines = true;

                listView1.FullRowSelect = true;

                listView1.View = View.Details;

                listView1.Columns.Add("Id");
                listView1.Columns.Add("Name");
                listView1.Columns.Add("Surname");
                listView1.Columns.Add("Birthday");

                await LoadStudentsAsync();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async Task LoadStudentsAsync() //SELECT
        {
            SqlDataReader sqlReader = null;

            SqlCommand getStudentsComand = new SqlCommand("SELECT * FROM [Students]", sqlConnection);

            try
            {
                sqlReader = await getStudentsComand.ExecuteReaderAsync();

                while(await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["Id"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Surname"]),
                        Convert.ToString(sqlReader["Birthday"]),

                    });

                    listView1.Items.Add(item);
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

        private async void toolStripButton5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            await LoadStudentsAsync();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //INSERT
        {
            INSERT insert = new INSERT(sqlConnection);

            insert.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                UPDATE update = new UPDATE(sqlConnection, Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));

                update.Show();
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {

                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                switch (res)
                {
                    case DialogResult.OK:

                        SqlCommand deleteStudentCommand = new SqlCommand("DELETE FROM [Students] WHERE [Id]=@Id", sqlConnection);

                        deleteStudentCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));

                        try
                        {
                            await deleteStudentCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        listView1.Items.Clear();

                        await LoadStudentsAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
