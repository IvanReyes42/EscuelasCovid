using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AppMovilEscuela
{
    [Activity(Label = "RegistroHijosActivity")]
    public class RegistroHijosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistroHijos);

            var txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            var txtMatricula = FindViewById<EditText>(Resource.Id.txtMatricula);
            var txtAP = FindViewById<EditText>(Resource.Id.txtApellidoPaterno);
            var txtAM = FindViewById<EditText>(Resource.Id.txtApellidoMaterno);
            var txtGrado = FindViewById<EditText>(Resource.Id.txtGrado);
            var txtGrupo = FindViewById<EditText>(Resource.Id.txtGrupo);
            var txtEdad = FindViewById<EditText>(Resource.Id.txtEdad);
            var btnRegistrar = FindViewById<Button>(Resource.Id.btnRegistrar);

            btnRegistrar.Click += delegate 
            {
                string Matricula, Nombre, AP, AM, Grado, Grupo;
                int Edad;
                int id = MainActivity.Id;
                
                Matricula = txtMatricula.Text;
                Nombre = txtNombre.Text;
                AP = txtAP.Text;
                AM = txtAM.Text;
                Grado = txtGrado.Text;
                Grupo = txtGrupo.Text;
                Edad = int.Parse(txtEdad.Text);

                try
                {
                    var API = "https://api-restescuelacovid.azurewebsites.net//Principal/GuardarAlumno?Matricula=" +
                    Matricula + "&Nombre=" + Nombre + "&AP=" + AP + "&AM=" + AM + "&Grado=" + Grado + "&Grupo=" + Grupo + "&edad=" + Edad + "&FkUsuario=" + id + "";
                    var request = (HttpWebRequest)WebRequest.Create(API);
                    WebResponse response = request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseText = reader.ReadToEnd();
                    Toast.MakeText(this, responseText.ToString(), ToastLength.Long).Show();

                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Error de conexion", ToastLength.Long).Show();
                }
            };
        }
    }
}