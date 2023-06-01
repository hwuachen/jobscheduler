namespace jobscheduler.Models
{
    public class JobBase
    {
        private readonly IConfiguration _configuration;
        public JobBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ExecuteJob(string username)
        {
            if (_configuration != null)
            {
                string pythonPath = _configuration.GetSection("pythonPath").Value;
                Console.WriteLine($"ExecuteJob : {username} at pythonPath {pythonPath}");
            }
        }

        public void ScheduleJob(string username)
        {
            Console.WriteLine($"ScheduleJob : {username}");
        }

        public void ScheduleRecurringJob(string username)
        {
            Console.WriteLine($"ScheduleJob : {username}");
        }

        public void UnsubscribeJob(string username)
        {
            Console.WriteLine($"UnsubscribeJob : {username}");
        }
    }
}
