using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dotnet_angular.Rotas;

using dotnet_angular.Data;
using dotnet_angular.Estudantes;
using Microsoft.EntityFrameworkCore;

public static class EstudantesRotas
{


    public static void AddRotasEstudantes(this WebApplication app)
    {

        var rotaEstudantes = app.MapGroup("estudantes");




        rotaEstudantes.MapPost("", async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
        {

            var jaExiste = await context.Estudantes.AnyAsync(Estudante => Estudante.Nome == request.Nome , ct);
            if (jaExiste)
                return Results.Conflict("O Estudante já existe ");
            var novoEstudande = new Estudante(request.Nome);

            await context.Estudantes.AddAsync(novoEstudande, ct);

            await context.SaveChangesAsync(ct);

            var estudanteRetorno = new EstudanteDto(novoEstudande.Id, novoEstudande.Nome);



            return Results.Ok(estudanteRetorno);


        });




        rotaEstudantes.MapGet("", async (AppDbContext context, CancellationToken ct) =>
        {

            var estudantes = await context.Estudantes
            .Where(estudante => estudante.Ativo)
            .Select(estudante =>  new EstudanteDto(estudante.Id, estudante.Nome))
            .ToListAsync(ct);

            return estudantes;

        });


     
      rotaEstudantes.MapPut("{id:Guid}", async (Guid id, UpdateEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
        {

            var estudante = await context.Estudantes
            .SingleOrDefaultAsync(estudante => estudante.Id==id, ct);
         
           if(estudante == null)

            return Results.NotFound();

            estudante.AtualizarNome(request.Nome);

            await context.SaveChangesAsync(ct);

            return Results.Ok(new EstudanteDto(estudante.Id, estudante.Nome));

        });


        rotaEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>{

          var estudante = await context
          .Estudantes
          .SingleOrDefaultAsync(estudante => estudante.Id == id, ct);


          if(estudante== null)
          return Results.NotFound();
          
          estudante.Desativar();

          await context.SaveChangesAsync(ct);

          return Results.Ok("Estudande desativado");



        });







    }






}