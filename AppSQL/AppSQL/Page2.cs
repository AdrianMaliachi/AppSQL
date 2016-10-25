using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using SQLite;

using Xamarin.Forms;

namespace AppSQL
{
    public class Page2 : ContentPage
    {
        public Label name = new Label();
        public Page2()
        {
            SQLiteConnection database;
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<agenda>();

            Label nom = new Label();
            nom.Text = "Nombre";
            nom.HorizontalTextAlignment = TextAlignment.Center;

            Entry nombre = new Entry();
            nombre.Placeholder = "Introduce tu Nombre";
            nombre.HorizontalTextAlignment = TextAlignment.Center;
            nombre.BackgroundColor = Color.White;
            

            Label ape = new Label();
            ape.Text = "Apellido";
            ape.HorizontalTextAlignment = TextAlignment.Center;

            Entry apellido = new Entry();
            apellido.HorizontalTextAlignment = TextAlignment.Center;
            apellido.Placeholder = "Introduce tu Apellido";
            apellido.BackgroundColor = Color.White;

            Label tel = new Label();
            tel.Text = "Telefono";
            tel.HorizontalTextAlignment = TextAlignment.Center;
            
            Entry telefono = new Entry();
            telefono.Placeholder = "Introduce tu numero telefonico";
            telefono.HorizontalTextAlignment = TextAlignment.Center;
            telefono.Keyboard = Keyboard.Numeric;
            telefono.BackgroundColor = Color.White;

            Label buscar = new Label();
            buscar.Text = "Busqueda";

            Entry busca = new Entry();
            busca.Placeholder = "Introduce el ID";
            busca.BackgroundColor = Color.White;

            /*busca.TextChanged += (sender, args) => {

                var queryy = database.Query<agenda>("SELECT * FROM [Agenda] WHERE id_contacto LIKE @param '%' or nombre LIKE @param '%' or apellido LIKE @param '%' or telephone LIKE @param '%'");
                var listt = queryy.ToList();
                var datoo = listt.Last();
                nombre.Text = datoo.nombre;
                apellido.Text = datoo.apellido;
                telefono.Text = datoo.telephone;

            };*/


            Button guardar = new Button();
            guardar.Text = "Guardar Contacto";
            guardar.BackgroundColor = Color.Black;
            guardar.TextColor = Color.White;
            guardar.Clicked += async (sender, args) =>
            {
                if (nombre.Text == null || apellido.Text == null || telefono.Text == null)
                {                    
                    await DisplayAlert("Alerta", "Te falta llenar algun campo ", "OK");
                    busca.Text = "";
                }

                else
                {

                    var elemento = new agenda();
                    elemento.nombre = "" + nombre.Text;
                    elemento.apellido = "" + apellido.Text;
                    elemento.telephone = "" + telefono.Text;
                    database.Insert(elemento);
                    //await MainPage.DisplayAlert("Contacto", "Tu contacto ha sido /n guarado con exito ", "OK");
                    await DisplayAlert("Contacto", "Tu contacto ha sido \n guarado con exito ", "OK");

                    nombre.Text = null;
                    apellido.Text = null;
                    telefono.Text = null;
                    busca.Text = "";

                }
                
            };

        

            Button bus = new Button();
            bus.Text = "buscar";
            bus.BackgroundColor = Color.Black;
            bus.TextColor = Color.White;

            bus.Clicked += async (sender, args) =>
            {
                
                if (busca.Text==null)
                {


                    await DisplayAlert("Alerta", "Te falta llenar algun campo ", "OK");
                }

                else
                {

                    try {
                        var queryy = database.Query<agenda>("SELECT * FROM [Agenda] where [id_contacto] = '" + busca.Text + "'");
                        var listt = queryy.ToList();
                        var datoo = listt.Last();
                        nombre.Text = datoo.nombre;
                        apellido.Text = datoo.apellido;
                        telefono.Text = datoo.telephone;

                        guardar.IsEnabled = false;
                    } catch (Exception e){
                        await DisplayAlert("Alerta", "El contacto que estas intentanto buscar no esta disponoble \n o ha sido eliminado: ", "OK");
                        busca.Text = "";
                    }                    
                }

            };

            Button actualiza = new Button();
            actualiza.Text = "Actualizar";
            actualiza.BackgroundColor = Color.Black;
            actualiza.TextColor = Color.White;
            actualiza.Clicked += async (sender, args) =>
            {
                try { 
                if (nombre.Text == null || apellido.Text == null || telefono.Text == null)
                {
                    await DisplayAlert("Alerta", "Te falta llenar algun campo: ", "OK");
                }

                else
                {
                    var queryy = database.Query<agenda>("Update [Agenda] set nombre='" + nombre.Text + "', apellido= '" + apellido.Text + "', telephone= '" + telefono.Text + "'  where [id_contacto] = '" + busca.Text + "'");
                    await DisplayAlert("Contacto", "Tu contacto ha sido \n actualizado con exito ", "OK");

                    nombre.Text = "";
                    apellido.Text = "";
                    telefono.Text = "";

                    busca.Text = "";

                }

                 }catch (Exception e)
                {
                    await DisplayAlert("Alerta", "El contacto que estas intentanto actualizar no esta disponoble \n o ha sido eliminado: ", "OK");

                }

            };
      
            Button elimina = new Button();
            elimina.Text = "Eliminar contacto";
            elimina.BackgroundColor = Color.Black;
            elimina.TextColor = Color.White;
            elimina.Clicked += async (sender, args) =>
            {
                try
                {
                    if (nombre.Text == null || apellido.Text == null || telefono.Text == null || busca.Text == null)
                    {
                        await DisplayAlert("Alerta", "Te falta llenar algun campo: ", "OK");
                    }
                    else
                    {
                        var queryy = database.Query<agenda>("Delete From [Agenda]  where [id_contacto] = '" + busca.Text + "'");
                        await DisplayAlert("Contacto", "Tu contacto ha sido \n eliminado con exito ", "OK");
   
                        nombre.Text = "";
                        apellido.Text = "";
                        telefono.Text = "";
                        busca.Text = "";
                    }
                }
                catch (Exception e)
                {
                    await DisplayAlert("Alerta", "El contacto que estas intentanto eliminar no esta disponoble \n o ha sido eliminado: ", "OK");

                }
            };

            Button limpiar = new Button();
            limpiar.Text = "Limpiar";
            .BackgroundColor = Color.Black;
            limpiar.TextColor = Color.White;
            limpiar.Clicked += (sender, args) =>
            {
                nombre.Text = null;
                apellido.Text = "";
                telefono.Text = "";
                busca.Text = "";

                guardar.IsEnabled = true;
            };

            Content = new StackLayout()
                
            {
                Children = {
                        
                        nom,
                        nombre,
                        ape,
                        apellido,
                        tel,
                        telefono,
                        guardar,
                        actualiza,
                        elimina,
                        /*new Label {

                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = Convert.ToString(dato.id_contacto)
                        },*/
                        buscar,
                        busca,
                        bus,
                        limpiar,
                        name
                }
            };
        }
    }
      [Table("Agenda")]
        public class agenda
        {
            [PrimaryKey, AutoIncrement]
            public int id_contacto { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string telephone { get; set; }

        }
}
