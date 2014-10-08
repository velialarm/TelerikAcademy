using System;
using System.Text;

namespace _3DSystem
{
    class GenericList<T> where T: IComparable
    {
        //Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
        //Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
        //Implement methods for adding element, accessing element by index, removing element by index, 
        //inserting element at given position, clearing the list, finding element by its value and ToString(). 
        //Check all input parameters to avoid accessing elements at invalid positions

        private const int Capacity = 20;
        private T[] _list;
        private int _pos;

        public GenericList(int cap)
        {
            _list = new T[cap];
        }

        public T this[int index]
        {
            get { return _list[index]; }
            set { _list[index] = value; }
        }

        // methods
        public T Max()
        {
            dynamic maxElem = int.MinValue;
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i] > maxElem)
                {
                    maxElem = _list[i];
                }
            }

            return maxElem;
        }

        public T Min()
        {
            dynamic minElem = int.MaxValue;
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i] < minElem)
                {
                    minElem = _list[i];
                }
            }

            return minElem;
        }

        public void AddElement(T element)
        {
            if (_pos >= _list.Length)
            {
                // autogrow
                T[] newList = new T[_list.Length * 2];
                for (int i = 0; i < _list.Length; i++)
                {
                    newList[i] = _list[i];
                }

                _pos++;
                newList[_list.Length] = element;
                _list = newList;
            }
            else
            {
                _list[_pos] = element;
                _pos++;
            }
        }

        public void RemoveElemAtIndex(int index)
        {
            if (index < _list.Length)
            {
                T[] newList = new T[_list.Length - 1];
                bool beforeRem = true;

                for (int i = 0; i < _list.Length - 1; i++)
                {
                    if (i == index)
                    {
                        beforeRem = false;
                    }

                    if (beforeRem)
                    {
                        newList[i] = _list[i];
                    }
                    else
                    {
                        newList[i] = _list[i + 1];
                    }
                }

                _list = newList;
            }
            else
            {
                Console.WriteLine("Outside the array");
            }
        }

        public void InsertElemAtIndex(int index, T element)
        {
            if (index < _list.Length)
            {
                T[] newList = new T[_list.Length + 1];
                bool beforeRem = true;

                for (int i = 0; i < _list.Length + 1; i++)
                {
                    if (i == index)
                    {
                        beforeRem = false;
                        newList[i] = element;
                        continue;
                    }

                    if (beforeRem)
                    {
                        newList[i] = _list[i];
                    }
                    else
                    {
                        newList[i] = _list[i - 1];
                    }
                }

                _list = newList;
            }
            else
            {
                Console.WriteLine("Outside the array");
            }
        }

        public int Length()
        {
            return _list.Length;
        }

        public void ClearList()
        {
            _list = new T[1];
        }

        public int FindElemByValue(T value)
        {
            int indexFound = -1;

            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i].Equals(value))
                {
                    indexFound = i;
                    break;
                }
            }

            return indexFound;
        }

        public override string ToString()
        {
            StringBuilder endText = new StringBuilder();
            foreach (var item in _list)
            {
                endText.AppendFormat("{0} ", item);
            }

            return endText.ToString().Trim();
        }
    }
}
