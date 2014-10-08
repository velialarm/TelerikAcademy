using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, mobile phone e-mail, course, 
 * specialty, university, faculty. Use an enumeration for the specialties, universities and faculties. 
 * Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

 */
class Student : Person, ICloneable, IComparable<Student>
{

    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string CourseSpecialty { get; private set; }
    public string University { get; private set; }
    public string Faculty { get; private set; }

    public Student(string firstName, string middleName, string lastName, string socialSecurityNumber, string address = "", string email = "", string phone = "", string courseSpecialty = "", string university = "", string faculty = "")
        : base(firstName, middleName, lastName, socialSecurityNumber, age: null)
    {
        this.Address = address;
        this.Email = email;
        this.Phone = phone;

        this.CourseSpecialty = courseSpecialty;
        this.University = university;
        this.Faculty = faculty;
    }
    /**
     * 2. Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student.
     */
    public object Clone()
    {
        return new Student(
            this.FirstName, this.MiddleName, this.LastName,
            this.SocialSecurityNumber,
            this.Address, this.Email, this.Phone,
            this.CourseSpecialty, this.University, this.Faculty
        );
    }
    /**
     * 3. Implement the  IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order) 
     * and by social security number (as second criteria, in increasing order).
     */
    public int CompareTo(Student other)
    {
        if (Student.Equals(this, other)) return 0;

        return Student.Equals
            (
                new Student[] { this, other }
                    .OrderBy(student => student.FirstName)
                    .ThenBy(student => student.MiddleName)
                    .ThenBy(student => student.LastName)
                    .ThenBy(student => student.SocialSecurityNumber)
                    .First(), this
            ) ? -1 : 1;
    }

    public override bool Equals(object obj)
    {
        return this.SocialSecurityNumber == (obj as Student).SocialSecurityNumber;
    }

    public override int GetHashCode()
    {
        return SocialSecurityNumber.GetHashCode();
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine(base.ToString());

        if (!String.IsNullOrEmpty(this.Address))
        {
            info.AppendLine("Address: " + this.Address);
        }
        if (!String.IsNullOrEmpty(this.Email))
        {
            info.AppendLine("Email: " + this.Email);
        }
        if (!String.IsNullOrEmpty(this.Phone))
        {
            info.AppendLine("Phone: " + this.Phone);
        }
        if (!String.IsNullOrEmpty(this.CourseSpecialty))
        {
            info.AppendLine("Course Specialty: " + this.CourseSpecialty);
        }
        if (!String.IsNullOrEmpty(this.University))
        {
            info.AppendLine("University: " + this.University);
        }
        if (!String.IsNullOrEmpty(this.Faculty))
        {
            info.AppendLine("Faculty: " + this.Faculty);
        }
        return info.ToString().TrimEnd();
    }
}

