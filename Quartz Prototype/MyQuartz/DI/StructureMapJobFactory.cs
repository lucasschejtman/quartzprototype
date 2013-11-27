using System;
using System.Diagnostics;
using Quartz;
using Quartz.Spi;
using StructureMap;

namespace QuartzPrototype.MyQuartz.DI
{
    public class StructureMapJobFactory : IJobFactory
    {
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob)ObjectFactory.GetInstance(bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
                throw;
            }
        }

        public void ReturnJob(IJob job)
        {
            
        }
    }
}