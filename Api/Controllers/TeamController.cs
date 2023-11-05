using Api.Controllers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TeamController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public TeamController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetTeamDto>>> Get()
    {
        var teams = await _unitOfWork.Teams.GetAllAsync();
        return _mapper.Map<List<GetTeamDto>>(teams);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetTeamDto>> Get(int id)
    {
        var team = await _unitOfWork.Teams.GetByIdAsync(id);
        return _mapper.Map<GetTeamDto>(team);
    }

    // [HttpGet]
    // [ApiVersion("1.1")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Pager<Team>>> Get([FromQuery] Params TeamParams)
    // {
    //     var (totalRegistros, registros) = await _unitOfWork.Colores.GetAllAsync(ColorParams.PageIndex,ColorParams.PageSize,ColorParams.Search);
    //     var listaColor = _mapper.Map<List<Team>>(registros);
    //     return new Pager<Team>(listaColor,totalRegistros,ColorParams.PageIndex,ColorParams.PageSize,ColorParams.Search);
    // }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Team Team)
    {
        _unitOfWork.Teams.Add(Team);
        await _unitOfWork.SaveAsync();
        if (Team == null)
        {
            return BadRequest();
        }
        return "Team Creado con Éxito!";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Team Team)
    {
        if (Team == null|| id != Team.Id)
        {
            return BadRequest();
        }
        var exist = await _unitOfWork.Teams.GetByIdAsync(id);

        if (exist == null)
        {
            return NotFound();
        }
        _unitOfWork.Teams.Update(exist);
        await _unitOfWork.SaveAsync();

        return "Team Actualizado con Éxito!";
    } 

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var Team = await _unitOfWork.Teams.GetByIdAsync(id);
        if (Team == null)
        {
            return NotFound();
        }
        _unitOfWork.Teams.Remove(Team);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"Se eliminó con éxito." });
    }
}