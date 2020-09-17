using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReactASPCrud.Models;
using ReactASPCrud.Services;

namespace ReactASPCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ReactPolicy")]
    public class RecordsController : ControllerBase
    {
        private readonly RecordService recordService;

        public RecordsController(RecordService recordService)
        {
            this.recordService = recordService;
        }

        // GET api/records/data
        [HttpGet("data")]
        public IEnumerable<Table> Get()
        {
            setApi();
            return recordService.GetAll();
        }

        //GET api/records/data/myTable
        [HttpGet("data/{name}")]
        public async Task<IActionResult> GetTable(string name)
        {
            return Ok(recordService.GetByTableName(name));
        }

        //GET api/records/select
        [HttpGet("select")]
        public IEnumerable<ExpandoObject> GetSelectedApi()
        {
            return recordService.GetSelected();
        }

        [HttpGet("messages")]
        public List<string> GetMessages()
        {
            return recordService.getMessages();
        }

        // POST api/records
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Record record)
        {
            //recordService.SplitInputString(record);
            recordService.setInput(record.Name);
            recordService.getMessages().Clear();
            recordService.manageTable();

            return NoContent();
        }

        // PUT api/records/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] User user)
        //{
        //    userService.Update(id, user);

        //    return NoContent();
        //}

        // DELETE api/records/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    userService.Delete(id);

        //    return NoContent();
        //}

        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }

        public void setApi()
        {
            recordService.clearRecords();
            CreateHandler createHandler = new CreateHandler();
            InsertHandler insertHandler = new InsertHandler();
            SelectHandler selectHandler = new SelectHandler();
            WhereHandler whereHandler = new WhereHandler();
            InnerJoinHandler innerJoinHandler = new InnerJoinHandler();

            recordService.setInput("CREATE TABLE myTable (int32 id, string name, string nickname, int32 age, int32 weight);");
            createHandler.Process();
            recordService.setInput("INSERT INTO myTable (1, József, Józsi, 60, 92);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (2, Péter, Peti, 45, 77);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (3, Gyula, Gyuszi, 32, 67);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (4, Endre, Ede, 21, 60);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (5, Laura, Lara, 23, 55);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (6, Anna, Anka, 19, 48);");
            insertHandler.Process();
            //Input = "SELECT name, age FROM myTable;";
            //selectHandler.Process();
            //Input = "WHERE age > 33;";
            //whereHandler.Process();
            recordService.setInput("CREATE TABLE pets (int32 petid, int32 ownerid, string petname, string type);");
            createHandler.Process();
            recordService.setInput("INSERT INTO pets (1, 3, kuty, puli);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO pets (2, 3, fasirt, agar);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO pets (3, 1, macska, bulldog);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO pets (4, 6, kopasz, tacsko);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO pets (5, 6, foltos, dalmata;");
            insertHandler.Process();
            innerJoinHandler.setInput("SELECT * FROM myTable INNER JOIN pets ON mytable.id = pets.ownerid;");
            selectHandler.Process();
            innerJoinHandler.Process();

        }
    }
}