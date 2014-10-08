using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school
{
    public class Classes : Comments
    {
        private String textIdentifier;
        private List<Teachers> teachers;
        private List<Students> students;
        public String TextIdentifier
        {
            get { return textIdentifier; }
            set { textIdentifier = value; }
        }
        public List<Teachers> Teachers
        {
            get { return teachers; }
            set { teachers = value; }
        }
        public List<Students> Students
        {
            get { return students; }
            set { students = value; }
        }

        public void addComment(string freeTextComments)
        {
            
        }

        public string ShowComments()
        {
            String freeTextComments = "Place for comments for Classes";
            return freeTextComments;
        }
    }
}
