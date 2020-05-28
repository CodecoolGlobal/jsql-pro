using System;
using System.Linq;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class CreateHandler : BaseHandler
    {
        public CreateHandler() { }

        public override void Process()
        {
            SplitInput();
            if (RecordService.input.Contains("CREATE"))
            {
                ValidateInput();
                if (RecordService.input.IndexOf("CREATE").Equals(0) && !tableExist())
                {
                    Table table = new Table();
                    table.Name = RecordService.keyWords[2];
                    for (int i = 0; i < RecordService.inputStringSlices.Length - 1; i += 2)
                    {
                        table.addHeader(RecordService.inputStringSlices[i + 1], RecordService.inputStringSlices[i]);
                    }
                    RecordService.records.Add(table);
                }
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


        public override void ValidateInput()
        {
            RecordService.Messages.Clear();
            StatementNameIsInInput();
            if (!RecordService.input.Contains(";"))
            {
                RecordService.Messages.Add("you are missing the ; symbol");
            }
            if (tableExist())
            {
                RecordService.Messages.Add("Table Exist");
            }
            if (!RecordService.input.IndexOf("CREATE").Equals(0))
            {
                RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
            }
            if (RecordService.keyWords.Length < 1)
            {
                RecordService.Messages.Add("values are missing");
            }
            if (!RecordService.input.Contains("(") || (!RecordService.input.Contains(")")))
            {
                RecordService.Messages.Add("( or ) is missing");
            }
        }

        public void StatementNameIsInInput()
        {
            foreach (var inp in RecordService.AccessableInputs)
            {
                if (RecordService.input.Contains(inp))
                {
                    RecordService.Messages.Add("State is correct");
                }
                else
                {
                    RecordService.Messages.Add("Your input is missing a state or it is in incorrect form. Use Uppercase Letters!");
                }
            }
        }
    }
}