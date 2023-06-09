namespace Sample.ModularMonolith.Shared.Bones.Background
{
    internal class HangfireConfigurations
    {
        public string SchemaName { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int MaximumFailedJobs { get; set; }
        public int ProcessMonitorCheckingIntervalInSeconds { get; set; }
        public string[] Queues { get; set; }
    }
}
