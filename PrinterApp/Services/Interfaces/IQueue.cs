using PrinterApp.Services;

namespace PrinterApp.Interfaces
{
    public interface IQueue
    {
        void AddBack(PrintJob job);
        PrintJob RemoveFront();
        bool IsEmpty();
        int GetNumberOfJobs();
    }
}
