using avillarroelS5.Models;
using avillarroelS5.Utils;

namespace avillarroelS5.Views;

public partial class vHome : ContentPage
{
	
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);
        status.Text = App.personRepo.StatusMessage;
    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Person> people = App.personRepo.GetAllPeople();
        ListarPersonas.ItemsSource = people;
    }

    private async void btnEditar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button?.BindingContext as Person;

        if (person != null)
        {
            string nuevoNombre = await DisplayPromptAsync("Editar Persona", "Ingrese el nuevo nombre:", initialValue: person.Nombre);

            if (!string.IsNullOrEmpty(nuevoNombre))
            {
                person.Nombre = nuevoNombre;
                App.personRepo.UpdatePerson(person);
                status.Text = App.personRepo.StatusMessage;
                ListarPersonas.ItemsSource = App.personRepo.GetAllPeople();
            }
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button?.BindingContext as Person;

        if (person != null)
        {
            App.personRepo.DeletePerson(person.Id);
            status.Text = App.personRepo.StatusMessage;
            ListarPersonas.ItemsSource = App.personRepo.GetAllPeople();
        }
    }

}