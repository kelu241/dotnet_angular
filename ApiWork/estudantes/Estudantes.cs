
namespace dotnet_angular.Estudantes;

public class Estudante
{

    public Guid Id { get; init; }

    public string Nome { get; set; }


    public bool Ativo { get; private set; }


    public Estudante(String nome)
    {
        Nome = nome;
        Id = Guid.NewGuid();
        Ativo = true;

    }

    public void AtualizarNome(string nome){

        Nome = nome;
    }

    public void Desativar(){
        Ativo = false;
    }


}