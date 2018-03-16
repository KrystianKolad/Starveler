using System;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Starveler.Service.Extensions
{
    public static class EmailConfigurationExtensions
    {
        private static string emailSectionName = "Email";
       
        public static IConfigurationSection GetEmailConfigurationSection(this IConfiguration configuration)
        {
            var section = configuration.GetSection(emailSectionName);
            EnsureSpecificSectionExists(section, emailSectionName);
            
            return section;
        }

        private static void EnsureSpecificSectionExists(IConfigurationSection section, string sectionName)
        {
            if (!section.GetChildren().Any())
			{
				throw new ArgumentException($"Unable to configuration section '{sectionName}'. Make sure it exists in the provided configuration");
			}
        }
    }
}