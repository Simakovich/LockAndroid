using Android.App.Admin;
using Android.App;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;

namespace LockScreen.Platforms.Android
{
    [BroadcastReceiver(
    Name = "your.packagename.AdminReceiver",
    Label = "My Device Admin Receiver",
    Permission = Manifest.Permission.BindDeviceAdmin)]
    [MetaData("android.app.device_admin", Resource = "@xml/device_admin")]
    [IntentFilter(new[] { "android.app.action.DEVICE_ADMIN_ENABLED", Intent.CategoryAlternative })]
    public class AdminReceiver : DeviceAdminReceiver
    {
        public override void OnEnabled(Context context, Intent intent)
        {
            base.OnEnabled(context, intent);
            //TODO: код, выполняемый при активации административных привилегий
        }

        public override void OnDisabled(Context context, Intent intent)
        {
            base.OnDisabled(context, intent);
            //TODO: код, выполняемый при деактивации административных привилегий
        }
        public override void OnReceive(Context context, Intent intent)
        {
            base.OnReceive(context, intent);
            // Здесь вы можете поместить код для отладки или логирования
        }
        //Переопределите другие методы по мере необходимости
    }
}