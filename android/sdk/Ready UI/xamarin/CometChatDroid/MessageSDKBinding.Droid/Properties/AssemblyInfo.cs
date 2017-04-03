using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("MessageSDKBinding.Droid")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("exx")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: UsesPermissionAttribute(Android.Manifest.Permission.Internet)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.AccessWifiState)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.Camera)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.RecordAudio)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.ModifyAudioSettings)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.ReadContacts)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.SendSms)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.Vibrate)]
[assembly: UsesPermissionAttribute(Android.Manifest.Permission.ReadPhoneState)]

