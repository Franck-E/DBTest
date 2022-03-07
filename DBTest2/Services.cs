namespace DBTest2;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class Services
{

    public static ServiceProvider serviceProvider = new ServiceCollection()
        .AddDbContext<DataDBContext>(options =>
        {
            options.UseSqlite($@"Data source = {App.dbPath}");
        })
        .AddScoped<IPerson>(provider => new StorePerson(provider.GetService<DataDBContext>()))
        .BuildServiceProvider();

    public static IPerson PersonStore = serviceProvider.GetService<IPerson>();
}
