//A bank account has a holder name, balance, bank name, IBAN, BIC and three credit cards numbers
//declare the variables needed to keep the information for a single bank account

using System;

class BankAccountData
{
    static void Main()
    {
        string firstName = "Kiril";
        string middleName = "Bankov";
        string familyName = "Georgiev";
        decimal saldo = 234.54m;
        string bankName = "Procreditbank";
        string accIBAN = "BG04PRCB92301042624316";
        string accBIC = "PRCBBGSF";
        ulong creditCard1 = 4260820008197126;
        ulong creditCard2 = 4260813452171135;
        ulong creditCard3 = 4260820017331522;
        Console.WriteLine("Client: {0} {1} {2}", firstName, middleName, familyName);
        Console.WriteLine("Bank: {0}, BIC: {1}, IBAN: {2}", bankName, accBIC, accIBAN);
        Console.WriteLine("Saldo: {0:C}", saldo);
        Console.WriteLine("Credit cards: {0}, {1}, {2}", creditCard1, creditCard2, creditCard3);
    }
}
