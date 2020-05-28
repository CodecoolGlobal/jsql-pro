using System;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class DeleteHandler : BaseHandler
    {

        private int tableIndexSelect;
        public DeleteHandler() { }

        public override void Process()
        {
            SplitInput();
            if (RecordService.input.Contains("DELETE"))
            {
                ValidateInput();
                if (RecordService.input.IndexOf("DELETE").Equals(0) && tableExist())
                {
                    tableIndexSelect = getTableIndexSelect();
                    if (tableIndexSelect >= 0)
                    {
                        RecordService.records.RemoveAt(tableIndexSelect);
                    }
                }
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
                throw new Exception("input is not a Deletion");
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


        public int getTableIndexSelect()
        {
            int tableInx = -1;
            for (int i = 0; i < RecordService.records.Count; i++)
            {
                if (RecordService.records[i].Name.Equals(RecordService.keyWords[RecordService.keyWords.Length - 1]))
                {
                    tableInx = i;
                }
                else
                {
                    continue;
                }
            }
            return tableInx;
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
            if (!RecordService.input.IndexOf("DELETE").Equals(0))
            {
                RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
            }
            if (RecordService.keyWords.Length > 3)
            {
                RecordService.Messages.Add("You entered to many information");
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