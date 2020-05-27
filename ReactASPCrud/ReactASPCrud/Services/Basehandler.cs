using System;

namespace ReactASPCrud.Services
{
    public abstract class BaseHandler : IHandler
    {
        public IHandler _nextHandler;

        public BaseHandler()
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
            if (RecordService.input.Contains("("))
            {
                int valuesStartFrom = RecordService.input.IndexOf("(");
                string values = RecordService.input.Replace(",", "").Substring(RecordService.input.Length - (RecordService.input.Length - (valuesStartFrom + 1)));
                RecordService.inputStringSlices = values.Substring(0, values.Length - 2).Split(" ");
                string keyvalues = RecordService.input.Substring(0, valuesStartFrom - 1);
                RecordService.keyWords = keyvalues.Split(" ");
            }
            else
            {
                string values = RecordService.input.Replace(",", "");
                RecordService.keyWords = values.Remove(values.Length - 1).Split(" ");
            }
        }
    }
}