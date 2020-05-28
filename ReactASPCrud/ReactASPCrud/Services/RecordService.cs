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

        static RecordService() { }
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
    }
}
//refactor előtt kb 500 sor volt