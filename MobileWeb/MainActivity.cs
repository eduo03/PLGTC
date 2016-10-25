using System;

using Android.App;
using Mono;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Graphics;

namespace MobileWeb.Activities
{
	//[Activity (Label = "PLGTC",MainLauncher=true, Theme = "@android:style/Theme.Light.NoTitleBar")]
	[Activity (Label = "PLGTC", Theme = "@android:style/Theme.Light.NoTitleBar")]	
	public class MainActivity : Activity
	{
		WebView web_view;
		bool doubleBackToExitPressedOnce = false;
	
		string url="http://192.168.0.8";
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			web_view = FindViewById<WebView> (Resource.Id.LocalWebView);
			web_view.Settings.JavaScriptEnabled = true;
			web_view.SetWebViewClient (new HelloWebViewClient(this)); 
			web_view.LoadUrl (url);
		}




		public class HelloWebViewClient : WebViewClient
		{
			public Activity mActivity;
			public HelloWebViewClient(Activity mActivity){
				this.mActivity=mActivity;
			}

			public void onPageFinished(WebView view, String url) {
				//code to dismiss dialog	//progressDialog.Cancel();
			
				base.OnPageFinished (view, url);
				Toast.MakeText(mActivity,"3",ToastLength.Long).Show();
			}

			public override bool ShouldOverrideUrlLoading (WebView view, string url)
			{
				view.LoadUrl (url);

				Toast.MakeText(mActivity,"Please Wait Retrieving Data",ToastLength.Long).Show();
				//var progressDialog = ProgressDialog.Show(mActivity, "Please wait...", "Downloading Data From Server...", true);
				return true;
			}
			public void onPageStarted(WebView view, String url) {
		
				Toast.MakeText(mActivity,"21111111111111111111",ToastLength.Long).Show();
				base.OnPageFinished (view, url);
				//var progressDialog = ProgressDialog.Show(mActivity, "Please wait...", "Downloading Data From Server...", true);
			}


		}

		public override void OnBackPressed ()
		{
			//if (doubleBackToExitPressedOnce) {
				//base.OnBackPressed ();
				//Java.Lang.JavaSystem.Exit (0);
				//this.finis();
				//System.Environment.Exit(0);
				//System.exit(0
			
				Finish();
			//	Android.OS.Process.KillProcess (Android.OS.Process.MyPid ());
				//return;
			//} 


			//this.doubleBackToExitPressedOnce = true;
			//Toast.MakeText (this, "Press back again to exit", ToastLength.Short).Show ();

			//new Handler ().PostDelayed (() => {
			//	doubleBackToExitPressedOnce = false;
			//}, 2000);
		}
	
		public override bool OnKeyUp(Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Menu) {
				var inputView = LayoutInflater.Inflate(Resource.Layout.LayInputURL, null);
				var builder = new AlertDialog.Builder(this);
				builder.SetTitle("Change Server Address");
				builder.SetMessage("Server Address: "+ url);
				builder.SetView(inputView);
				builder.SetPositiveButton("Change", OkDialog_Clicked);
				builder.SetNegativeButton("Cancel", delegate { builder.Dispose(); });
				builder.Show();
			}
			return base.OnKeyUp (keyCode, e);
		}

		private void OkDialog_Clicked(object sender, DialogClickEventArgs args)
		{
			var dialog = (AlertDialog)sender;
			var txtnewurl = (EditText)dialog.FindViewById (Resource.Id.txturl);
			url=txtnewurl.Text;

			web_view.LoadUrl (url);
			web_view.SetWebViewClient(new WebViewClient());
		}

	}
}


