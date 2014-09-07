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
    using System.Windows.Shapes;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        private MongoRepository repo;
        private string user;
        private DispatcherTimer timer;

        public ChatWindow(string user)
        {
            InitializeComponent();
            this.repo = new MongoRepository();
            this.user = user;
            this.LoadChatMessages();
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1);
            this.timer.Start();
            this.timer.Tick += new EventHandler(OnTimeElapsed);
        }

        private void OnTimeElapsed(object sender, EventArgs e)
        {
            this.LoadChatMessages();
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            var text = msgText.Text;
            repo.GetCollection<Message>("Messages")
                .Insert(new Message()
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Date = DateTime.Now,
                    Text = text,
                    User = new User()
                    {
                        Username = this.user
                    }
                });
            msgText.Text = string.Empty;
            this.LoadChatMessages();
        }

        private void LoadChatMessages()
        {
            var all = repo.GetCollection<Message>("Messages").FindAll();
            this.chat.Items.Clear();
            foreach (var msg in all)
            {
                this.chat.Items.Add(msg);
            }
            if (this.chat.Items.Count > 0)
            {
                this.chat.ScrollIntoView(this.chat.Items[this.chat.Items.Count - 1]);
            }
        }

    }
}
