namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PhonebookFactory
    {
        public ICommandFactory GetCommandFactory()
        {
            return new CommandFactory();
        }

        public IRemovablePhonebookRepository GetPhonesRepository()
        {
            return new PhonebookRepository(this.GetPhonesDatabase());
        }

        private IRemovabaleDatabase GetPhonesDatabase()
        {
            return new PhoneDatabase();
        }
    }
}
