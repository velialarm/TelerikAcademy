namespace DictionaryHashTableAndSetHW
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ContactAddressUtil
    {
        private static MultiDictionary<string, ContactAddress> byName =
        new MultiDictionary<string, ContactAddress>(true);

        private static MultiDictionary<Tuple<string, string>, ContactAddress> byNameAndTown =
            new MultiDictionary<Tuple<string, string>, ContactAddress>(true);

        public static void Add(string name, string town, string phone)
        {
            var entry = new ContactAddress(name, town, phone);

            var nameAndTown = new Tuple<string, string>(entry.Name, entry.Town);

            byName.Add(name, entry);
            byNameAndTown.Add(nameAndTown, entry);
        }

        public static IEnumerable<ContactAddress> Find(string name)
        {
            return byName[name];
        }

        public static IEnumerable<ContactAddress> Find(string name, string town)
        {
            var nameAndTown = new Tuple<string, string>(name, town);

            return byNameAndTown[nameAndTown];
        }
    }
}
