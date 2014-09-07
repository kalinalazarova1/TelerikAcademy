// 1. Research how to create a MongoDB database in Mongolab(http://mongolab.com )
// 2. Create a chat database in MongoLab
// The database should keep messages
// Each message has a text, date and an embedded field user
// Users have username
// 3. Create a Chat client, using the Chat MongoDB database
// When the client starts, it asks for username
// Without password
// Logged-in users can see 
// All posts, since they have logged in
// History of all posts
// Logged-in users can post message
// Create a simple WPF application for the client

// !!! Plese note that cloud database could not be accessed through Telerik Academy Network because of some limitations.
// Choose anothe network to run the application.

namespace MongoChat.WPF
{
    using Mongo.Data;
    using MongoChat.Models;
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonLoginClick(object sender, RoutedEventArgs e)
        {
            
            var current = this.username.Text;
            while(string.IsNullOrWhiteSpace(current))
            {
                MessageBox.Show("Invalid user name. Please try again.");
            }

            var chatControl = new ChatWindow(current);
            this.Close();
            chatControl.ShowDialog();
        }
    }
}
