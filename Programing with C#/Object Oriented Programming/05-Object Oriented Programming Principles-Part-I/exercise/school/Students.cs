using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school
{
    public class Students : People, Comments
    {
        private int classNumber;

        public int ClassNumber
        {
            get { return classNumber; }
            set { classNumber = value; }
        }
        public void addComment(string freeTextComments)
        {

        }

        public string ShowComments()
        {
            String freeTextComments = "Place for comments for Students";
            return freeTextComments;
        }
    }
}
