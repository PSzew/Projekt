using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class ClassModel
    {
        public class Info
        {
            public int timestamp { get; set; }
            public double rate { get; set; }
        }

        public class Query
        {
            public string from { get; set; }
            public string to { get; set; }
            public int amount { get; set; }
        }

        public class Root
        {
            public bool success { get; set; }
            public Query query { get; set; }
            public Info info { get; set; }
            public string date { get; set; }
            public double result { get; set; }
        }

    }
}
//Class model potrzebny do deserializacji danych JSON do obiektu
