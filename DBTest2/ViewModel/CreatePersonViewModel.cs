namespace DBTest2;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

public class CreatePersonViewModel : ObservableObject
{
    public ICommand Create { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }



    public CreatePersonViewModel()
    {
        Create = new RelayCommand(async () =>
        {
            var person = new Person
            {
                FirstName = FirstName,
                LastName = LastName,
                MiddleName = MiddleName
            };
            await Services.PersonStore.AddPerson(person);
            App.Persons.Add(person);
        });
    }
}