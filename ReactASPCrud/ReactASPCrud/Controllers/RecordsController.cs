﻿using System.Collections.Generic;
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

        // POST api/records
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Record record)
        {
            //recordService.SplitInputString(record);
            recordService.setInput(record.Name);
            recordService.getMessages().Clear();
            recordService.manageTable();

            return CreatedAtAction("Get", recordService.getMessages());
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
    }
}