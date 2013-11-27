using Quartz;

namespace QuartzPrototype.MyQuartz.Jobs
{
    public class AddValueJob : IJob
    {
        private readonly IMockService _mockService;

        // Testing DI
        public AddValueJob(IMockService mockService)
        {
            _mockService = mockService;
        }

        public void Execute(IJobExecutionContext context)
        {
            _mockService.Hello();

            var data = context.MergedJobDataMap;
            var toAdd = int.Parse(data["ValueToAdd"].ToString());

            Helper.Instace.Value += toAdd;
            
            // Sliding timer
            // You can't update a trigger, you need to re schedule the job
            //var newTrigger = context.Trigger.GetTriggerBuilder()
            //                             .WithCronSchedule(string.Format("0/{0} * * * * ?", 3))
            //                             .Build();
            //context.Scheduler.RescheduleJob(new TriggerKey("triggerName"), newTrigger);

            // Error handling, job retry
            //try
            //{
            //    throw new Exception("test job retry exception");
            //}
            //catch (Exception e)
            //{
            //    Trace.WriteLine(e);

            //    var je = new JobExecutionException(e) {RefireImmediately = true};

            //    throw je;
            //}

            // Error handling, fine grain retry count
            // http://stackoverflow.com/questions/4408858/quartz-retry-when-failure
        }
    }
}