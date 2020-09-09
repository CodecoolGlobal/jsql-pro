using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class DeleteTests
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


 
        [Fact]
        public void DeleteInputWithoutSemicolon()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "DELETE TABLE myTable";
            recordService.manageTable();

            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void DeletetSatementIsInWrongPlace()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "myTable DELETE TABLE;";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void DeleteInputWithTooManyInputs()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "DELETE TABLE myTable kiskutya;";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "You entered to many information" });
        }
    }
}
