using Microsoft.EntityFrameworkCore;
using Test_Miangaly.Models;

namespace Test_Miangaly.Repositories;

public class PersonneRepository : IPersonneRepository
{
    private readonly AppDbContext context;

    public PersonneRepository(AppDbContext appDbContext)
    {
        context = appDbContext;
    }

    public async Task<bool> CreateAsync(Personne person)
    {
        context.Add(person);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Personne>> GetAllAsync()
    {
        return await context.Personnes.OrderBy(x => x.Nom).ToListAsync();
    }
}
