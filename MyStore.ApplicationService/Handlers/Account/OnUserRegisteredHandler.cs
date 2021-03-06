using System.Collections.Generic;
using DomainNotificationHelper;
using MyStore.ApplicationService.Services.Common;
using MyStore.Domain.Account.Events.UserEvents;

namespace MyStore.ApplicationService.Handlers.Account
{
    public class OnUserRegisteredHandler : IHandler<OnUserRegisteredEvent>
    {

        public void Handle(OnUserRegisteredEvent args)
        {
            var user = args.User;
            var title = args.EmailTitle;
            var body = args.EmailBody.Replace("##EMAIL##", args.User.Email);

            EmailService.Send(user.Email, title, body);
        }

        public bool HasNotifications()
        {
            return false;
        }

        public IEnumerable<OnUserRegisteredEvent> Notify()
        {
            return null;
        }

        public void Dispose()
        {
           
        }
    }
}