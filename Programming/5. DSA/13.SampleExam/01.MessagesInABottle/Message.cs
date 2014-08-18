namespace _01.MessagesInABottle
{
    public class Message
    {
        public Message(string original, string decoded)
        {
            this.Original = original;
            this.Decoded = decoded;
        }

        public string Original { get; set; }

        public string Decoded { get; set; }
    }
}
