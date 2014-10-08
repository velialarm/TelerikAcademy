namespace _01MobilePhones
{
    class Display
    {
        private int _size;

        private int _numCollors;


        public Display(int size, int colors)
        {
            _numCollors = colors;
            _size = size;
        }
        
        public int SizeDisplay
        {
            get { return _size; }
            set { _size = value; }
        }

        public int NumCollors
        {
            get { return _numCollors; }
            set { _numCollors = value; }
        }
    }
}
