using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class SelectTests
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


      
        [Fact]
        public void SelectInputWithoutSemicolon()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "SELECT name, age FROM myTable";
            recordService.manageTable();

            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void SelectSatementIsInWrongPlace()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "name, age SELECT FROM myTable;";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void SelectInputHaveMoreValuesNextToTheStarSymbol()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "SELECT name, age, * FROM myTable;";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are not able to use * and other column name in the same time" });
        }

        [Fact]
        public void SelectInputHaveMissingValues()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "SELECT FROM myTable;";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are missing something" });
        }
    }
}
