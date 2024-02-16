// from environment variables

using System;
using System.Collections.Generic;

namespace s21_d03_Sources
{
    public class EnvSource : IConfigurationSource
    {
        public int Priority => 3;

        public Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string? apiKey = Environment.GetEnvironmentVariable("API_KEY");
            if (apiKey is not null)
            {
                result.Add("API_KEY", apiKey);
            }

            string? databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            if (databaseUrl is not null)
            {
                result.Add("DATABASE_URL", databaseUrl);
            }

            return result;
        }
    }
}