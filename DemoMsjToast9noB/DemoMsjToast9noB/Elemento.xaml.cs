using DemoMsjToast9noB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMsjToast9noB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Estudiante> ResultadoUpdate;
        IEnumerable<Estudiante> ResultadoDelete;

        public Elemento(Estudiante objEstudiante)
        {
            _conn = DependencyService.Get<DataBase>().GetConnection();
            InitializeComponent();
            IdSeleccionado = objEstudiante.Id;
            txtNombre.Text = objEstudiante.Nombre;
            txtUsuario.Text = objEstudiante.Usuario;
            txtContrasenia.Text = objEstudiante.Contrasenia;
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = UPDATE(db, txtNombre.Text, txtUsuario.Text, txtContrasenia.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = DELETE(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Error: " + ex.Message, "ok");
            }

        }
        public static IEnumerable<Estudiante> DELETE(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
        }

        public static IEnumerable<Estudiante> UPDATE(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre = ?, Usuario = ?, Contrasenia = ? where Id = ?", nombre, usuario, contrasenia, id);
        }
    }
}