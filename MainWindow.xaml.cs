using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TestDB
{

    public partial class MainWindow : Window
    {

        SqliteConnection _connection;

        public MainWindow()
        {
            InitializeComponent();

            _connection = new SqliteConnection("Data Source=contact-manager.db");
            _connection.Open();

            diplayUserData();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtCommandName.Text != string.Empty && txtCommandEmail.Text != string.Empty && txtCommandAge.Text != string.Empty)
            {
                string command = $"INSERT INTO Users (Name, Email, Age) VALUES ('{txtCommandName.Text}', '{txtCommandEmail.Text}', '{txtCommandAge.Text}')";

                txtCommandName.Text = string.Empty;
                txtCommandEmail.Text = string.Empty;
                txtCommandAge.Text = string.Empty;

                var cmd = new SqliteCommand(command, _connection);
                cmd.ExecuteNonQuery();

                diplayUserData();
            }
            else
            {
                int fieldCount = 0;
                bool haveName = true;
                bool haveEmail = true;
                bool haveAge = true;

                if (txtCommandName.Text == string.Empty)
                {
                    fieldCount += 1;
                    haveName = false;
                }

                if (txtCommandEmail.Text == string.Empty)
                {
                    fieldCount += 1;
                    haveEmail = false;
                }


                if (txtCommandAge.Text == string.Empty)
                {
                    fieldCount += 1;
                    haveAge = false;
                }

                StringBuilder emptyFields = new StringBuilder();
                if(fieldCount == 1)
                    emptyFields.Append("The field ");
                else
                    emptyFields.Append("The fields ");

                List<string> emptyFieldNames = new List<string>();

                if (!haveName)
                    emptyFieldNames.Add("'Name'");

                if (!haveEmail)
                    emptyFieldNames.Add("'Email'");

                if (!haveAge)
                    emptyFieldNames.Add("'Age'");

                if (emptyFieldNames.Count > 0)
                {
                    if (emptyFieldNames.Count == 1)
                    {
                        emptyFields.Append(emptyFieldNames[0]);
                    }
                    else
                    {
                        for (int i = 0; i < emptyFieldNames.Count - 1; i++)
                        {
                            emptyFields.Append(emptyFieldNames[i]);
                            emptyFields.Append(", ");
                        }
                        emptyFields.Append("and ");
                        emptyFields.Append(emptyFieldNames[emptyFieldNames.Count - 1]);
                    }

                    if (fieldCount == 1)
                        emptyFields.Append(" is empty");
                    else
                        emptyFields.Append(" are empty");
                    MessageBox.Show(emptyFields.ToString());
                }
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (txtCommandDelete.Text != string.Empty)
            {
                string userName = txtCommandDelete.Text;

                var deleteCmd = new SqliteCommand("DELETE FROM Users WHERE Name = @UserName", _connection);
                deleteCmd.Parameters.AddWithValue("@UserName", userName);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    diplayUserData();
                    txtCommandDelete.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show($"User '{userName}' not found or couldn't be deleted.", "Deletion Failed");
                }
            }
            else
            {
                MessageBox.Show("The 'Name' field is empty");
            }
        }

        public void diplayUserData()
        {
            var selectCmd = new SqliteCommand("SELECT * FROM Users", _connection);

            StringBuilder usersData = new StringBuilder();

            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string name = reader["Name"]?.ToString() ?? "N/A";
                    string email = reader["Email"].ToString() ?? "N/A";
                    string age = reader["Age"].ToString() ?? "N/A";

                    usersData.AppendLine($"Name: {name}, Email: {email}, Age: {age}");
                }
            }

            displayUsersText.Text = usersData.ToString();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (txtCommandSearch.Text != string.Empty)
            {
                string userName = txtCommandSearch.Text;

                var selectCmd = new SqliteCommand("SELECT * FROM Users WHERE Name = @UserName", _connection);
                selectCmd.Parameters.AddWithValue("@UserName", userName);

                StringBuilder userData = new StringBuilder();

                using (var reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"]?.ToString() ?? "N/A";
                        string email = reader["Email"].ToString() ?? "N/A";
                        string age = reader["Age"].ToString() ?? "N/A";

                        userData.AppendLine($"Name: {name}, Email: {email}, Age: {age}");
                    }
                }

                Info.Content = userData.ToString();
            }
            else
            {
                MessageBox.Show("Please enter a name to search.");
            }
        }
    }
}
    