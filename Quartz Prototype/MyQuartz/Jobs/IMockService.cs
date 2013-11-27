using System.Diagnostics;

namespace QuartzPrototype.MyQuartz.Jobs
{
    public interface IMockService
    {
        void Hello();
    }

    public class MockService : IMockService
    {
        public void Hello()
        {
            Trace.WriteLine("hello");
        }
    }
}
