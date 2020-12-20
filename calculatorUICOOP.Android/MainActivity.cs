using calculatorUICOOP.Droid.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace calculatorUICOOP.Droid
{
    [Activity(Label = "calculatorUICOOP", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private Logger _logger;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Handling uncaught application exceptions
            _logger = new Logger();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        #region Handling uncaught application exceptions
        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var exception = unhandledExceptionEventArgs.ExceptionObject as Exception;
            _logger.Log(LogLevel.Error, exception);
        }
        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            foreach (var exception in unobservedTaskExceptionEventArgs.Exception.InnerExceptions)
                _logger.Log(LogLevel.Error, exception);
        }
        #endregion
    }
}