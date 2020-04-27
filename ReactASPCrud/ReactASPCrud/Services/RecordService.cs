using ReactASPCrud.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ReactASPCrud.Services
{
    public class RecordService
    {
        private static List<ExpandoObject> records = new List<ExpandoObject>();
        private static string[] inputStringSlices;
        private static int Count = 1;

        static RecordService()
        {
        }
        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            // ExpandoObject supports IDictionary so we can extend it like this
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        public List<ExpandoObject> GetAll()
        {
            return records;
        }


        public void GenerateTableCols(Record user)
        {
            int valuesStartFrom = user.Name.IndexOf("(");
            string values = user.Name.Replace(",", "").Substring(user.Name.Length - (user.Name.Length - (valuesStartFrom + 1)));
            inputStringSlices = values.Substring(0, values.Length - 2).Split(" ");
        }

        public ExpandoObject GenerateDynamicObject()
        {
            dynamic expado = new ExpandoObject();
            for(int i = 0; i < inputStringSlices.Length - 1; i += 2)
            {
                AddProperty(expado, inputStringSlices[i+1], inputStringSlices[i]);
            }
            records.Add(expado);

            return expado;
        }


        //public void Update(int id, User user)
        //{
        //    User found = users.Where(n => n.Id == id).FirstOrDefault();
        //    found.Name = user.Name;
        //}

        //public void Delete(int id)
        //{
        //    users.RemoveAll(n => n.Id == id);
        //}
    }
}
