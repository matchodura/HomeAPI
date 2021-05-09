using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAPI.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace HomeAPI.HubConfig
{
    public class MotionHub : Hub<INotifyHubClient>
    {
    }
}
