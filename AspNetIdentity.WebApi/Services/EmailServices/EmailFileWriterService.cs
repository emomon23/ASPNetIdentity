using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace AspNetIdentity.WebApi.Services.EmailServices
{
    public class EmailFileWriterService : IIdentityMessageService
    {
        string baseFilePath;

        public EmailFileWriterService()
        {
            string setting = ConfigurationManager.AppSettings["EmailFileWriterPath"];

            baseFilePath = string.IsNullOrEmpty(setting) ? @"C:\AspNetIdentity\Emails" : setting.ToString();

            if (!Directory.Exists(baseFilePath))
            {
                Directory.CreateDirectory(baseFilePath);
            }

            if (!baseFilePath.EndsWith("\\"))
            {
                baseFilePath += "\\";
            }
        }
        public async Task SendAsync(IdentityMessage message)
        {
            string scrubbedEmail = "EMail_" + message.Destination.Replace("@", "").Replace(".", "");

            string filePath = string.Format("{0}{1}{2}.txt", baseFilePath, scrubbedEmail, Guid.NewGuid().ToString().Substring(0, 5));
            string contents = string.Format("To: {0}\nSubject: {1}\n\n{2}", message.Destination, message.Subject, message.Body);

            File.WriteAllText(filePath, contents);
        }
    }
}