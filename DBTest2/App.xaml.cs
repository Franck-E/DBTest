using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Windows.Storage;

namespace DBTest2;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static List<Person> Persons = new List<Person>();
    public static string dbPath { get; set; }

    protected async override void OnStartup(StartupEventArgs e)
    {
        StorageFolder initial = ApplicationData.Current.LocalFolder;
        dbPath = System.IO.Path.Join(initial.Path, "dbTest.db");

        await InitializeData();
        

        MainWindow window = new();
        window.Show();

        base.OnStartup(e);
    }
    private async Task InitializeData()
    {
        try
        {
            await Services.PersonStore.EnsurePersonStore();
            Persons = await Services.PersonStore.GetPersons();
        }
        catch (Exception)
        {
            //File.Delete(DB);
            await InitializeData();
        }
    }
}
