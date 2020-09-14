using System;
using System.Collections.Generic;
using System.Dynamic;
using ReactASPCrud.Models;

namespace ReactASPCrud.Services
{
    public abstract class BaseHandler : RecordService, IHandler
    {

        public IHandler _nextHandler;

        public BaseHandler() : base()
        {
         
            _nextHandler = null;
        }

        public void SetNextHandler(IHandler handler)
        {
            _nextHandler = handler;
        }

        public virtual void Process()
        {
            throw new NotImplementedException();
        }

        public virtual void SplitInput()
        {
            if (Input.Contains("("))
            {
                int valuesStartFrom = Input.IndexOf("(");
                string values = Input.Replace(",", "").Substring(Input.Length - (Input.Length - (valuesStartFrom + 1)));
                inputStringSlices = values.Substring(0, values.Length - 2).Split(" ");
                string keyvalues = Input.Substring(0, valuesStartFrom - 1);
                keyWords = keyvalues.Split(" ");
            }
            else
            {
                string values = Input.Replace(",", "");
                keyWords = values.Remove(values.Length - 1).Split(" ");
                inputStringSlices = new string[] { "" };
            }
        }

        public virtual bool ValidateInput()
        {
            throw new NotImplementedException();
        }


    }
}