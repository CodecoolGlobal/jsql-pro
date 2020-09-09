using ReactASPCrud.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ReactASPCrud.Services
{
    public class RecordService
    {
        internal static string input { get; set; }
        internal static List<Table> records = new List<Table>();
        internal static List<ExpandoObject> selected = new List<ExpandoObject>();
        internal static string[] inputStringSlices;
        internal static string[] keyWords;
        internal static List<string> Messages = new List<string>();
        internal static string[] AccessableInputs = new string[] { "CREATE", "INSERT", "DELETE", "SELECT" };

        public RecordService() {
            setApi();
        }
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
            if (StatementNameIsInInput())
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
            else
            {
                Messages.Add("The server is not able to process your input!");
            }

        }

        public bool StatementNameIsInInput()
        {
            if (RecordService.input.Contains("CREATE") || RecordService.input.Contains("SELECT") ||
                RecordService.input.Contains("INSERT") || RecordService.input.Contains("DELETE"))
            {
                RecordService.Messages.Add("State is correct");
                return true;
            }
            else
            {
                RecordService.Messages.Add("Your input is missing a state or it is in incorrect form. Use Uppercase Letters!");
                return false;
            }

        }

        //fill api with dummi data
        public void setApi(){
            CreateHandler createHandler = new CreateHandler();
            InsertHandler insertHandler = new InsertHandler();
            SelectHandler selectHandler = new SelectHandler();
            
            input = "CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);";
            createHandler.Process();
            input = "INSERT INTO myTable (József, Józsi, 60, 92);";
            insertHandler.Process();
            input = "INSERT INTO myTable (Péter, Petii, 45, 77);";
            insertHandler.Process();
            input = "INSERT INTO myTable (Gyula, Gyuszi, 32, 67);";
            insertHandler.Process();
            input = "SELECT name, age FROM myTable;";
            selectHandler.Process();
        }
    }
}
//refactor előtt kb 500 sor volt