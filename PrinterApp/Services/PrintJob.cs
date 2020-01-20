
namespace PrinterApp.Services
{
    public class PrintJob : Base.Base
    {
        private int _numberOfPage { get; set; }
        private string _jobName { get; set; }

        public PrintJob(string jobName, int numberOfPages)
        {
            _numberOfPage = numberOfPages;
            _jobName = jobName;
        }

        public string GetJobName()
        {
            return _jobName;
        }

        public int GetNumberOfPages()
        {
            return _numberOfPage;
        }      
    }
}
