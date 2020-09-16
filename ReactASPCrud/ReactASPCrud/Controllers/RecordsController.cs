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
            CreateHandler createHandler = new CreateHandler();
            InsertHandler insertHandler = new InsertHandler();
            SelectHandler selectHandler = new SelectHandler();
            WhereHandler whereHandler = new WhereHandler();

            recordService.setInput("CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);");
            createHandler.Process();
            recordService.setInput("INSERT INTO myTable (József, Józsi, 60, 92);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (Péter, Peti, 45, 77);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (Gyula, Gyuszi, 32, 67);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (Endre, Ede, 21, 60);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (Laura, Lara, 23, 55);");
            insertHandler.Process();
            recordService.setInput("INSERT INTO myTable (Anna, Anka, 19, 48);");
            insertHandler.Process();
            //Input = "SELECT name, age FROM myTable;";
            //selectHandler.Process();
            //Input = "WHERE age > 33;";
            //whereHandler.Process();
        }
    }
}