using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        string Server = "localhost";
        string Uid = "root";
        string Password = "R@ss0512";
        string database = "company";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=company;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from Customers";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=company;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "INSERT INTO Customers (CustomerName,ContactName, Address, City) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=company;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "update company.Customers set CustomerName='" + textBox1.Text + "',ContactName='" + textBox2.Text + "',Address='" + textBox3.Text + "',City='" + textBox4.Text + "' where CustomerName= '" + textBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=company;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "Delete from company.Customers where CustomerName ='" + textBox1.Text + "'";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            if ("CustomerName" !=query)
            {
                MessageBox.Show("there is no name to delete");
            }
            cnn.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=company;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            
            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM company.Customers WHERE CustomerName =" + textBox5.Text,cnn);
                DataTable search = new DataTable();
                using(MySqlDataAdapter adapter =new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(search);
                }
                dataGridView1.DataSource = search;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(ex.Message));
            }
        }
    } 
}
