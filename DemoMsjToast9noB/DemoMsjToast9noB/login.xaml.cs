using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using DemoMsjToast9noB.Models;
using System.IO;

namespace DemoMsjToast9noB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante WHERE Usuario = ? and Contrasenia = ?", usuario, contrasenia);
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documenthPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documenthPath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);

                if (resultado.Count() > 0)
                {
                    await Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    await DisplayAlert("Alerta", "Usuario no existe, debe registrarse", "ok");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}