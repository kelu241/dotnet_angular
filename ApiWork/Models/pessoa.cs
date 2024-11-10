namespace dotnet_angular.Models;

public class pessoa{

public Guid Id {get;set;}
public string Nome {get;set;}

public pessoa(Guid id, string nome)
{
    Id = id;
    Nome = nome;
}


}