using System;
using System.Collections.Generic;
using System.Linq;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getcardNum()
    {

        return cardNum;
    }

    public void setcardNum(String newCardNum)
    {

        cardNum = newCardNum;
    }
    public double getPin()
    {

        return pin;
    }

    public void setPin(int newPin)
    {

        pin = newPin;
    }
    public String getFirstName()
    {

        return firstName;
    }

    public void setFirstName(String newFirstName)
    {

        firstName = newFirstName;
    }

    public String getLastName()
    {

        return lastName;
    }

    public void setLastName(String newLastName)
    {

        firstName = newLastName;
    }

    public double getBalance() {

        return balance;
    }

    public void setBalance(double newBalance) {

        balance = newBalance;
    }


    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder user)
        {
            Console.WriteLine("How much money would you like to deposit");
            double depo = double.Parse(Console.ReadLine());
            user.setBalance(user.getBalance() + depo);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + user.getBalance());
        }

        void withdraw(cardHolder user)
        {
            Console.WriteLine("How much money would you like to withdraw");
            double withdrawal = double.Parse(Console.ReadLine());
            //Check if user has enough money
            if (user.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient Funds :(");
            }
            else
            {
                user.setBalance(user.getBalance() - withdrawal);
                Console.WriteLine("Have a great day");
            }
        }

        void balance(cardHolder user)
        {
            Console.WriteLine("Current balance: " + user.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4455778811222233", 1234, "John", "Taylor", 167.31));
        cardHolders.Add(new cardHolder("4455778811222231", 1244, "Tim", "Taylor", 167.35));

        //Prompt user
        Console.WriteLine("Welcome to myATM");
        Console.WriteLine("Insert debit card");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against cardHolder db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized."); }
            }
            catch
            {
                { Console.WriteLine("Card not recognized."); };
            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against cardHolder db
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("PIN not recognized."); }
            }
            catch
            {
                { Console.WriteLine("PIN not recognized."); };
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Have a great day!");
    }

}

