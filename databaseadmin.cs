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
    public partial class databaseadmin : Form
    {
        public databaseadmin()
        {
            InitializeComponent();
        }

        private void databaseadmin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Databases databases = new Databases();
            databases.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=railway;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            
            string query = "INSERT INTO passenger (Passenger_ID,first_name, last_name, address) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "')";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=railway;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "Delete from railway.passenger where Passenger_ID ='" + textBox2.Text + "'";
            
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
 
            cnn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=railway;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();

            string query = "update railway.passenger set Passenger_ID='" + textBox2.Text + "',first_name='" + textBox3.Text + "',last_name='" + textBox4.Text + "',address='" + textBox6.Text + "' where Passenger_ID= '" + textBox2.Text +"'";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=railway;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string query = "select * from passenger";
            MySqlCommand cmd = new MySqlCommand(query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand(query, cnn);
            DataTable dt = new DataTable();
            dt.Load(reader);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            MySqlConnection cnn;
            connetionString = "server=localhost;database=railway;uid=root;pwd=R@ss0512;";
            cnn = new MySqlConnection(connetionString);

            try
            {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM railway.passenger WHERE Passenger_ID =" + textBox5.Text, cnn);
                DataTable search = new DataTable();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
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
