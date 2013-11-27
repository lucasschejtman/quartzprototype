using System;
using System.Collections.Generic;
using System.Linq;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace QuartzPrototype.MyQuartz
{
    public class Helper
    {
        private IScheduler _scheduler;
        private static readonly Lazy<Helper> Instance = new Lazy<Helper>(() => new Helper());

        public static Helper Instace
        {
            get { return Instance.Value; }
        }
        
        private Helper()
        {
        }

        public void Start()
        {
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            _scheduler = schedFact.GetScheduler();

            // Non .config file way of doing it
            //var job = JobBuilder.Create<AddValueJob>().WithIdentity("AddValue", "Group").Build();
            //job.JobDataMap.Put("ValueToAdd", 1);

            //var trigger = (ICronTrigger) TriggerBuilder.Create().WithIdentity("AddValue Trigger", "Group")
            //                                           .WithCronSchedule("0/1 * * * * ?").Build();

            //_scheduler.ScheduleJob(job, trigger);

            _scheduler.Start();
        }

        public int Value { get; set; }

        public IEnumerable<MockJob> Jobs
        {
            get
            {
                var jobGroups = _scheduler.GetJobGroupNames();

                return from @group in jobGroups 
                       let groupMatcher = GroupMatcher<JobKey>.GroupContains(@group) 
                       let jobKeys = _scheduler.GetJobKeys(groupMatcher) from jobKey in jobKeys 
                       let detail = _scheduler.GetJobDetail(jobKey) 
                       let triggers = _scheduler.GetTriggersOfJob(jobKey) from trigger in triggers 
                       select new MockJob
                                        {
                                            Name = jobKey.Name,
                                            Group = @group,
                                            Description = detail.Description,
                                            TriggerName =  trigger.Key.Name,
                                            TriggerGroup = trigger.Key.Group,
                                            TriggerType = trigger.GetType().Name,
                                            TriggerState = _scheduler.GetTriggerState(trigger.Key),
                                            TriggerNextFireTime = trigger.GetNextFireTimeUtc(),
                                            TriggerPreviousFireTime = trigger.GetPreviousFireTimeUtc()
                                        }; 
            }
        }
    }
}