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

        public SelectHandler(){}

        public override void Process()
        {
            SplitInput();
            if (RecordService.input.Contains("SELECT") && RecordService.input.IndexOf("SELECT").Equals(0) && tableExist())
            {
                tableIndexSelect = getTableIndexSelect();
                RecordService.selected.Clear();
                Table table = RecordService.records[tableIndexSelect];
                List<string> selectedValues = new List<string>();
                List<ExpandoObject> selectedObjects = new List<ExpandoObject>();

                for (int i = 1; i < RecordService.keyWords.Length - 2; i++)
                {
                    selectedValues.Add(RecordService.keyWords[i]);
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
                        RecordService.selected.Add(expado);
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
                        RecordService.selected.Add(expado);
                    }

                }
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                throw new Exception("input is not a Selection");
            }
        }

        public bool tableExist()
        {
            bool tableExist = false;
            foreach (Table table in RecordService.records)
            {
                if (table.Name.Equals(RecordService.keyWords[RecordService.keyWords.Length - 1]))
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
            for (int i = 0; i < RecordService.records.Count; i++)
            {
                if (RecordService.records[i].Name.Equals(RecordService.keyWords[RecordService.keyWords.Length - 1]))
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