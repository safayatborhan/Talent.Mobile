using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Mobile.Interface
{
    public interface INetworkOperation
    {
        string GetIPAddress();
        bool IsInternetConnectionAvailable();
    }
}
