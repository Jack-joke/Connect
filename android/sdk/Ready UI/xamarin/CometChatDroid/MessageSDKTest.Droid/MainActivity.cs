using Android.App;
using Android.Widget;
using Android.OS;
using Com.Inscripts.Cometchat.Sdk;
using Com.Inscripts.Utils;
using Com.Orm;
using Com.Inscripts.Helpers;
using Com.Inscripts.Interfaces;
using System;

namespace MessageSDKTest.Droid
{

	[Activity(Label = "MessageSDKTest.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);


			LocalConfig.Initialize(this.ApplicationContext);
			SugarContext.Init(this.ApplicationContext);

			MessageSDK.SetUrl(this.ApplicationContext, "https://chat.phpchatsoftware.com/", null);

			button.Click += delegate
			{
				//This is for cloud
				//MessageSDK.SetApiKey (this.ApplicationContext, "10415x77177883eedf5255554e825180e563c1");
				//MessageSDK.Login (this.ApplicationContext, "user1", "user1", new MyCallback (successObj1 => MessageSDK.LaunchCometChat (this, null)));

				//Without cloud


				MessageSDK.Login(this.ApplicationContext, "demo1", "user1", new MyLoginCallback(successObj1 => MessageSDK.LaunchCometChat(this, null), null, null, null, null, null));
			};



		}
	}
}



