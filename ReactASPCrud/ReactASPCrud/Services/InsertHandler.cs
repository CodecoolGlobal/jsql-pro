using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class InsertHandler : BaseHandler
    {

        private int tableIndex;

        public InsertHandler()
        {

        }

        public override void Process()
        {
            if (RecordService.input.Contains("INSERT") && RecordService.input.IndexOf("INSERT").Equals(0) && tableExist())
            {
                tableIndex = getTableIndex();
                SplitInput();
                Table table = RecordService.records[tableIndex];
                dynamic expado = new ExpandoObject();
                int sliceCount = 0;
                foreach (var value in table.columns.Keys)
                {
                    Util.AddProperty(expado, value, convertToType(table.columns[value], RecordService.inputStringSlices[sliceCount]));
                    sliceCount++;
                }
                //serialise
                string strCust = JsonConvert.SerializeObject(expado, new ExpandoObjectConverter());
                table.addRecord(strCust, expado);

            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                throw new Exception("input is not an Insertion");
            }
        }



        public bool tableExist()
        {
            bool tableExist = false;
            foreach (Table table in RecordService.records)
            {
                if (table.Name.Equals(RecordService.keyWords[2]))
                {
                    tableExist = true;
                }
                else
                {
                    continue;
                }
            }
            return tableExist;
        }

        public object convertToType(string columnType, string toConvert)
        {
            switch (columnType)
            {
                case "string":
                    return toConvert.ToString();
                case "int32":
                    if (Int32.TryParse(toConvert, out int result))
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("String could not be parsed.");
                        return null;
                    }
                case "int64":
                    if (Int64.TryParse(toConvert, out Int64 result1))
                    {
                        return result1;
                    }
                    else
                    {
                        Console.WriteLine("String could not be parsed.");
                        return null;
                    }
                case "bool":
                    if (Boolean.TryParse(toConvert, out bool result2))
                    {
                        return result2;
                    }
                    else
                    {
                        Console.WriteLine("String could not be parsed.");
                        return null;
                    }
                default:
                    return null;
            }
        }

        public int getTableIndex()
        {
            int tableInx = -1;
            for (int i = 0; i < RecordService.records.Count; i++)
            {
                //új módszer kell a tábla nevének a megszerzésére
                if (RecordService.records[i].Name.Equals(RecordService.keyWords[2]))
                {
                    tableInx = i;
                }
                else
                {
                    continue;
                }
            }
            return tableInx;
        }
    }
}