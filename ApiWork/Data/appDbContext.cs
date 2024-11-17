using Microsoft.EntityFrameworkCore;
using dotnet_angular.Estudantes;

namespace dotnet_angular.Data;

public class AppDbContext : DbContext {


public DbSet<Estudante> Estudantes{get;set;}


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
   
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Luciano;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging(); //Usar somente em desenvolvimento.

        base.OnConfiguring(optionsBuilder);

    }



}