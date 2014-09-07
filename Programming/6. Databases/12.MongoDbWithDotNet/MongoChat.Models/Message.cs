namespace MongoChat.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return "[" + Date + "] " + User.Username + " : " + Text;
        }
    }
}
