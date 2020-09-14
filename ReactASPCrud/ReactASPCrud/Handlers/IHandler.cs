namespace ReactASPCrud.Services
{
    public interface IHandler
    {
        void SetNextHandler(IHandler handler);
        void Process();
        void SplitInput();
        bool ValidateInput();
    }
}