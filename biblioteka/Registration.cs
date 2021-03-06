﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace biblioteka
{
    public partial class Registration : FormPrimary
    {
       // SqlConnection connection;
        string connectionString;

        public Registration()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["biblioteka.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.userBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void Registration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.UserTable' table. You can move, or remove it, as needed.
            this.userTableTableAdapter.Fill(this.database1DataSet.UserTable);

        }

        private void buttonInsterRegistration_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string query = "INSERT INTO UserTable VALUES (@UserName, @Pass, @FirstName, @SecondName, @City, @email, 0)";

            //    using (connection = new SqlConnection(connectionString))
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            //    {
            //        command.Parameters.AddWithValue("@UserName", textBoxLogin.Text);
            //        command.Parameters.AddWithValue("@Pass", textBoxPassword.Text);
            //        command.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
            //        command.Parameters.AddWithValue("@SecondName", textBoxSecondName.Text);
            //        command.Parameters.AddWithValue("@City", textBoxCity.Text);
            //        command.Parameters.AddWithValue("@email", textBoxEmail.Text);


            //        DataTable userTable = new DataTable();
            //        dataAdapter.Fill(userTable);

            //        dataAdapter.Update(userTable);        // update database.
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            RegisterUser();
        }

        private void RegisterUser()
        {
            string userName = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxSecondName.Text;
            string city = textBoxCity.Text;
            string email = textBoxEmail.Text;

            try
            {
                User user = new User(userName, password, firstName, lastName, city, email);
                user.RegisterUser();

                MessageBox.Show("Registration completed. Welcome in our library.");

                user.LoginUser();

                this.Hide();
                FormLoggedBooks bio = new FormLoggedBooks();
                bio.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void buttonGoToMainPage_Click(object sender, EventArgs e)
        {
            this.goToSignInForm();
        }
    }
}
