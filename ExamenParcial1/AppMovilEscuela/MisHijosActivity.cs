using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Json;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppMovilEscuela
{
    [Activity(Label = "MisHijosActivity")]
    public class MisHijosActivity : Activity
    {
        public List<Alumnos> ListaAlumnos;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MisHijos);
            var WS = new ServicioWeb.ServicioWebEscuela();
            var btnNuevo = FindViewById<Button>(Resource.Id.btnNuevo);
            var lblHijos = FindViewById<TextView>(Resource.Id.lblMisHijos);


            /*var conjunto = new DataSet();
            conjunto = WS.MostrarHijos(MainActivity.Id);*/
            var API = "https://api-restescuelacovid.azurewebsites.net//Principal/MostrarHijos?id="+MainActivity.Id;
            JsonValue json = await Datos(API);
            Transform(json); ;

            string Hijos = "";
            foreach (var item in ListaAlumnos)
            {
                Hijos += "Matricula: " + item.Matricula+"\n";
                Hijos += "Nombre: " + item.Nombre + " " + item.ApellidoPaterno + " "+ item.ApellidoMaterno + "\n";
                Hijos += "Grado: " + item.Grado +" Grupo: "+ item.Grupo + " Edad: "+ item.Edad + "\n";
                Hijos += "\n";
            }
            
            lblHijos.Text = Hijos;
            btnNuevo.Click += delegate 
            {
                var intent = new Intent(this, typeof(RegistroHijosActivity));
                StartActivity(intent);
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
                ListaAlumnos = new List<Alumnos>();   
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Alumnos a = new Alumnos();
                    a.Matricula = Resultados["matricula"];
                    a.Nombre = Resultados["nombre"];
                    a.ApellidoPaterno = Resultados["apellidoPaterno"];
                    a.ApellidoMaterno = Resultados["apellidoMaterno"];
                    a.Grado = Resultados["grado"];
                    a.Grupo = Resultados["grupo"];
                    a.Edad = Resultados["edad"];
                    ListaAlumnos.Add(a);
                    
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
    }
}