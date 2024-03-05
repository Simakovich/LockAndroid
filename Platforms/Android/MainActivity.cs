using Android.App;
using Android.App.Admin;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using LockScreen.Platforms.Android;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;


namespace LockScreen;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    private static readonly int RequestCode = 0;
    DevicePolicyManager devicePolicyManager;
    ComponentName adminComponentName;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        devicePolicyManager = (DevicePolicyManager)GetSystemService(DevicePolicyService);
        adminComponentName = new ComponentName(this, Java.Lang.Class.FromType(typeof(AdminReceiver)));

        LockScreenActivity();
    }

    public void LockScreenActivity()
    {

        if (devicePolicyManager.IsAdminActive(adminComponentName))
        {
            devicePolicyManager.LockNow();
        }
        else
        {
            Intent intent = new Intent(DevicePolicyManager.ActionAddDeviceAdmin);
            intent.PutExtra(DevicePolicyManager.ExtraDeviceAdmin, adminComponentName);
            intent.PutExtra(DevicePolicyManager.ExtraAddExplanation, "Your custom message to persuade the user");
            StartActivityForResult(intent, RequestCode);
        }
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if (requestCode == RequestCode)
        {
            if (resultCode == Result.Ok)
            {
                Toast.MakeText(this, "Admin rights granted!", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Admin rights denied!", ToastLength.Short).Show();
            }
        }
    }

    protected override void OnRestart()
    {
        base.OnRestart(); 
        Finish();
    }
}