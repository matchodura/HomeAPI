using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface INotifyHubClient
    {
        Task BroadcastMessage(string message);
    }
}
