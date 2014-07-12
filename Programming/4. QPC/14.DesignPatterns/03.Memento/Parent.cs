namespace BinarySerialization
{
    using System;

    [Serializable]
    public class Parent
    {
        public Parent(string name, bool isMale)
        {
            this.Name = name;
            this.IsMale = isMale;
        }

        public string Name { get; set; }

        public bool IsMale { get; set; }

        public override string ToString()
        {
            return (this.IsMale ? "father: " : "mother: ") + this.Name;
        }
    }
}
