using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_e_Fashion.SignalRModels
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
