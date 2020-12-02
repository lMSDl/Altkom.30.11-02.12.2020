using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Indexers
{
    public class Indexer
    {
        public class StringDataStore
        {
            private string[] store = new string[10];

            public string this[int index]
            {
                get
                {
                    if (index >= store.Length || index < 0)
                        return null;
                    return store[index];
                }
                set
                {
                    if (index < store.Length && index >= 0)
                         store[index] = value;
                }
            }

            public int this[string data]
            {
                get
                {
                    return store.ToList().IndexOf(data);
                }
            }


            public void SetString(int index, string value)
            {
                store[index] = value;
            }

            public string GetString(int index, string value)
            {
                return store[index];
            }
        }

        public void Test()
        {
            var dataStore = new[] { new StringDataStore(), new StringDataStore() };
            dataStore[0].SetString(0, "1");
            dataStore[0].SetString(1, "two");
            dataStore[0].SetString(2, "III");

            dataStore[0][3] = "4";
            dataStore[0][4] = "five";
            dataStore[0][5] = "VI";

            for(int i = 0; i < 10; i++)
                Console.WriteLine(dataStore[0][i]);

            var index = dataStore[0]["five"];
            Console.WriteLine(index);
           
        }

    }
}
