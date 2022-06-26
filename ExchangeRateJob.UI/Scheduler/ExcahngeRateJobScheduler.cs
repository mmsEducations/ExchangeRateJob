using ExchangeRateJob.UI.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateJob.UI.Scheduler
{
    public class ExcahngeRateJobScheduler
    {
        public static async Task<IScheduler> GetJobSchedulerAync()
        { 
            //1 
            IScheduler schedulerExcahngeRate = await new StdSchedulerFactory().GetScheduler();
            await schedulerExcahngeRate.Start();


            //2
            IJobDetail jobDetailExcahngeRate = JobBuilder.Create<ExchangeRateJobs>().WithIdentity("ExchangeRateJobs").Build();

            //3
            ITrigger triggerExcahngeRate = TriggerBuilder.Create().WithIdentity("ExchangeRateJobs").StartNow().WithSimpleSchedule(work => work.WithIntervalInSeconds(30).RepeatForever()).Build();

            //4
            await schedulerExcahngeRate.ScheduleJob(jobDetailExcahngeRate, triggerExcahngeRate);

            return schedulerExcahngeRate;

        }
    }
}
