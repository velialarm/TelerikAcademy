using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace school
{
    public class Teachers : People, Comments
    {
        private List<Disciplines> disciplines;

        public List<Disciplines> Disciplines
        {
            get { return disciplines; }
            set { disciplines = value; }
        }

        public Teachers()
        {
            
        }


        public void addComment(string freeTextComments)
        {
           
        }

        public string ShowComments()
        {
            String freeTextComments = "Place for comments for Teachers";
            return freeTextComments;
        }
    }
}
