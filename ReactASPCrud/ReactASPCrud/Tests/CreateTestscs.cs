using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class CreateTests
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


        [Fact]
        public void CreateInputWithoutSemicolon()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE testTable (string name, string nickname, int32 age, int32 weight)";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void CreateInputTableAlreadyExist()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            RecordService.Messages.Clear();
            recordService.manageTable();
            Assert.Equal(new List<string>() { "State is correct", "Table Exist" }, RecordService.Messages);
        }

        [Fact]
        public void CreateInputMissingTableName()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Table name is missing" });
        }

        [Fact]
        public void CreateStatementIsInWrongPlace()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "TABLE CREATE testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void CreateStatementsValuesAreMissing()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE testTable ();";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "values are missing" });
        }

        [Fact]
        public void CreateStatementsBracketMissing()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE testTable );";
            recordService.manageTable();
            Assert.Equal(RecordService.Messages, new List<string>() { "State is correct", "values are missing", "( or ) is missing" });
        }

        [Fact]
        public void CreateHandlerValidate()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "CREATE TABLE testTable );";
            recordService.manageTable();
            Assert.False(createHandler.ValidateInput());
        }
    }
}
