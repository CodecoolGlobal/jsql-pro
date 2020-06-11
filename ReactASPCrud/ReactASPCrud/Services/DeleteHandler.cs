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
                if (ValidateInput() && RecordService.input.IndexOf("DELETE").Equals(0) && tableExist())
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
                //throw new Exception("input is not a Deletion");
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


        public override bool ValidateInput()
        {
            bool inputIsValid = true;

            if (!RecordService.input.Contains(";"))
            {
                RecordService.Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (tableExist())
            {
                RecordService.Messages.Add("Table Exist");
            }
            if (!RecordService.input.IndexOf("DELETE").Equals(0))
            {
                RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (RecordService.keyWords.Length > 3)
            {
                RecordService.Messages.Add("You entered to many information");
                inputIsValid = false;
            }

            return inputIsValid;
        }
    }
}