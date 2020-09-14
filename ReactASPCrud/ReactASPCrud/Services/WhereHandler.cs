using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ReactASPCrud.Services
{
    public class WhereHandler : BaseHandler
    {

        private int tableIndex;
        public static List<string> whereKeyWords = new List<string>();

        public override void Process()
        {
            SplitInput();
            if (Input.Contains("WHERE"))
            {
                getWhereKeywords();
                List<ExpandoObject> whereInSelect = new List<ExpandoObject>();
                foreach (var exp in SelectHandler.selectedObjects)
                {
                    foreach (KeyValuePair<string, object> kvp in exp)
                    {
                        if (kvp.Key.Equals(whereKeyWords[1]) && operate(kvp.Value))
                        {
                            whereInSelect.Add(exp);
                            break;
                        }
                    }
                }
                //selected columns
                selected.Clear();
                foreach (var exp in whereInSelect)
                {
                    dynamic expado = new ExpandoObject();

                    foreach (KeyValuePair<string, object> kvp in exp)
                    {
                        if (SelectHandler.selectedValues.Contains(kvp.Key))
                        {
                            Util.AddProperty(expado, kvp.Key, kvp.Value);
                        }
                    }
                    selected.Add(expado);
                }

                // if (ValidateInput())
                // {

                //itt kell nekem a Recordservice.selected expado objecteket tarolo lista es abban vegrehajtani a where statementet


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

        public bool operate(object value)
        {
            if (whereKeyWords[2].Equals(">") && int.TryParse(value.ToString(), out int result) && Convert.ToInt64(value) > Convert.ToInt64(whereKeyWords[3]))
            {
                return true;
            }
            if (whereKeyWords[2].Equals("<") && int.TryParse(value.ToString(), out int result1) && Convert.ToInt64(value) < Convert.ToInt64(whereKeyWords[3]))
            {
                return true;
            }
            if (whereKeyWords[2].Equals(">=") && int.TryParse(value.ToString(), out int result2) && Convert.ToInt64(value) >= Convert.ToInt64(whereKeyWords[3]))
            {
                return true;
            }
            if (whereKeyWords[2].Equals("<=") && int.TryParse(value.ToString(), out int result3) && Convert.ToInt64(value) <= Convert.ToInt64(whereKeyWords[3]))
            {
                return true;
            }
            if (whereKeyWords[2].Equals("=") && int.TryParse(value.ToString(), out int result4) && Convert.ToInt64(value) == Convert.ToInt64(whereKeyWords[3]))
            {
                return true;
            }
            if (whereKeyWords[2].Equals("=") && value.Equals(whereKeyWords[3]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void getWhereKeywords()
        {
            int index = Array.IndexOf(keyWords, "WHERE");
            for (int i = index; i < keyWords.Length; i++)
            {
                whereKeyWords.Add(keyWords[i]);
            }
        }


        // public override bool ValidateInput()
        // {
        //     bool inputIsValid = true;



        //     if (!RecordService.input.Contains(";"))
        //     {
        //         RecordService.Messages.Add("you are missing the ; symbol");
        //         inputIsValid = false;
        //     }
        //     if (RecordService.keyWords.Contains("INSERT") && RecordService.keyWords.Contains("INTO") && RecordService.keyWords.Length < 3)
        //     {
        //         RecordService.Messages.Add("Table name is missing");
        //         inputIsValid = false;
        //     }
        //     if (tableExist())
        //     {
        //         RecordService.Messages.Add("Table Exist");
        //     }
        //     if (!RecordService.input.IndexOf("INSERT").Equals(0))
        //     {
        //         RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
        //         inputIsValid = false;
        //     }
        //     if (RecordService.inputStringSlices.Length < 2)
        //     {
        //         RecordService.Messages.Add("You are missing values");
        //         inputIsValid = false;
        //     }
        //     if (!RecordService.input.Contains("(") || (!RecordService.input.Contains(")")))
        //     {
        //         RecordService.Messages.Add("( or ) is missing");
        //         inputIsValid = false;
        //     }

        //     return inputIsValid;
        // }

    }
}