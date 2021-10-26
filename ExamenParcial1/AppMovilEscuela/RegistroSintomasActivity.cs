using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections;
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
    [Activity(Label = "RegistroSintomasActivity")]
    public class RegistroSintomasActivity : Activity
    {
       public List<Alumnos> ListaAlumnos;
        //public List<KeyValuePair<string, string>> ListaAlumnos;
        List<string> AlumnosNombre;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistroSintomas);
            
            var txtObservacion = FindViewById<EditText>(Resource.Id.txtObservaciones);
            
            var txtTemperatura = FindViewById<EditText>(Resource.Id.txtTemperatura);
            var txtMatricula = FindViewById<EditText>(Resource.Id.txtMatricula);
            var TextDateFecha = FindViewById<EditText>(Resource.Id.TextDateFecha);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            var txtAsiste = FindViewById<EditText>(Resource.Id.txtAsiste);
            var txtSintomas = FindViewById<EditText>(Resource.Id.txtSintomas);
            //var cmbAlumno = FindViewById<Spinner>(Resource.Id.cmbAlumno);

            /*var API = "https://api-restescuelacovid.azurewebsites.net//Principal/NombreAlumnos?Fkusuario=" + MainActivity.Id;
            JsonValue json = await Datos(API);
            Transform(json);

            cmbAlumno.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(cmbAlumno_ItemSelected);
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.RegistroSintomas, AlumnosNombre);
            adapter.SetDropDownViewResource(Resource.Layout.RegistroSintomas);
            cmbAlumno.Adapter = adapter;*/
            


            TextDateFecha.Text = DateTime.Now.ToString();
            btnGuardar.Click += delegate 
            {
                double temperatura;
                string Observaciones,Matricula,Asistencia,Sintomas;
                Asistencia = txtAsiste.Text;
                Sintomas = txtSintomas.Text;
               
                temperatura = double.Parse(txtTemperatura.Text);
               Matricula = txtMatricula.Text;
                Observaciones = txtObservacion.Text;
                

                try
                {
                    var API = "https://api-restescuelacovid.azurewebsites.net//Principal/GuardarSintomas?FkAlumno=" +
                    Matricula+"&temp="+temperatura+"&Sintomas="+Sintomas+"&observaciones="+Observaciones+"&Asistenacia="+Asistencia+""; 
                    var request = (HttpWebRequest)WebRequest.Create(API);
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseText = reader.ReadToEnd();
                    //Toast.MakeText(this, responseText.ToString(), ToastLength.Long).Show();
                    if (responseText.ToString().Equals("Almacenado en SQL server desde .Net Core 5"))
                        Toast.MakeText(this, "Sintomas Registrado Correctamente", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Error al registrar los datos", ToastLength.Long).Show();
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Error de Conexion", ToastLength.Long).Show();

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
                /*ListaAlumnos = new List<KeyValuePair<string, string>>();
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    var dato = new KeyValuePair<string, string>(Resultados["nombre"], Resultados["matricula"]);
                    ListaAlumnos.Add(dato);
                }
                AlumnosNombre = new List<string>();
                foreach (var item in ListaAlumnos)
                    AlumnosNombre.Add(item.Value);*/

                ListaAlumnos = new List<Alumnos>();
                for (int i = 0; i < json.Count; i++)
                {
                    var Resultados = json[i];
                    Alumnos a = new Alumnos();
                    a.Matricula = Resultados["matricula"];
                    a.Nombre = Resultados["nombre"];
                    ListaAlumnos.Add(a);

                }


            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }
        private void cmbAlumno_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            
        }
    }
}