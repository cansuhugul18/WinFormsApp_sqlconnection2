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
using MySql.Data.MySqlClient;



namespace WinFormsApp_sqlconnection2
{
    public partial class Form1 : Form
    {
        MySqlConnection myConnection;
        public Form1()
        {
            InitializeComponent();

            myConnection = new MySqlConnection("Server=localhost;Database=my_schema;Uid=root;Pwd=Chbcd12012018;"); // trusted connection  da olabilir.
            myConnection.Open();
            label1.Text = myConnection.State.ToString();
           // myConnection.Close();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand com;
            DataSet ds = new DataSet();

            using (com = myConnection.CreateCommand())
            {
                com.CommandText = ("INSERT INTO kisiler(kisi_id, kisi_adi) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')");
                label1.Text = "" + com.ExecuteNonQuery();
                string selectquery = "SELECT * FROM kisiler";
                adapter.SelectCommand = new MySqlCommand(selectquery, myConnection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //güncelleme
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand com;
            DataSet ds = new DataSet();
           
          
            using (com = myConnection.CreateCommand())
            {
                com.CommandText= "UPDATE kisiler SET kisi_adi='" + textBox2.Text + "' WHERE kisi_id='" + textBox1.Text + "'";
                label1.Text = "" + com.ExecuteNonQuery();

                string selectquery = "SELECT * FROM kisiler";
                adapter.SelectCommand = new MySqlCommand(selectquery, myConnection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        { // silme
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand com;
            DataSet ds = new DataSet();

            using (com = myConnection.CreateCommand())
            {
                com.CommandText = ("DELETE FROM kisiler where kisi_adi= '"+textBox2.Text +"'");
                label1.Text = "" + com.ExecuteNonQuery();

                string selectquery = "SELECT * FROM kisiler";
                adapter.SelectCommand = new MySqlCommand(selectquery, myConnection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand com;
            DataSet ds = new DataSet();
            using (com = myConnection.CreateCommand())
            {
                com.CommandText = ("select * from kisiler");
                label1.Text = "" + com.ExecuteNonQuery();

                string selectquery = "SELECT * FROM kisiler";
                adapter.SelectCommand = new MySqlCommand(selectquery, myConnection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
