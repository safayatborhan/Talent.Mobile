using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using Talent.Mobile.Interface;
using System.Net;
using Xamarin.Forms;
using Talent.DependencyService;

[assembly: Dependency(typeof(NetworkOperation))]
namespace Talent.DependencyService
{
    public class NetworkOperation : INetworkOperation
    {
        public string GetIPAddress()
        {
            string ipAddress = string.Empty;

            foreach (IPAddress adress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                ipAddress = adress.ToString();
                break;
            }
            return ipAddress;
        }

        public bool IsInternetConnectionAvailable()
        {
            bool isConnected;

            var connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Android.App.Application.ConnectivityService);

            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnected)
            {
                isConnected = true;
            }
            else
            {
                isConnected = false;
            }
            return isConnected;
        }
    }
}