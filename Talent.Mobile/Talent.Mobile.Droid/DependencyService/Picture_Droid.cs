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
using Talent.Mobile.Droid.DependencyService;
using Java.IO;
using Talent.Mobile.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_Droid))]

namespace Talent.Mobile.Droid.DependencyService
{
    public class Picture_Droid : IPicture
    {
        public void SavePictureToDisk(string filename, byte[] imageData,string documentType)
        {
            var dir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
            var pictures = dir.AbsolutePath;
            var userId = 20;
            string name = userId + "_" + documentType + ".jpg";
            string filePath = System.IO.Path.Combine(pictures, name);
            try
            {
                System.IO.File.WriteAllBytes(filePath, imageData);
                //mediascan adds the saved image into the gallery
                var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                //mediaScanIntent.SetData(Uri.FromFile(new File(filePath)));
                Android.Net.Uri contentUri = Android.Net.Uri.FromFile(new File(filePath));
                Xamarin.Forms.Forms.Context.SendBroadcast(mediaScanIntent);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }

        }
    }
}