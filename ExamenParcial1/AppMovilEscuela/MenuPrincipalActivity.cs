using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Data;


namespace AppMovilEscuela
{
    [Activity(Label = "MenuPrincipalActivity")]
    public class MenuPrincipalActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuPrincipal);

            var btnHijos = FindViewById<Button>(Resource.Id.btnHijos);
            var btnSintomas = FindViewById<Button>(Resource.Id.btnSintomas);

            btnHijos.Click += delegate
            {
                var intent = new Intent(this, typeof(MisHijosActivity));
                StartActivity(intent);
            };
            btnSintomas.Click += delegate
            {
                var intent = new Intent(this, typeof(RegistroSintomasActivity));
                StartActivity(intent);
            };

        }
    }
}