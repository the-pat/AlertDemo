using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace AlertDemo.Services
{
    public class SmsService : IIdentityMessageService
    {
        private readonly TwilioRestClient _service;
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }
    }
}