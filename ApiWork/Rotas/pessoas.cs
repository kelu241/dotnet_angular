public static class Pessoas
{

    public static void MapPessoasRota(this WebApplication app)
    {

        app.MapGet("/hello-ei", () =>

            new { Nome = "LUciano"});


    }



}