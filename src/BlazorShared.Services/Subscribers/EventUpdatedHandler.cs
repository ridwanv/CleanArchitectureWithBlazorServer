using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorShared.Events;
using BlazorShared.Models;
using MediatR;

namespace BlazorShared.Services.Subscribers;
public class EventUpdatedHandler : INotificationHandler<CreatedEvent<Event>>
{
    public Task Handle(CreatedEvent<Event> notification, CancellationToken cancellationToken)
    {
        SendEmails();
        return Task.CompletedTask;
    }

    private void SendEmails()
    {
        // Send a reminder to the merchant's calendar
    }
}
