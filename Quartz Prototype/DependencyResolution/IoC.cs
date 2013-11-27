using Quartz;
using Quartz.Impl;
using QuartzPrototype.MyQuartz.Jobs;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace QuartzPrototype.DependencyResolution 
{
    public static class IoC
    {
        public static IContainer Initialize() 
        {
            ObjectFactory.Initialize(x =>
                                         {
                                             x.Scan(s =>
                                                        {
                                                            s.TheCallingAssembly();
                                                            s.WithDefaultConventions();
                                                        });
                                             x.Scan(s =>
                                             {
                                                 s.TheCallingAssembly();
                                                 s.WithDefaultConventions();
                                                 s.AddAllTypesOf<IJob>().NameBy(c => c.Name);
                                             });

                                             Configure(x);
                                         });

            return ObjectFactory.Container;
        }

        private static void Configure(IRegistry registry)
        {
            registry.SelectConstructor(() => new StdSchedulerFactory());
            registry.For<ISchedulerFactory>().Use<StdSchedulerFactory>();
            registry.For<IScheduler>().Use(() => ObjectFactory.GetInstance<ISchedulerFactory>().GetScheduler());

            registry.For<IMockService>().Use<MockService>();
        }
    }
}