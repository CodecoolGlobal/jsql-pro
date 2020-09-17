using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class InnerJoinHandler : BaseHandler
    {
        private int firstTableIndex = -1;
        private int secondTableIndex = -1;
        private List<ExpandoObject> firstSelectedObjects = new List<ExpandoObject>();
        private List<ExpandoObject> secondSelectedObjects = new List<ExpandoObject>();
        private List<ExpandoObject> innerJoinSelectedObjects = new List<ExpandoObject>();
        public static List<string> innerJoinKeyWords = new List<string>();
        private static string firstJoinColumn = "";
        private string secondJoinColumn = "";

        public override void Process()
        {
            SplitInput();
            if (Input.Contains("INNER"))
            {
                getInnerJoinKeywords();
                firstJoinColumn = getTableConnectionColumn(4);
                secondJoinColumn = getTableConnectionColumn(6);
                getTablesIndexes();
                Table firstTable = records[firstTableIndex];
                Table secondTable = records[secondTableIndex];

                foreach (var record in firstTable.serialisedRecords)
                {
                    firstSelectedObjects.Add(JsonConvert.DeserializeObject<ExpandoObject>(record, new ExpandoObjectConverter()));
                }
                foreach (var record in secondTable.serialisedRecords)
                {
                    secondSelectedObjects.Add(JsonConvert.DeserializeObject<ExpandoObject>(record, new ExpandoObjectConverter()));
                }
                //check if the tables containing the neccessary joining columns

                if (checkJoin())
                {
                    foreach (var exp in secondSelectedObjects)
                    {
                        dynamic expado = new ExpandoObject();
                        bool visited = false;
                        List<int> connectionPositions = new List<int>();
                        //check connection
                        foreach (KeyValuePair<string, object> kvp in exp)
                        {
                            int counter = 0;
                            if (!visited)
                            {
                                foreach (var exp2 in firstSelectedObjects)
                                {
                                    foreach (KeyValuePair<string, object> kvp2 in exp2)
                                    {
                                        if (kvp2.Key.Equals(firstJoinColumn)
                                            && kvp.Key.Equals(secondJoinColumn)
                                            && kvp.Value.Equals(kvp2.Value))
                                        {
                                            connectionPositions.Add(counter);
                                        }
                                    }
                                    counter++;
                                }
                                if (connectionPositions.Count > 0)
                                {
                                    foreach (KeyValuePair<string, object> kvp2 in firstSelectedObjects[connectionPositions[0]])
                                    {
                                        Util.AddProperty(expado, kvp2.Key, kvp2.Value);
                                    }
                                    visited = true;
                                }
                            }

                            Util.AddProperty(expado, kvp.Key, kvp.Value);
                            //here i have to test what happenes if expado is empty
                        }
                        innerJoinSelectedObjects.Add(expado);
                    }
                    //selected columns
                    selected.Clear();
                    updateSelect();
                    foreach (var exp in innerJoinSelectedObjects)
                    {
                        dynamic expado = new ExpandoObject();

                        foreach (KeyValuePair<string, object> kvp in exp)
                        {
                            if (SelectHandler.selectedValues.Contains(kvp.Key))
                            {
                                Util.AddProperty(expado, kvp.Key, kvp.Value);
                            }
                        }
                        selected.Add(expado);
                    }
                }
            }
            if (_nextHandler != null)
            {
                _nextHandler.Process();
            }
        }


        public void getInnerJoinKeywords()
        {
            int index = Array.IndexOf(keyWords, "INNER");
            for (int i = index; i < keyWords.Length; i++)
            {
                innerJoinKeyWords.Add(keyWords[i]);
            }
        }

        public void getTablesIndexes()
        {
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Name.Equals(keyWords[Array.IndexOf(keyWords, "FROM") + 1]))
                {
                    firstTableIndex = i;
                }
                if (records[i].Name.Equals(keyWords[Array.IndexOf(keyWords, "JOIN") + 1]))
                {
                    secondTableIndex = i;
                }
                else
                {
                    continue;
                }
            }
        }

        public bool checkJoin()
        {
            bool firstAbleToJoin = false;
            bool secondAbleToJoin = false;

            foreach (KeyValuePair<string, object> kvp in firstSelectedObjects[0])
            {
                if (kvp.Key.Equals(getTableConnectionColumn(4)))
                {
                    firstAbleToJoin = true;
                    break;
                }
            }
            foreach (KeyValuePair<string, object> kvp in secondSelectedObjects[0])
            {
                if (kvp.Key.Equals(getTableConnectionColumn(6)))
                {
                    secondAbleToJoin = true;
                    break;
                }
            }

            if (firstAbleToJoin && secondAbleToJoin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getTableConnectionColumn(int columnIndexInKeywords)
        {
            string result = innerJoinKeyWords[columnIndexInKeywords];
            int len = innerJoinKeyWords[columnIndexInKeywords].Count();
            int inx = innerJoinKeyWords[columnIndexInKeywords].IndexOf('.') + 1;
            string sub = result.Substring(inx, (len) - inx);
            return sub;

        }

        public void updateSelect() {
            if (Input.Contains("*"))
            {
                SelectHandler.selectedValues.Clear();
                foreach (KeyValuePair<string, object> kvp in innerJoinSelectedObjects[0])
                {
                    SelectHandler.selectedValues.Add(kvp.Key);
                }
            }
        }
    }
}