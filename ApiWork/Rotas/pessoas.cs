
namespace dotnet_angular.Rotas;
using dotnet_angular.Models;


public static class pessoas
{

public static List<pessoa> Humanos = new List<pessoa>(){
    new pessoa(Guid.NewGuid(), "Neymar"),
    new pessoa(Guid.NewGuid(), "Chilly"),
    new pessoa(Guid.NewGuid(), "Xandão")
};

    public static void MapPessoasRota(this WebApplication app)
    {

        app.MapGet("/hello-ei", () =>

            Humanos );


    }



}