namespace _8.ExtractAlbum
{
    using System.Collections.Generic;

    public class Band
    {
        private ICollection<Album> albums;

        public Band()
        {
            this.albums = new List<Album>();
        }

        public string Name { get; set; }

        public ICollection<Album> Albums
        {
            get
            {
                return this.albums;
            }

            set
            {
                this.albums = value;
            }
        }
    }
}
