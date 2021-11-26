using Android.App;
using Android.Widget;
using DemoMsjToast9noB.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]

namespace DemoMsjToast9noB.Droid
{
    class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje)
        {
            //Crear msje emergente de larga duracion 5s
            Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void ShortAlert(string mensaje)
        {
            //Crear msje emergente por 3s
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}