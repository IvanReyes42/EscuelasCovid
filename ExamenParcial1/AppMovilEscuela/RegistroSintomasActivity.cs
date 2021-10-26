using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace AppMovilEscuela
{
    [Activity(Label = "RegistroSintomasActivity")]
    public class RegistroSintomasActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistroSintomas);
            var WS = new ServicioWeb.ServicioWebEscuela();
            var txtObservacion = FindViewById<EditText>(Resource.Id.txtObservaciones);
            
            var txtTemperatura = FindViewById<EditText>(Resource.Id.txtTemperatura);
            var txtMatricula = FindViewById<EditText>(Resource.Id.txtMatricula);
            var TextDateFecha = FindViewById<EditText>(Resource.Id.TextDateFecha);
            var btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            var txtAsiste = FindViewById<EditText>(Resource.Id.txtAsiste);
            var txtSintomas = FindViewById<EditText>(Resource.Id.txtSintomas);
            var conjunto = new DataSet();
            conjunto = WS.MostrarHijos(MainActivity.Id);
         

            TextDateFecha.Text = DateTime.Now.ToString();
            btnGuardar.Click += delegate 
            {
                double temperatura;
                string Observaciones,Matricula,Asistencia,Sintomas;
                Asistencia = txtAsiste.Text;
                Sintomas = txtSintomas.Text;
                var WS = new ServicioWeb.ServicioWebEscuela();
                temperatura = double.Parse(txtTemperatura.Text);
                Matricula = txtMatricula.Text;
                Observaciones = txtObservacion.Text;
                

                try
                {
                    if(WS.GuardarSintomas(Matricula,temperatura,Sintomas,Observaciones,Asistencia))
                        Toast.MakeText(this, "Registro Guardado Correctamente", ToastLength.Long).Show();
                    else
                        Toast.MakeText(this, "Error de dato", ToastLength.Long).Show();
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Error de Conexion", ToastLength.Long).Show();

                }
            };
            
        }
    }
}