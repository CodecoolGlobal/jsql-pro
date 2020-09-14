using ReactASPCrud.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ReactASPCrud.Services
{
    public class RecordService
    {
        public RecordService() {
            //records.Clear();
            //setApi();
        }

        protected static string input { get; set; }
        protected static List<Table> records = new List<Table>();
        protected static List<ExpandoObject> selected = new List<ExpandoObject>();
        protected static string[] inputStringSlices;
        protected static string[] keyWords;
        protected static List<string> Messages = new List<string>();
        protected static string[] AccessableInputs = new string[] { "CREATE", "INSERT", "DELETE", "SELECT" };

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
                WhereHandler whereHandler = new WhereHandler();

                createHandler.SetNextHandler(deleteHandler);
                deleteHandler.SetNextHandler(insertHandler);
                insertHandler.SetNextHandler(selectHandler);
                selectHandler.SetNextHandler(whereHandler);
                createHandler.Process();
            }
            else
            {
                Messages.Add("The server is not able to process your input!");
            }

        }

        public bool StatementNameIsInInput()
        {
            if (input.Contains("CREATE") || input.Contains("SELECT") ||
                input.Contains("INSERT") || input.Contains("DELETE") || 
                input.Contains("WHERE"))
            {
                Messages.Add("State is correct");
                return true;
            }
            else
            {
                Messages.Add("Your input is missing a state or it is in incorrect form. Use Uppercase Letters!");
                return false;
            }

        }

        //fill api with dummi data
        public void setApi(){
            CreateHandler createHandler = new CreateHandler();
            InsertHandler insertHandler = new InsertHandler();
            SelectHandler selectHandler = new SelectHandler();
            WhereHandler whereHandler = new WhereHandler();
            
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
            input = "WHERE age > 33;";
            whereHandler.Process();
        }
        public void setInput(string _input)
        {
            input = _input;
        }

        public List<string> getMessages() {
            return Messages;
        }
    }
}
//refactor előtt kb 500 sor volt