namespace Phonebook
{
    using System.Text;

    public abstract class Command : ICommand
    {
        private const string DefaultCountryCode = "+359";

        public abstract string Execute(IRemovablePhonebookRepository repository);

        protected string NormalizePhoneNumber(string phoneNumber)
        {
            StringBuilder normalizedNumber = new StringBuilder();
            foreach (char symbol in phoneNumber)
            {
                if (char.IsDigit(symbol) || (symbol == '+'))
                {
                    normalizedNumber.Append(symbol);
                }
            }

            if (normalizedNumber.Length >= 2 && normalizedNumber[0] == '0' && normalizedNumber[1] == '0')
            {
                normalizedNumber.Remove(0, 1);
                normalizedNumber[0] = '+';
            }

            while (normalizedNumber.Length > 0 && normalizedNumber[0] == '0')
            {
                normalizedNumber.Remove(0, 1);
            }

            if (normalizedNumber.Length > 0 && normalizedNumber[0] != '+')
            {
                normalizedNumber.Insert(0, DefaultCountryCode);
            }

            return normalizedNumber.ToString();
        }
    }
}
