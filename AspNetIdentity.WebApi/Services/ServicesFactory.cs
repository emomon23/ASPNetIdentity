using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using AspNetIdentity.WebApi.Services.EmailServices;

namespace AspNetIdentity.WebApi.Services
{
    public interface IServicesFactory
    {
        IIdentityMessageService CreateEmailService(IIdentityMessageService emailSvc = null);
    }
    public class ServicesFactory : IServicesFactory
    {
        IIdentityMessageService emailService;

        public IIdentityMessageService CreateEmailService(IIdentityMessageService emailSvc = null)
        {
            emailService = emailSvc == null ? new EmailFileWriterService() : emailSvc;
            return emailService;
        }
    }
}