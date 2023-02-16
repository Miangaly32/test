using Test_Miangaly.Models;
using Test_Miangaly.Repositories;

namespace Test_Miangaly.Services;

public class PersonneService : IPersonneService
{
    private readonly IPersonneRepository _repository;

    public PersonneService(IPersonneRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> AddAsync(Personne person)
    {
        var age = CalculAge(person); 
        if (age > 150)
        {
            throw new Exception("Age doit etre inferieur a 150");
        }
        return await _repository.CreateAsync(person);
    }

    public async Task<List<GetPersonneDTO>> GetAllAsync()
    {
        var result = new List<GetPersonneDTO>();
        var persons = await _repository.GetAllAsync();
        foreach(var person in persons)
        {
            var personDto = new GetPersonneDTO();
            personDto.Id = person.Id;
            personDto.Nom = person.Nom;
            personDto.Prenom = person.Prenom;
            personDto.DateNaissance = person.DateNaissance;
            personDto.Age = CalculAge(person);
            result.Add(personDto);
        }
        
        return result;
    }

    private int CalculAge(Personne person)
    {
        return DateTime.Now.Year - person.DateNaissance.Year;
    }
}
