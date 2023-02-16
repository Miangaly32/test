using Test_Miangaly.Models;

namespace Test_Miangaly.Repositories;

public interface IPersonneRepository
{
    Task<bool> CreateAsync(Personne person);
    Task<List<Personne>> GetAllAsync();
}
