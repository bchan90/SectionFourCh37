using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionFourCh37
{
  class Program
  {
    // class specific vaiables
    private static List<string> username;
    private static List<string> password;

    static void Main(string[] args)
    {
      // initialize variables
      username = new List<string>();
      password = new List<string>();

      // check if registering or logging in
      OptionInput();
    }

    public static void OptionInput()
    {
      // integrity check
      if (username.Count != password.Count)
      {
        Console.Clear();
        Console.WriteLine("A fatal error has been encountered. Please contact the administrator for further details.");
        Console.Read();
      }

      Console.WriteLine("Enter '1' to register a new account.\nPress '2' to log-in to an existing account.\nPress 'Enter' to exit.");
      CheckExisting(Console.ReadLine());
    }

    private static void CheckExisting(string _existing)
    {
      if (_existing.Equals(""))
      {
        return;
      }
      else if (_existing.Equals("2"))
      {
        Console.Write("Enter your username: ");
        CheckUsername(Console.ReadLine());
      }
      else if (_existing.Equals("1"))
      {
        RegisterNewUser();
      }
      else
      {
        Console.Clear();
        Console.WriteLine("Incorrect value entered. Please enter only either '1' or '2' as directed.");
        OptionInput();
      }
    }

    private static void CheckUsername(string nameInput)
    {
      if (username.Contains(nameInput))
      {
        Console.Write("User found. Please input your password: ");
        CheckPassword(Console.ReadLine(), username.IndexOf(nameInput));
      }
      else
      {
        Console.Clear();
        Console.WriteLine("Cannot find that username.");
        OptionInput();
      }
    }

    private static void CheckPassword(string passwordInput, int i)
    {
      if (password[i].Equals(passwordInput))
      {
        Console.WriteLine("Thank you {0}. You have successfully logged in to your account! Press 'Enter' to continue.", username[i]);
        Console.ReadKey();
        Console.Clear();
        OptionInput();
      }
      else
      {
        Console.Clear();
        Console.WriteLine("Sorry, the password entered did not match our records. Please try again.");
        OptionInput();
      }
    }

    private static void RegisterNewUser()
    {
      Console.Write("Enter your desired username: ");
      string userInput = Console.ReadLine();
      if (username.Contains(userInput))
      {
        Console.Clear();
        Console.WriteLine("Sorry, that username has already been taken. Please try again.");
        OptionInput();
      }
      else
      {
        username.Add(userInput);
        Console.Write("Your username is {0}\nPlease enter the password you would like to use for this account: ", userInput);
        password.Add(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Thank you. Your password has been stored. Log-in to your account with your credentials.\n");
        OptionInput();
      }
    }
  }
}
