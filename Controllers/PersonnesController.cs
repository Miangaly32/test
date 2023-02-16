using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Miangaly.Models;
using Test_Miangaly.Services;

namespace Test_Miangaly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnesController : ControllerBase
    {
        private readonly IPersonneService _service;

        public PersonnesController(IPersonneService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cree une personne
        /// </summary>
        /// <param name="person"></param>
        /// <returns>La nouvelle personne creee</returns>
        /// <remarks>
        /// Seule les personnes moins de 150 ans peuvent etre enregistrées
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///         "id": 1,
        ///         "nom": "string",
        ///         "prenom": "string",
        ///         "dateNaissance": "1992-02-16"
        ///     }
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="500">If age > 150</response>
        [HttpPost]
    public async Task<IActionResult> AddPersonAction(Personne person)
    {
        try
        {
            await _service.AddAsync(person);
            return Created($"/Personnes/{person.Id}", person);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAction()
    {
        return Ok(await _service.GetAllAsync());
    }

}
}
