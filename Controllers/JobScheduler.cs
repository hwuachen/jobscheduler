using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using jobscheduler.Models;

namespace jobscheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobScheduler : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public JobScheduler(IConfiguration iConfig)
        {
            _configuration = iConfig;
        }


        [HttpPost]
        [Route("api/ExecuteJob")]
        public IActionResult ExecuteJob(string username)
        {
            JobBase _obj = new JobBase(_configuration);
            var jobId = BackgroundJob.Enqueue(() => _obj.ExecuteJob(username));
            return Ok($"JobId: {jobId} complete. SendMail({username})");
        }

        [HttpPost]
        [Route("api/ScheduleJob")]
        public IActionResult ScheduleJob(string username)
        {
            JobBase _obj = new JobBase(_configuration);
            var jobId = BackgroundJob.Schedule(() => _obj.ScheduleJob(username), TimeSpan.FromMinutes(1));
            return Ok($"JobId: {jobId} scheduled. ScheduleJob will be run after 1 min");
        }

        [HttpPost]
        [Route("api/ScheduleRecurringJob")]
        [Obsolete]
        public IActionResult ScheduleRecurringJob(string username)
        {
            JobBase _obj = new JobBase(_configuration);
            RecurringJob.AddOrUpdate(() => _obj.ScheduleRecurringJob(username),
                                    Cron.Monthly);
            return Ok($"RecurringJob scheduled (monthly) for {username}.");
        }


        [HttpPost]
        [Route("api/UnsubscribeJob")]
        public IActionResult UnsubscribeJob(string username)
        {
            JobBase _obj = new JobBase(_configuration);
            var jobId = BackgroundJob.Enqueue(() => _obj.UnsubscribeJob(username));

            // create a background job that will wait for a successful completion of another job with JobId = jobId
            BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine($"JobId: {jobId}, confirmation emial sent to ({username})"));
            return Ok($"UnsubscribeJob done.");
        }


    }
}
