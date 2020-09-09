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
                if (ValidateInput() && RecordService.input.IndexOf("CREATE").Equals(0) && !tableExist())
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
                //throw new Exception("input is not a Creation");
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


        public override bool ValidateInput()
        {
            bool inputIsValid = true;

            if (!(RecordService.inputStringSlices.Length % 2).Equals(0))
            {
                RecordService.Messages.Add("values in wrong format");
                inputIsValid = false;
            }
            if (!RecordService.input.Contains(";"))
            {
                RecordService.Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (tableExist())
            {
                RecordService.Messages.Add("Table Exist");
            }
            if (RecordService.keyWords.Contains("CREATE") && RecordService.keyWords.Contains("TABLE") && RecordService.keyWords.Length < 3)
            {
                RecordService.Messages.Add("Table name is missing");
                inputIsValid = false;
            }
            if (!RecordService.input.IndexOf("CREATE").Equals(0))
            {
                RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (!RecordService.inputStringSlices.Equals(null) && RecordService.inputStringSlices.Length < 2)
            {
                RecordService.Messages.Add("values are missing");
                inputIsValid = false;
            }
            if (!RecordService.input.Contains("(") || (!RecordService.input.Contains(")")))
            {
                RecordService.Messages.Add("( or ) is missing");
                inputIsValid = false;
            }

            return inputIsValid;
        }


    }
}