// 2. Refactor the following examples to produce code with well-named identifiers in C#:

public static class HumanFactory
{
    public enum Gender 
    {
        Male, Female
    }

    public static Human CreateHuman(int age)
    {
        Human newHuman = new Human();
        newHuman.Age = age;
        if (age % 2 == 0)
        {
            newHuman.Name = "Батката";
            newHuman.Gender = Gender.Male;
        }
        else
        {
            newHuman.Name = "Мацето";
            newHuman.Gender = Gender.Female;
        }

        return newHuman;
    }

    public class Human
    {
        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}