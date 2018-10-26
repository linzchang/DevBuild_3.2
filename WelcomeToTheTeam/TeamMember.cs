using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheTeam
{
    class TeamMember : Person
    {
        #region Properties
        public double Salary { get; set; }
        public string Address { get; set; }
        public static List<TeamMember> teamMembers = new List<TeamMember>();
        #endregion

        #region Constructor
        public TeamMember(string firstName, string lastName, string emailAddress, int age,  string address, double salary) : base(firstName, lastName, emailAddress, age)
        {
            Address = address;
            Salary = salary;
        }
        #endregion

        #region Methods
        //I tried to set AddToList to virtual in the Person class, and override it here in the Team Member class, but it said their was "No Suitable method found to override"
        public void AddToList(string FirstName, string LastName, string EmailAddress, int Age, double Salary)
        {
            IsAnAdult(Age);

            if (_isAnAdult)
            {
                teamMembers.Add(this);
                Console.WriteLine($"{this.FirstName} {this.LastName} was successfully added to the list.");
            }
            else
            {
                Console.WriteLine("A Person must be over 18 years old to be added to the list.");
            }
        }

        //I also hoped to override the ViewList method from Person class here but I couldn't since it was static
        //For it to work I had to make this a static method and make my list static also
        public static void ViewList(List<TeamMember> teamMembers)
        {
            foreach (var person in teamMembers)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} is a Team Member. " +
                    $"\nEmail: {person.EmailAddress} \nAge: {person.Age} \nAddress: {person.Address} \nSalary: {person.Salary}");
            }
        }
        #endregion
    }
}
