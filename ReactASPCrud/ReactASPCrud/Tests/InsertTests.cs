using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class InsertTests
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


       
        [Fact]
        public void InsertInputMissingTableName()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "INSERT INTO (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Table name is missing" });
        }

        [Fact]
        public void InsertStatementIsInWrongPlace()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "INTO INSERT testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void InsertStatementsValuesAreMissing()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "INSERT INTO testTable ();";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "You are missing values" });
        }

        [Fact]
        public void InsertStatementsBracketMissing()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "INSERT INTO testTable );";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "You are missing values", "( or ) is missing" });
        }

        [Fact]
        public void InsertInputWithoutSemicolon()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "INSERT INTO myTable (József, Józsi, 60, 92)";
            recordService.manageTable();

            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void InsertInputParserError()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            RecordService.Messages.Clear();
            RecordService.input = "INSERT INTO myTable (József, Józsi, hatvan, 92);";
            recordService.manageTable();

            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Table Exist", "String could not be parsed." });
        }

        [Fact]
        public void InsertHandlerParserTest()
        {
            InsertHandler insertHandler = new InsertHandler();

            Assert.Null(insertHandler.convertToType("int32", "kiskutya"));
        }

    }
}
