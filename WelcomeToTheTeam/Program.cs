using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WelcomeToTheTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's create a list of people!");
            MainMenu();
        }

        public static void MainMenu()
        {
            string firstName, lastName, emailAddress, address;
            int age;
            double salary;

            while (true)
            {
                string switchAnswer = GetResponse("Would you like to: \n1) Add a Person \n2) Add a Team Member");

                switch (switchAnswer)
                {
                    case "1":
                        Console.WriteLine("You selected add a person. \nPlease provide the following information for the person:");
                        firstName = GetName("Enter a first name: ");
                        lastName = GetName("Enter a last name: ");
                        emailAddress = GetEmail("Enter an email address: ");
                        age = GetAge("Enter an age: ");
                        Person person1 = new Person(firstName, lastName, emailAddress, age);
                        person1.AddToList(firstName, lastName, emailAddress, age);
                        string answer = GetResponse("Would you like to view the list? \nType Y to view the list.");
                        if (answer.ToUpper() != "Y")
                        {
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("List of people:");
                            Person.ViewList(Person.adults);
                        }
                        break;
                    case "2":
                        Console.WriteLine("You selected add a team member.  \nPlease provide the following information for the Team Member:");
                        firstName = GetName("Enter a first name: ");
                        lastName = GetName("Enter a last name: ");
                        emailAddress = GetEmail("Enter an email address: ");
                        age = GetAge("Enter an age: ");
                        address = GetResponse("Enter an address: ");
                        salary = GetSalary("Enter a salary: ");
                        TeamMember teamMember1 = new TeamMember(firstName, lastName, emailAddress, age, address, salary);
                        teamMember1.AddToList(firstName, lastName, emailAddress, age, salary);
                        string viewList = GetResponse("Would you like to view the list? \nType Y to view the list.");
                        if (viewList.ToUpper() != "Y")
                        {
                            MainMenu();
                        }
                        else
                        {
                            Console.WriteLine("List of Team Members:");
                            TeamMember.ViewList(TeamMember.teamMembers);
                        }
                        break;
                    default:
                        Console.WriteLine("That is not a valid selection, try again.");
                        continue;
                }

                Console.WriteLine(" ");
                string endProgram = GetResponse("Would you like to continue to the main menu?  Press Y to continue");
                if (endProgram.ToUpper() != "Y")
                {
                    break;
                }
                Console.Clear();
            }
        }

        public static string GetResponse(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();

        }

        public static string GetName(string message)
        {
            Console.WriteLine(message);
            string answer = Console.ReadLine();

            while (true)
            {
                if (Regex.IsMatch(answer, @"[0-9]"))
                {
                    answer = GetName($"{answer} is not a valid input, please do not enter any numbers or symbols.");
                    continue;
                }
                else
                {
                    return answer;
                }
            }
        }

        public static int GetAge(string message)
        {
            int number;

            while (true)
            {
                Console.Write(message);
                bool parsed = int.TryParse(Console.ReadLine(), out number);
                if (!parsed || number < 1)
                {
                    Console.WriteLine("That is not a valid age, please enter a positive number over 0.");
                }
                else
                {
                    return number;
                }
            }
        }

        public static string GetEmail(string message)
        {
            Console.WriteLine(message);
            string userEmail = Console.ReadLine();

            while (true)
            {
                if (!Regex.IsMatch(userEmail, @"^[a-zA-Z0-9]{3,30}@[a-zA-Z0-9]{2,10}.[a-z]{2,3}$"))
                {
                    userEmail = GetEmail("That is not a valid email, please try again.  Format: joesmith@aol.com");
                    continue;
                }
                else
                {
                    return userEmail;
                }
            }
        }

        public static double GetSalary(string message)
        {
            double number;

            while (true)
            {
                Console.Write(message);
                bool parsed = double.TryParse(Console.ReadLine(), out number);
                if (!parsed || number < 0)
                {
                    Console.WriteLine("That is not a valid salary, please enter a positive number.");
                }
                else
                {
                    return number;
                }
            }
        }
    }
}
