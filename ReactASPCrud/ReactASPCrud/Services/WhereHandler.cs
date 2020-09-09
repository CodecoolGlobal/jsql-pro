using System;
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
                if (ValidateInput())
                {
                    tableIndex = getTableIndex();
                    Table table = RecordService.records[tableIndex];
                    //itt kell nekem a Recordservice.selected expado objecteket tarolo lista es abban vegrehajtani a where statementet
                    
                    //where int nagyobb vagy kissebb vagy egyenlo
                    
                }
            }
            else
            {
                if (_nextHandler != null)
                {
                    _nextHandler.Process();
                }
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

        public int getTableIndex()
        {
            int tableInx = -1;
            for (int i = 0; i < RecordService.records.Count; i++)
            {
                //�j m�dszer kell a t�bla nev�nek a megszerz�s�re
                if (RecordService.records[i].Name.Equals(RecordService.keyWords[2]))
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
            if (RecordService.keyWords.Contains("INSERT") && RecordService.keyWords.Contains("INTO") && RecordService.keyWords.Length < 3)
            {
                RecordService.Messages.Add("Table name is missing");
                inputIsValid = false;
            }
            if (tableExist())
            {
                RecordService.Messages.Add("Table Exist");
            }
            if (!RecordService.input.IndexOf("INSERT").Equals(0))
            {
                RecordService.Messages.Add("Statement is in Wrong Place Start your input with it!");
                inputIsValid = false;
            }
            if (RecordService.inputStringSlices.Length < 2)
            {
                RecordService.Messages.Add("You are missing values");
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