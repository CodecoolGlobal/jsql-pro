using Xunit;
using ReactASPCrud.Models;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ReactASPCrud.Services
{
    public class Tests : BaseHandler
    {
        private RecordService recordService = new RecordService();
        private Table table = new Table();
        private CreateHandler createHandler = new CreateHandler();


        public void createTable()
        {
            table.Name = "testTable";
            keyWords = new string[] { "CREATE", "TABLE", "testTable" };
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

            records.Add(table);
        }


        [Fact]
        public void TableExistTest()
        {
            Models.Table table = new Models.Table();
            table.Name = "testName";
            keyWords = new string[] { "CREATE", "TABLE", "testName" };
            records.Add(table);
            CreateHandler createHandler = new CreateHandler();
            Assert.True(createHandler.tableExist());
        }

        [Fact]
        public void UnexpectedInput()
        {
            Messages.Clear();
            records.Clear();
            Input = "";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, Messages);

        }

        [Fact]
        public void useInputWithoutStatementName()
        {
            Messages.Clear();
            records.Clear();
            Input = "TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, Messages);
        }

        [Fact]
        public void useInputWithIncorrectStatementName()
        {
            Messages.Clear();
            records.Clear();
            Input = "create TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(new List<string>() { "Your input is missing a state or it is in incorrect form. Use Uppercase Letters!", "The server is not able to process your input!" }, Messages);
        }


        //Tests for CREATE statement-------------------------------------------------------------------------------------------


        [Fact]
        public void CreateInputWithoutSemicolon()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE testTable (string name, string nickname, int32 age, int32 weight)";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void CreateInputTableAlreadyExist()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Messages.Clear();
            recordService.manageTable();
            Assert.Equal(new List<string>() { "State is correct", "Table Exist" }, Messages);
        }

        [Fact]
        public void CreateInputMissingTableName()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Table name is missing" });
        }

        [Fact]
        public void CreateStatementIsInWrongPlace()
        {
            Messages.Clear();
            records.Clear();
            Input = "TABLE CREATE testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void CreateStatementsValuesAreMissing()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE testTable ();";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "values are missing" });
        }

        [Fact]
        public void CreateStatementsBracketMissing()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE testTable );";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "values are missing", "( or ) is missing" });
        }

        [Fact]
        public void CreateHandlerValidate()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE testTable );";
            recordService.manageTable();
            Assert.False(createHandler.ValidateInput());
        }

        //[Fact]
        //public void CreateHandlerProcess()
        //{
        //    RecordService.Messages.Clear();
        //    RecordService.records.Clear();
        //    RecordService.input = "TABLE CREATE testTable (string name, string nickname, int32 age, int32 weight);";
        //    recordService.manageTable();
        //    Assert.Equal(new Dictionary<string, string>() {"name": string }, RecordService.records[0].columns);
        //}

        //Tests for INSERT statement-------------------------------------------------------------------------------------------

        [Fact]
        public void InsertInputMissingTableName()
        {
            Messages.Clear();
            records.Clear();
            Input = "INSERT INTO (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Table name is missing" });
        }

        [Fact]
        public void InsertStatementIsInWrongPlace()
        {
            Messages.Clear();
            records.Clear();
            Input = "INTO INSERT testTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void InsertStatementsValuesAreMissing()
        {
            Messages.Clear();
            records.Clear();
            Input = "INSERT INTO testTable ();";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "You are missing values" });
        }

        [Fact]
        public void InsertStatementsBracketMissing()
        {
            Messages.Clear();
            records.Clear();
            Input = "INSERT INTO testTable );";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "You are missing values", "( or ) is missing" });
        }

        [Fact]
        public void InsertInputWithoutSemicolon()
        {
            Messages.Clear();
            records.Clear();
            Input = "INSERT INTO myTable (József, Józsi, 60, 92)";
            recordService.manageTable();

            Assert.Equal(Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void InsertInputParserError()
        {
            Messages.Clear();
            records.Clear();
            Input = "CREATE TABLE myTable (string name, string nickname, int32 age, int32 weight);";
            recordService.manageTable();
            Messages.Clear();
            Input = "INSERT INTO myTable (József, Józsi, hatvan, 92);";
            recordService.manageTable();

            Assert.Equal(Messages, new List<string>() { "State is correct", "Table Exist", "String could not be parsed." });
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
            Messages.Clear();
            records.Clear();
            Input = "DELETE TABLE myTable";
            recordService.manageTable();

            Assert.Equal(Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void DeletetSatementIsInWrongPlace()
        {
            Messages.Clear();
            records.Clear();
            Input = "myTable DELETE TABLE;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void DeleteInputWithTooManyInputs()
        {
            Messages.Clear();
            records.Clear();
            Input = "DELETE TABLE myTable kiskutya;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "You entered to many information" });
        }

        [Fact]
        public void DeleteInputWithoutTableKeyword()
        {
            Messages.Clear();
            records.Clear();
            Input = "DELETE myTable;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Missing TABLE keyword" });
        }

        //Tests for SELECT statement-------------------------------------------------------------------------------------------

        [Fact]
        public void SelectInputWithoutSemicolon()
        {
            Messages.Clear();
            records.Clear();
            Input = "SELECT name, age FROM myTable";
            recordService.manageTable();

            Assert.Equal(Messages, new List<string>() { "State is correct", "you are missing the ; symbol" });
        }

        [Fact]
        public void SelectSatementIsInWrongPlace()
        {
            Messages.Clear();
            records.Clear();
            Input = "name, age SELECT FROM myTable;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "Statement is in Wrong Place Start your input with it!" });
        }

        [Fact]
        public void SelectInputHaveMoreValuesNextToTheStarSymbol()
        {
            Messages.Clear();
            records.Clear();
            Input = "SELECT name, age, * FROM myTable;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "you are not able to use * and other column name in the same time" });
        }

        [Fact]
        public void SelectInputHaveMissingValues()
        {
            Messages.Clear();
            records.Clear();
            Input = "SELECT FROM myTable;";
            recordService.manageTable();
            Assert.Equal(Messages, new List<string>() { "State is correct", "you are missing something" });
        }
    }
}