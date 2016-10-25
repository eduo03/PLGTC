
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

namespace MobileWeb.Activities
{
	//[Activity (Label = "Census", Theme = "@android:style/Theme.Holo.Light.NoActionBar")]		
	[Activity (Label = "PLGTC",MainLauncher=true , Theme = "@android:style/Theme.Holo.Light.NoActionBar")]			
	public class ActStart : Activity
	{
		System.Timers.Timer t;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

				SetContentView (Resource.Layout.MainLOGO);
				t = new System.Timers.Timer ();
				t.Interval = 1500;
				t.Elapsed += new System.Timers.ElapsedEventHandler (t_Elapsed);
				t.Start ();

		}

		protected void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			t.Stop();
			var intent = new Intent ();
			intent.SetClass (this, typeof(MainActivity));
			StartActivity (intent);
		

		}


	}
}

