using System;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class InsertHandler : BaseHandler
    {

        private int tableIndex;

        public InsertHandler() { }

        public override void Process()
        {
            SplitInput();
            if (Input.Contains("INSERT"))
            {
                if (ValidateInput() && Input.IndexOf("INSERT").Equals(0) && tableExist())
                {
                    tableIndex = getTableIndex();
                    Table table = records[tableIndex];
                    //if (RecordService.keyWords.Length > table.columns.Keys.Count || RecordService.keyWords.Length < table.columns.Keys.Count)
                    //{
                    //    RecordService.Messages.Add("the entered velue number is incorrect");
                    //}
                    dynamic expado = new ExpandoObject();
                    int sliceCount = 0;
                    foreach (var value in table.columns.Keys)
                    {
                        Util.AddProperty(expado, value, convertToType(table.columns[value], inputStringSlices[sliceCount]));
                        sliceCount++;
                    }
                    //serialise
                    string strCust = JsonConvert.SerializeObject(expado, new ExpandoObjectConverter());
                    table.addRecord(strCust, expado);

                }
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                //throw new Exception("input is not an Insertion");
            }
        }



        public bool tableExist()
        {
            bool tableExist = false;
            foreach (Table table in records)
            {
                if (table.Name.Equals(keyWords[2]))
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
                        Messages.Add("String could not be parsed.");
                        return null;
                    }
                case "int64":
                    if (Int64.TryParse(toConvert, out Int64 result1))
                    {
                        return result1;
                    }
                    else
                    {
                        Messages.Add("String could not be parsed.");
                        return null;
                    }
                case "bool":
                    if (Boolean.TryParse(toConvert, out bool result2))
                    {
                        return result2;
                    }
                    else
                    {
                        Messages.Add("String could not be parsed.");
                        return null;
                    }
                default:
                    return null;
            }
        }

        public int getTableIndex()
        {
            int tableInx = -1;
            for (int i = 0; i < records.Count; i++)
            {
                //új módszer kell a tábla nevének a megszerzésére
                if (records[i].Name.Equals(keyWords[2]))
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

        public override bool ValidateInput()
        {
            bool inputIsValid = true;

           

            if (!Input.Contains(";"))
            {
                Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (keyWords.Contains("INSERT") && keyWords.Contains("INTO") && keyWords.Length < 3)
            {
                Messages.Add("Table name is missing");
                inputIsValid = false;
            }
            if (tableExist())
            {
                Messages.Add("Table Exist");
            }
            if (!Input.IndexOf("INSERT").Equals(0))
            {
                Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (inputStringSlices.Length < 2)
            {
                Messages.Add("You are missing values");
                inputIsValid = false;
            }
            if (!Input.Contains("(") || (!Input.Contains(")")))
            {
                Messages.Add("( or ) is missing");
                inputIsValid = false;
            }

            return inputIsValid;
        }

    }
}