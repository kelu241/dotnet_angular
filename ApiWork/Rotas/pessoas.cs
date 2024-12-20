
namespace dotnet_angular.Rotas;
using dotnet_angular.Models;
using Microsoft.AspNetCore.Mvc;

public static class pessoas
{

    public static List<pessoa> Humanos = new List<pessoa>(){
    new pessoa(Guid.NewGuid(), "Neymar"),
    new pessoa(Guid.NewGuid(), "Chilly"),
    new pessoa(Guid.NewGuid(), "Xandão")
};

    public static void MapPessoasRota(this WebApplication app)
    {

        app.MapGet("/humanos", () =>

            Humanos);

        app.MapGet("/humano/{nome}", (string nome) =>
            Humanos.Find((x) => x.Nome.StartsWith(nome)));

        app.MapPost("/HumanoAdd", (pessoa pessoa ) =>
        {

            Humanos.Add(pessoa);

            return Results.Ok(pessoa);

        });


        app.MapPut("humano/{id}", (Guid id, [FromBody]pessoa pessoa)=>{

            var encontrado = Humanos.Find((x) =>

            x.Id == id
            );
                         

            if (encontrado==null)
                return Results.NotFound();

            encontrado.Nome = pessoa.Nome;    

            return Results.Ok(Humanos);   
                        
        });
    }


}