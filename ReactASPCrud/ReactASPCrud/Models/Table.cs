using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactASPCrud.Models
{
    public class Table
    {
        public string Name { get; set; }

        public List<string> serialisedRecords = new List<string>();
        public List<ExpandoObject> deserialisedRecords = new List<ExpandoObject>();
        public Dictionary<string, string> columns = new Dictionary<string, string>();

        public void addRecord(string jsonstring, ExpandoObject expando)
        {
            serialisedRecords.Add(jsonstring);
            deserialisedRecords.Add(expando);
        }

        public void addHeader(string propName, string value)
        {
            columns.Add(propName, value);
        }
    }
}