using ReactASPCrud.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace ReactASPCrud.Services
{
    public class RecordService
    {
        public RecordService() {
        }

        protected static string Input { get; set; }
        protected static List<Table> records = new List<Table>();
        protected static List<ExpandoObject> selected = new List<ExpandoObject>();
        protected static string[] inputStringSlices;
        protected static string[] keyWords;
        protected static List<string> Messages = new List<string>();
        protected static string[] AccessableInputs = new string[] { "CREATE", "INSERT", "DELETE", "SELECT", "WHERE" };

        public List<Table> GetAll()
        {
            return records;
        }

        public List<ExpandoObject> GetByTableName(string name)
        {
            return records.Where(table => table.Name == name).FirstOrDefault().deserialisedRecords;
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
                InnerJoinHandler innerJoinHandler = new InnerJoinHandler();

                createHandler.SetNextHandler(deleteHandler);
                deleteHandler.SetNextHandler(insertHandler);
                insertHandler.SetNextHandler(selectHandler);
                selectHandler.SetNextHandler(innerJoinHandler);
                innerJoinHandler.SetNextHandler(whereHandler);

                createHandler.Process();
            }
            else
            {
                Messages.Add("The server is not able to process your input!");
            }

        }

        public bool StatementNameIsInInput()
        {
            if (AccessableInputs.Any(s => Input.Contains(s)))
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

        public void setInput(string _input)
        {
            Input = _input.ToUpper(new CultureInfo("en-US", false));
        }

        public List<string> getMessages() {
            return Messages;
        }

        public void clearRecords() {
            records.Clear();
        }
    }
}
//refactor előtt kb 500 sor volt