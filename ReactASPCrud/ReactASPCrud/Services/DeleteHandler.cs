using System;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class DeleteHandler : BaseHandler
    {

        private int tableIndexSelect;

        public override void Process()
        {
            SplitInput();
            if (input.Contains("DELETE"))
            {
                if (ValidateInput() && input.IndexOf("DELETE").Equals(0) && tableExist())
                {
                    tableIndexSelect = getTableIndexSelect();
                    if (tableIndexSelect >= 0)
                    {
                        records.RemoveAt(tableIndexSelect);
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
            foreach (Table table in records)
            {
                if (table.Name.Equals(keyWords[2]))
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
            for (int i = 0; i < records.Count; i++)
            {
                if (records[i].Name.Equals(keyWords[keyWords.Length - 1]))
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

            if (!input.Contains(";"))
            {
                Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (tableExist())
            {
                Messages.Add("Table Exist");
            }
            if (!input.Contains("TABLE"))
            {
                Messages.Add("Missing TABLE keyword");
                inputIsValid = false;
            }
            if (!input.IndexOf("DELETE").Equals(0))
            {
                Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (keyWords.Length > 3)
            {
                Messages.Add("You entered to many information");
                inputIsValid = false;
            }

            return inputIsValid;
        }
    }
}