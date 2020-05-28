using ReactASPCrud.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ReactASPCrud.Services
{
    public class RecordService
    {
        public static string input { get; set; }
        public static List<Table> records = new List<Table>();
        public static List<ExpandoObject> selected = new List<ExpandoObject>();
        public static string[] inputStringSlices;
        public static string[] keyWords;

        static RecordService(){}


        //public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        //{
        //    // ExpandoObject supports IDictionary so we can extend it like this
        //    var expandoDict = expando as IDictionary<string, object>;
        //    if (expandoDict.ContainsKey(propertyName))
        //        expandoDict[propertyName] = propertyValue;
        //    else
        //        expandoDict.Add(propertyName, propertyValue);
        //}


        public List<Table> GetAll()
        {
            return records;
        }

        public Table GetByTableName(string name)
        {
            return records.Where(table => table.Name == name).FirstOrDefault();
        }

        public List<ExpandoObject> GetSelected()
        {
            return selected;
        }

        public void manageTable()
        {
            CreateHandler createHandler = new CreateHandler();
            DeleteHandler deleteHandler = new DeleteHandler();
            InsertHandler insertHandler = new InsertHandler();
            SelectHandler selectHandler = new SelectHandler();

            createHandler.SetNextHandler(deleteHandler);
            deleteHandler.SetNextHandler(insertHandler);
            insertHandler.SetNextHandler(selectHandler);
            createHandler.Process();

        }

        //public void SplitInputString(Record user)
        //{
        //    if (user.Name.Contains("("))
        //    {
        //        int valuesStartFrom = user.Name.IndexOf("(");
        //        string values = user.Name.Replace(",", "").Substring(user.Name.Length - (user.Name.Length - (valuesStartFrom + 1)));
        //        inputStringSlices = values.Substring(0, values.Length - 2).Split(" ");
        //        string keyvalues = user.Name.Substring(0, valuesStartFrom - 1);
        //        keyWords = keyvalues.Split(" ");
        //    }
        //    else
        //    {
        //        string values = user.Name.Replace(",", "");
        //        keyWords = values.Remove(values.Length-1).Split(" ");
        //    }
        //}


        //public Table createTable()
        //{
        //    Table table = new Table();
        //    table.Name = keyWords[2];
        //    for (int i = 0; i < inputStringSlices.Length - 1; i += 2)
        //    {
        //        table.addHeader(inputStringSlices[i + 1], inputStringSlices[i]);
        //    }
        //    records.Add(table);

        //    return table;
        //}


        //public bool tableExist()
        //{
        //    bool tableExist = false;
        //    foreach (Table table in records)
        //    {
        //        if (table.Name.Equals(keyWords[2]))
        //        {
        //            tableExist = true;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return tableExist;
        //}


        //public object convertToType(string columnType, string toConvert)
        //{
        //    switch (columnType)
        //    {
        //        case "string":
        //            return toConvert.ToString();
        //        case "int32":
        //            if (Int32.TryParse(toConvert, out int result))
        //            {
        //                return result;
        //            }
        //            else
        //            {
        //                Console.WriteLine("String could not be parsed.");
        //                return null;
        //            }
        //        case "int64":
        //            if (Int64.TryParse(toConvert, out Int64 result1))
        //            {
        //                return result1;
        //            }
        //            else
        //            {
        //                Console.WriteLine("String could not be parsed.");
        //                return null;
        //            }
        //        case "bool":
        //            if (Boolean.TryParse(toConvert, out bool result2))
        //            {
        //                return result2;
        //            }
        //            else
        //            {
        //                Console.WriteLine("String could not be parsed.");
        //                return null;
        //            }
        //        default:
        //            return null;
        //    }
        //}


        //public int getTableIndex()
        //{
        //    int tableInx = -1;
        //    for (int i = 0; i < records.Count; i++)
        //    {
        //        if (records[i].Name.Equals(keyWords[2]))
        //        {
        //            tableInx = i;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return tableInx;
        //}

        //public int getTableIndexSelect()
        //{
        //    int tableInx = -1;
        //    for (int i = 0; i < records.Count; i++)
        //    {
        //        if (records[i].Name.Equals(keyWords[keyWords.Length-1]))
        //        {
        //            tableInx = i;
        //        }
        //        else
        //        {
        //            continue;
        //        }
        //    }
        //    return tableInx;
        //}


        //public Table insertIntoTable(int tableIndex)
        //{
        //    Table table = records[tableIndex];
        //    dynamic expado = new ExpandoObject();
        //    int sliceCount = 0;
        //    foreach (var value in table.columns.Keys)
        //    {
        //        AddProperty(expado, value, convertToType(table.columns[value], inputStringSlices[sliceCount]));
        //        sliceCount++;
        //    }
        //    //serialise
        //    string strCust = JsonConvert.SerializeObject(expado, new ExpandoObjectConverter());
        //    table.addRecord(strCust, expado);

        //    return table;
        //}

        //public Table SelectColumns(int tableIndexSelect)
        //{
        //    selected.Clear();
        //    Table table = records[tableIndexSelect];
        //    List<string> selectedValues = new List<string>();
        //    List<ExpandoObject> selectedObjects = new List<ExpandoObject>();

        //    for(int i = 1; i < keyWords.Length-2; i++) {
        //        selectedValues.Add(keyWords[i]);
        //    }

        //    foreach (var record in table.serialisedRecords)
        //    {
        //        selectedObjects.Add(JsonConvert.DeserializeObject<ExpandoObject>(record, new ExpandoObjectConverter()));
        //    }
        //    if(selectedValues.Count().Equals(1) && selectedValues[0].Equals("*"))
        //    {
        //        foreach (var exp in selectedObjects)
        //        {
        //            dynamic expado = new ExpandoObject();

        //            foreach (KeyValuePair<string, object> kvp in exp)
        //            {
        //                    AddProperty(expado, kvp.Key, kvp.Value);
        //            }
        //            selected.Add(expado);
        //        }
        //    }
        //    else
        //    {
        //    foreach (var exp in selectedObjects)
        //    {
        //    dynamic expado = new ExpandoObject();

        //        foreach (KeyValuePair<string, object> kvp in exp)
        //        {
        //            if (selectedValues.Contains(kvp.Key))
        //            {
        //                AddProperty(expado, kvp.Key, kvp.Value);
        //            }
        //        }
        //        selected.Add(expado);
        //    }
        //    }





        //    return new Table();
        //}

        //public Table DeleteTable(int tableIndexSelect)
        //{
        //    if(tableIndexSelect >= 0)
        //    {
        //        records.RemoveAt(tableIndexSelect);
        //    }

        //    return new Table();
        //}




        //switch (keyWords[0])
        //{
        //    case "CREATE":
        //        if (!tableExist()) {
        //            return createTable();
        //        }
        //        else {
        //            return new Table();
        //        }

        //    case "INSERT":
        //        //if (tableExist() && checkForValues(getTableIndex()))
        //        if (tableExist())
        //        {
        //            return insertIntoTable(getTableIndex());
        //        }
        //        else
        //        {
        //            return new Table();
        //        }

        //    case "SELECT":
        //            return SelectColumns(getTableIndexSelect());

        //    case "DELETE":
        //        return DeleteTable(getTableIndexSelect());


        //    default:
        //        Console.WriteLine("Other");
        //        return new Table();
        //}




        //rest my friend
        //public bool checkForValues(int tableIndex)
        //{
        //    int sliceCount = 0;
        //    int errorCount = 0;
        //    if (inputStringSlices.Length.Equals(records[tableIndex].columns.Values.Count))
        //    {
        //        foreach (var record in records[tableIndex].columns.Values)
        //        {

        //            //string type = inputStringSlices[sliceCount].GetType().ToString();
        //            //if (!inputStringSlices[sliceCount].GetType().ToString().Equals(record))
        //            //{
        //            //    errorCount++;
        //            //}
        //            //sliceCount++;


        //        }
        //        if (errorCount.Equals(0))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        return false; ;

        //    }
        //}


        //public bool checkForInsert(ExpandoObject expado)
        //{
        //    bool result = true;

        //    //deserialise
        //    dynamic cust = JsonConvert.DeserializeObject<ExpandoObject>(records[0].serialisedRecords[0], new ExpandoObjectConverter());

        //    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(cust))
        //    {
        //        string name = descriptor.Name;
        //        object value = descriptor.GetValue(cust);
        //        object value2 = descriptor.GetValue(cust);

        //        if (!descriptor.GetValue(cust) == descriptor.GetValue(expado))
        //        {
        //            result = false;
        //        }
        //        Console.WriteLine("{0}={1}  expado value={2}", name, value, value2);

        //    }
        //    //if (!cust.Equals(expado))
        //    //{
        //    //    result = false;
        //    //}
        //    return result;
        //}


        //public Table GenerateDynamicObject()
        //{
        //    dynamic expado = new ExpandoObject();
        //    dynamic expado2 = new ExpandoObject();

        //    //List<ExpandoObject> records2 = new List<ExpandoObject>();
        //    //AddProperty(expado, "id", 1);
        //    //AddProperty(expado, "tableName", keyWords[2]);
        //    //AddProperty(expado, "records", records2);


        //    for (int i = 0; i < inputStringSlices.Length - 1; i += 2)
        //    {
        //        //CREATE
        //        if (keyWords[0].Equals("CREATE"))
        //        {
        //            object value = generateType(inputStringSlices[i]);
        //            AddProperty(expado2, inputStringSlices[i + 1], value);
        //        }
        //        //INSERT
        //        else
        //        {if()
        //            AddProperty(expado2, inputStringSlices[i + 1], inputStringSlices[i]);
        //        }
        //    }
        //    //serialise
        //    string strCust = JsonConvert.SerializeObject(expado2, new ExpandoObjectConverter());








        //    //deserialise
        //    //cust = JsonConvert.DeserializeObject<ExpandoObject>(res, new ExpandoObjectConverter());

        //    Table table;





        //    if (keyWords[0].Equals("CREATE"))
        //    {
        //        table = new Table();
        //        table.Id = 1;
        //        table.Name = keyWords[2];
        //        table.addRecord(strCust, expado2);
        //        records.Add(table);


        //        return table;
        //    }
        //    else
        //    {
        //        //GOOD INPUT
        //        if (checkForInsert(expado2) == true)
        //        {
        //            table = records[0];
        //            table.addRecord(strCust, expado2);

        //            return table;
        //        }
        //        //BAD INPUT
        //        else
        //        {
        //            Console.WriteLine("ITS NOT GOOD");
        //            return table = new Table();
        //        }
        //    }




    }
    //public object generateType(string inputStringSlice)
    //{
    //    object result = null;

    //    switch (inputStringSlice)
    //    {
    //        case "string":
    //            result = "egy";
    //            break;
    //        case "int":
    //            result = 1;
    //            break;

    //    }

    //    return result;
    //}


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






//"name":"CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);"
//"name":"INSERT INTO myTable (József, Józsi, 60, 92);"

//"name":"CREATE TABLE KITTY (int32 hight, int32 weight, string name);"
//"name":"INSERT INTO KITTY (62, 33, cicavagyeskesz);"