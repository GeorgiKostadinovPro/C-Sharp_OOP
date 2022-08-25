using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] accountInfo = input[i]
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                int accountNumber = int.Parse(accountInfo[0]);
                double accountBalance = double.Parse(accountInfo[1]);

                bankAccounts.Add(accountNumber, accountBalance);
            }

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                int accountNumber = int.Parse(cmdArgs[1]);
                double sum = double.Parse(cmdArgs[2]);

                try
                {
                    if (cmd == "Deposit")
                    {
                        bankAccounts[accountNumber] += sum;
                    }
                    else if (cmd == "Withdraw")
                    {
                        if (sum > bankAccounts[accountNumber])
                        {
                            throw new OverflowException("Insufficient balance!");
                        }

                        bankAccounts[accountNumber] -= sum;
                    }
                    else 
                    {
                        throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}