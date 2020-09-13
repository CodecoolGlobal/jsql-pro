using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class SelectHandler : BaseHandler
    {
        private int tableIndexSelect;
        internal static List<ExpandoObject> selectedObjects = new List<ExpandoObject>();

        public static List<string> selectedValues = new List<string>();
        public override void Process()
        {
            SplitInput();
            if (input.Contains("SELECT"))
            {
                if (ValidateInput() && input.IndexOf("SELECT").Equals(0) && tableExist())
                {
                    tableIndexSelect = getTableIndexSelect();
                    selected.Clear();
                    selectedValues.Clear();
                    Table table = records[tableIndexSelect];

                    for (int i = 1; i < keyWords.Length - 2; i++)
                    {
                        selectedValues.Add(keyWords[i]);
                    }

                    foreach (var record in table.serialisedRecords)
                    {
                        selectedObjects.Add(JsonConvert.DeserializeObject<ExpandoObject>(record, new ExpandoObjectConverter()));
                    }
                    if (selectedValues.Count().Equals(1) && selectedValues[0].Equals("*"))
                    {
                        foreach (var exp in selectedObjects)
                        {
                            dynamic expado = new ExpandoObject();

                            foreach (KeyValuePair<string, object> kvp in exp)
                            {
                                Util.AddProperty(expado, kvp.Key, kvp.Value);
                            }
                            selected.Add(expado);
                        }
                    }
                    else
                    {
                        foreach (var exp in selectedObjects)
                        {
                            dynamic expado = new ExpandoObject();

                            foreach (KeyValuePair<string, object> kvp in exp)
                            {
                                if (selectedValues.Contains(kvp.Key))
                                {
                                    Util.AddProperty(expado, kvp.Key, kvp.Value);
                                }
                            }
                            selected.Add(expado);
                        }

                    }
                }
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                //throw new Exception("input is not a Selection");
            }
        }

        public bool tableExist()
        {
            bool tableExist = false;
            foreach (Table table in records)
            {
                if (table.Name.Equals(keyWords[keyWords.Length - 1]))
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

        public int getTableIndexSelect()
        {
            int tableInx = -1;
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Name.Equals(keyWords[keyWords.Length - 1]))
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


            if (!input.Contains(";"))
            {
                Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (tableExist())
            {
                Messages.Add("Table Exist");
            }
            if (!input.IndexOf("SELECT").Equals(0))
            {
                Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (keyWords.Length > 4 && keyWords.Contains("*"))
            {
                Messages.Add("you are not able to use * and other column name in the same time");
                inputIsValid = false;
            }
            if (keyWords.Length < 4)
            {
                Messages.Add("you are missing something");
                inputIsValid = false;
            }

            return inputIsValid;
        }
    }

}