using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryHashTableAndSetHW
{
    public class ContactAddress
    {
        public const string Separator = " | ";

        public ContactAddress(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name { get; private set; }

        public string Town { get; private set; }

        public string Phone { get; private set; }

        public override string ToString()
        {
            return string.Join(ContactAddress.Separator, this.Name, this.Town, this.Phone);
        }
    }
}
