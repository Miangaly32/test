using Test_Miangaly.Models;

namespace Test_Miangaly.Services;

public interface IPersonneService
{
    Task<bool> AddAsync(Personne person);
    Task<List<GetPersonneDTO>> GetAllAsync();
}
