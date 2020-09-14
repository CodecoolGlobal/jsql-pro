using System;
using System.Linq;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class CreateHandler : BaseHandler
    {
        public CreateHandler() : base() { }

        public override void Process()
        {
            SplitInput();
            if (Input.Contains("CREATE"))
            {
                if (ValidateInput() && Input.IndexOf("CREATE").Equals(0) && !tableExist())
                {
                    Table table = new Table();
                    table.Name = keyWords[2];
                    for (int i = 0; i < inputStringSlices.Length - 1; i += 2)
                    {
                        table.addHeader(inputStringSlices[i + 1], inputStringSlices[i]);
                    }
                    records.Add(table);
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


        public override bool ValidateInput()
        {
            bool inputIsValid = true;

            if (!(inputStringSlices.Length % 2).Equals(0))
            {
                Messages.Add("values in wrong format");
                inputIsValid = false;
            }
            if (!Input.Contains(";"))
            {
                Messages.Add("you are missing the ; symbol");
                inputIsValid = false;
            }
            if (tableExist())
            {
                Messages.Add("Table Exist");
            }
            if (keyWords.Contains("CREATE") && keyWords.Contains("TABLE") && keyWords.Length < 3)
            {
                Messages.Add("Table name is missing");
                inputIsValid = false;
            }
            if (!Input.IndexOf("CREATE").Equals(0))
            {
                Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (!inputStringSlices.Equals(null) && inputStringSlices.Length < 2)
            {
                Messages.Add("values are missing");
                inputIsValid = false;
            }
            if (!Input.Contains("(") || (!Input.Contains(")")))
            {
                Messages.Add("( or ) is missing");
                inputIsValid = false;
            }

            return inputIsValid;
        }


    }
}