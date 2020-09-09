using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public class WhereHandler : BaseHandler
    {

        private int tableIndex;

        public WhereHandler() { }

        public override void Process()
        {
            SplitInput();
            if (RecordService.input.Contains("WHERE"))
            {
                RecordService.selected.Clear();
                foreach (var exp in SelectHandler.selectedObjects)
                {
                    dynamic expado = new ExpandoObject();

                    foreach (KeyValuePair<string, object> kvp in exp)
                    {
                        if (kvp.Key.Equals(RecordService.keyWords[1]) && operate(kvp.Value))
                        {
                            Util.AddProperty(expado, kvp.Key, kvp.Value);
                        }
                    }
                    RecordService.selected.Add(expado);

                    // if (ValidateInput())
                    // {

                    //itt kell nekem a Recordservice.selected expado objecteket tarolo lista es abban vegrehajtani a where statementet


                }
            }
            //where int nagyobb vagy kissebb vagy egyenlo

            // }
            // }
            // else
            // {
            //     if (_nextHandler != null)
            //     {
            //         _nextHandler.Process();
            //     }
            // }
        }

        public bool operate(object value)
        {
            if (RecordService.keyWords[2].Equals(">") && int.TryParse(value.ToString(), out int result) && Convert.ToInt64(value) > Convert.ToInt64(RecordService.keyWords[3]))
            {
                return true;
            }
            else
            {
                return false;
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