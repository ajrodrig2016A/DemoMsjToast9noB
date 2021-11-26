using DemoMsjToast9noB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMsjToast9noB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;


        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtUsuario.Text, Contrasenia = txtContrasenia.Text };
                con.InsertAsync(Registros);
            }
            catch (Exception ex)
            {
                DisplayAlert("Excepcion", ex.Message, "OK");
            }

            txtNombre.Text = String.Empty;
            txtUsuario.Text = String.Empty;
            txtContrasenia.Text = String.Empty;
        }
    }
}