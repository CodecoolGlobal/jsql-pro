using System;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class CreateHandler : BaseHandler
    {
        public CreateHandler(){}

        public override void Process()
        {
            if (RecordService.input.Contains("CREATE") && RecordService.input.IndexOf("CREATE").Equals(0) && !tableExist())
            {
                SplitInput();
                Table table = new Table();
                table.Name = RecordService.keyWords[2];
                for (int i = 0; i < RecordService.inputStringSlices.Length - 1; i += 2)
                {
                    table.addHeader(RecordService.inputStringSlices[i + 1], RecordService.inputStringSlices[i]);
                }
                RecordService.records.Add(table);
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                throw new Exception("input is not a Creation");
            }
        }

        public bool tableExist()
        {
            bool tableExist = false;
            foreach (Table table in RecordService.records)
            {
                if (table.Name.Equals(RecordService.keyWords[2]))
                {
                    tableExist = true;
                }
                else
                {
                    continue;
                }
            }
            return tableExist;
        }
    }
}