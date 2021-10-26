using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

using System;
using System.Data;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Json;
using System.Collections.Generic;

namespace AppMovilEscuela
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static int Id;
        public List<Usuarios> ListaUsuarios;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var txtUsuario = FindViewById<EditText>(Resource.Id.txtusuario);
            var txtContraseña = FindViewById<EditText>(Resource.Id.txtcontraseña);
            var BtnIngresar = FindViewById<Button>(Resource.Id.btningresar);


            /* BtnIngresar.Click += delegate
               {
                   int x = 0;
                   Usuario = txtUsuario.Text;
                   Contraseña = txtContraseña.Text;
                   var WS = new ServicioWeb.ServicioWebEscuela();
                   var conjunto = new DataSet();
                   conjunto = WS.Login();
                   foreach (DataRow item in conjunto.Tables["Usuarios"].Rows)
                   {
                       if(Usuario == item["Usuario"].ToString() && Contraseña == item["Contraseña"].ToString())
                       {
                           x++;
                           Id = int.Parse(item["IdUsuario"].ToString());
                       }

                   }
                   if (x > 0)
                   {
                       var intent = new Intent(this, typeof(MenuPrincipalActivity));
                       StartActivity(intent);

                   }
                   else
                       Toast.MakeText(this, "Error de usuario y/o contraseña", ToastLength.Long).Show();
               };*/
            BtnIngresar.Click += async delegate
            {
                try
                {
                    int x = 0;
                    var API = "https://api-restescuelacovid.azurewebsites.net/Principal/Login";
                    JsonValue json = await Datos(API);
                    Transform(json);
                    foreach (var Item in ListaUsuarios)
                    {
                        if (txtUsuario.Text == Item.Usuario && txtContraseña.Text == Item.Contraseña)
                        {
                            x++;
                            Id = Item.IdUsuario;
                        }
                    }
                    if (x > 0)
                    {
                        var intent = new Intent(this, typeof(MenuPrincipalActivity));
                        StartActivity(intent);

                    }
                    else
                        Toast.MakeText(this, "Error de usuario y/o contraseña", ToastLength.Long).Show();

                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };

        }
        public async Task<JsonValue> Datos(string API)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri(API));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var jsondoc = await Task.Run(() => JsonValue.Load(stream));
                    return jsondoc;
                }
            }
        }
        public void Transform(JsonValue json)
        {
            try
            {
                ListaUsuarios = new List<Usuarios>();   
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Usuarios u = new Usuarios();
                    u.IdUsuario = Resultados["idUsuario"];
                    u.Usuario = Resultados["usuario"];
                    u.Contraseña = Resultados["contraseña"];
                    ListaUsuarios.Add(u);
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

    }
}