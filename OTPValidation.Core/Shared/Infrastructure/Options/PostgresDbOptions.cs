namespace OTPValidation.Core.Shared.Infrastructure.Options
{
    public sealed class PostgresDbOptions
    {
        public const string SectionName = "Connection:Postgres";
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string BuildConnectionString()
        {
            return $"Host={Host};Port={Port};Database={Database};Username={Username};Password={Password}";
        }
    }
}
