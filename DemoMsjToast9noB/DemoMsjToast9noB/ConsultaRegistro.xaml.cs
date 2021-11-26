using DemoMsjToast9noB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoMsjToast9noB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> TablaEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            get();
        }

        public async void get()
        {
            try
            {
                var resultado = await con.Table<Estudiante>().ToListAsync();
                TablaEstudiante = new ObservableCollection<Estudiante>(resultado);
                listaUsuarios.ItemsSource = TablaEstudiante;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private async void listausuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Estudiante Obj = (Estudiante)e.SelectedItem;
                //var item = Obj.Id.ToString();
                //int id = Convert.ToInt32(item); //Eliminar actualizar

                await Navigation.PushAsync(new Elemento(Obj));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "ok");
            }
        }
    }
}