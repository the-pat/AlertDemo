using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Microsoft.AspNet.Identity;
using Twilio;

namespace AlertDemo.Services
{
    public class SmsService : IIdentityMessageService
    {
        #region Fields and Properties

        private readonly TwilioRestClient _service;

        #endregion

        #region Constructors

        /// <summary>
        /// The base constructor.
        /// Takes a account sid and auth token to get a 
        /// twilio rest client object
        /// </summary>
        /// <param name="acctSid">
        /// The account sid for twilio.
        /// </param>
        /// <param name="authToken">
        /// The auth token for twilio.
        /// </param>
        public SmsService(string acctSid, string authToken)
        {
            this._service = new TwilioRestClient(acctSid, authToken);
        }

        /// <summary>
        /// The default constructor.
        /// Uses the account sid and auth token stored in the web.config.
        /// </summary>
        public SmsService() : this(WebConfigurationManager.AppSettings["TwilioAccountSid"], 
                                   WebConfigurationManager.AppSettings["TwilioAuthToken"])
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Send a message to the specifed recipient.
        /// </summary>
        /// <param name="from">
        /// The Twilio number sending the message.
        /// </param>
        /// <param name="to">
        /// The message recipient.
        /// </param>
        /// <param name="body">
        /// The message body.
        /// </param>
        /// <returns>
        /// A Twilio message.
        /// </returns>
        public Message SendMessage(string from, string to, string body)
        {
            return this._service.SendMessage(from, to, body);
        }

        /// <summary>
        /// Expose a way to send SMS messages.
        /// </summary>
        /// <param name="message">
        /// A message with a body, destination, and subject.
        /// </param>
        /// <returns>
        /// The task.
        /// </returns>
        public Task SendAsync(IdentityMessage message)
        {
            var from = WebConfigurationManager.AppSettings["TwilioSmsNumber"];
            var result = this._service.SendMessage(from, message.Destination, message.Body);

            Trace.TraceInformation(result.Status);

            // Twilio doesn't currently have an async API, so we return success.
            return Task.FromResult(0);
        }

        #endregion
    }
}