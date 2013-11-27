using System;
using Quartz;

namespace QuartzPrototype.MyQuartz
{
    public class MockJob
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string TriggerName { get; set; }
        public string TriggerGroup { get; set; }
        public string TriggerType { get; set; }
        public TriggerState TriggerState { get; set; }
        public DateTimeOffset? TriggerNextFireTime { get; set; }
        public DateTimeOffset? TriggerPreviousFireTime { get; set; }
    }
}