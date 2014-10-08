using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school
{
    public class Disciplines : Comments
    {
        private String name;
        private int numLectures;
        private int numExercises;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NumLectures
        {
            get { return numLectures; }
            set { numLectures = value; }
        }
        public int NumExercises
        {
            get { return numExercises; }
            set { numExercises = value; }
        }

        public void addComment(string freeTextComments)
        {
            
        }

        public string ShowComments()
        {
            String freeTextComments = "Place for comments for Disciplines";
            return freeTextComments;
        }
    }
}
