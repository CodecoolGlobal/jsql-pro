using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class Tests
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


        public void createTable()
        {
            table.Name = "testTable";
            RecordService.keyWords = new string[] { "CREATE", "TABLE", "testTable" };
            table.addHeader("age", "int");
            table.addHeader("name", "string");
            table.addHeader("nickname", "string");

            ExpandoObject expado1 = new ExpandoObject();
            ExpandoObject expado2 = new ExpandoObject();

            Util.AddProperty(expado1, "age", 11);
            Util.AddProperty(expado1, "name", "Péter");
            Util.AddProperty(expado1, "name", "Peti");

            Util.AddProperty(expado2, "age", 30);
            Util.AddProperty(expado2, "name", "József");
            Util.AddProperty(expado2, "name", "Józsi");

            string strCust1 = JsonConvert.SerializeObject(expado1, new ExpandoObjectConverter());
            string strCust2 = JsonConvert.SerializeObject(expado2, new ExpandoObjectConverter());

            table.addRecord(strCust1, expado1);
            table.addRecord(strCust2, expado2);

            RecordService.records.Add(table);
        }


        [Fact]
        public void TableExistTest()
        {
            Models.Table table = new Models.Table();
            table.Name = "testName";
            RecordService.keyWords = new string[] { "CREATE", "TABLE", "testName" };
            RecordService.records.Add(table);
            CreateHandler createHandler = new CreateHandler();
            Assert.True(createHandler.tableExist());
        }

        [Fact]
        public void UnexpectedInput()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, RecordService.Messages);

        }

        [Fact]
        public void useInputWithoutStatementName()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, RecordService.Messages);
        }

        [Fact]
        public void useInputWithIncorrectStatementName()
        {
            RecordService.Messages.Clear();
            RecordService.records.Clear();
            RecordService.input = "create TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, RecordService.Messages);
        }


        //Tests for CREATE statement-------------------------------------------------------------------------------------------


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

        //Tests for INSERT statement-------------------------------------------------------------------------------------------

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


        //Tests for DELETE statement-------------------------------------------------------------------------------------------

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

        //Tests for SELECT statement-------------------------------------------------------------------------------------------

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