using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Person
{
    public Person(string firstName,string middleName, string lastName, string socialSecurityNumber, int? age)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SocialSecurityNumber = socialSecurityNumber;
        this.Age = age;
    }

    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string  LastName { get; private set; }
    public string SocialSecurityNumber { get; private set; }
    public int? Age { get; private set; }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
        info.AppendLine();
        info.AppendLine("Social Security Number: " + this.SocialSecurityNumber);
        info.AppendLine("Age: " + (this.Age ?? -1));

        return info.ToString().TrimEnd();
    }


    

}

