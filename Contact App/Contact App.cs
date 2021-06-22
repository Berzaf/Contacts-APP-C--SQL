using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Contact_App
{
    public partial class Form1 : Form
    {
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
    }
}
