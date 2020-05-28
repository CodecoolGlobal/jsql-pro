using Xunit;

namespace ReactASPCrud.Services
{
    public class Tests
    {
        [Fact]
        public void TableExistTest()
        {
            Models.Table table = new Models.Table();
            table.Name = "testName";
            RecordService.keyWords = new string[] {"CREATE", "TABLE", "testName"};
            RecordService.records.Add(table);
            CreateHandler createHandler = new CreateHandler();
            Assert.Equal(true, createHandler.tableExist());
        }
    }
}