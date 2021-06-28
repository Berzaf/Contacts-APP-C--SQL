using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Contact_App
{
    public partial class Form1 : Form
    {
        private MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)

        {
            string cn = @"server=localhost;user=root;password=Elora@3030;database=contactinfo";

            MySqlConnection con = new MySqlConnection(cn);

            con.Open();

            // create sql Query
            string sql = "INSERT INTO contactDB (firstName, lastName, phoneNumber, email, address) VALUES (@firstName, @lastName, @phoneNumber, @email, @address)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            // create paramters
            cmd.Parameters.AddWithValue("@contactID", textBoxContactId.Text);
            cmd.Parameters.AddWithValue("@firstName", textBoxFname.Text);
            cmd.Parameters.AddWithValue("@lastName", textBoxLname.Text);
            cmd.Parameters.AddWithValue("@phoneNumber", textBoxPnum.Text);
            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
            cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Added");


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cn = @"server=localhost;user=root;password=Elora@3030;database=contactinfo";

            MySqlConnection con = new MySqlConnection(cn);

            con.Open();

            // update sql Query
            string sql = "UPDATE contactDB set firstName=@firstName, lastName=@lastName, phoneNumber=@phoneNumber, email=@email, address=@address where contactID=@contactID";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            // update paramters
            cmd.Parameters.AddWithValue("@contactID", textBoxContactId.Text);
            cmd.Parameters.AddWithValue("@firstName", textBoxFname.Text);
            cmd.Parameters.AddWithValue("@lastName", textBoxLname.Text);
            cmd.Parameters.AddWithValue("@phoneNumber", textBoxPnum.Text);
            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
            cmd.Parameters.AddWithValue("@address", textBoxAddress.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string cn = @"server=localhost;user=root;password=Elora@3030;database=contactinfo";

            MySqlConnection con = new MySqlConnection(cn);

            con.Open();

            // delete sql Query
            string sql = "DELETE from contactDB where contactID=@contactID";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            // update paramters
            cmd.Parameters.AddWithValue("@contactID", textBoxContactId.Text);
           
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfuly Deleted");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            string cn = @"server=localhost;user=root;password=Elora@3030;database=contactinfo";

            MySqlConnection con = new MySqlConnection(cn);

            con.Open();

            // delete sql Query
            string sql = "SELECT * FROM contactDB";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            // update paramters
            //cmd.Parameters.AddWithValue("contactID", textBoxSearch.Text);

            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgvContacts.DataSource = dt;
            dgvContacts.Visible = true;


            MessageBox.Show("Successfuly Searched");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cn = @"server=localhost;user=root;password=Elora@3030;database=contactinfo";

            MySqlConnection con = new MySqlConnection(cn);

            con.Open();

            // delete sql Query
            string sql = "SELECT * FROM contactDB";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dgvContacts.DataSource = dt;

            con.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }
    }
}
