namespace _8.ExtractAlbum
{
    using System.Collections.Generic;

    public class Album
    {
        private ICollection<string> authors;

        public Album()
        {
            this.authors = new List<string>();
        }

        public string Name { get; set; }

        public ICollection<string> Authors
        {
            get
            {
                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }
    }
}
