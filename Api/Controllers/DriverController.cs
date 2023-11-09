using Api.Controllers;
using Api.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DriverController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DriverController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GetDriverDto>>> Get()
    {
        var drivers = await _unitOfWork.Drivers.GetAllAsync();
        return _mapper.Map<List<GetDriverDto>>(drivers);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetDriverDto>> Get(int id)
    {
        var driver = await _unitOfWork.Drivers.GetByIdAsync(id);
        return _mapper.Map<GetDriverDto>(driver);
    }

   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Post(Driver Driver)
    {
        _unitOfWork.Drivers.Add(Driver);
        await _unitOfWork.SaveAsync();
        if (Driver == null)
        {
            return BadRequest();
        }
        return "Driver Creado con Éxito!";
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<string>> Put(int id,[FromBody] Driver Driver)
    {
        if (Driver == null|| id != Driver.Id)
        {
            return BadRequest();
        }
        var exist = await _unitOfWork.Drivers.GetByIdAsync(id);

        if (exist == null)
        {
            return NotFound();
        }
        _unitOfWork.Drivers.Update(Driver);
        await _unitOfWork.SaveAsync();

        return "Driver Actualizado con Éxito!";
    } 

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        var Driver = await _unitOfWork.Drivers.GetByIdAsync(id);
        if (Driver == null)
        {
            return NotFound();
        }
        _unitOfWork.Drivers.Remove(Driver);
        await _unitOfWork.SaveAsync();
        return Ok(new { message = $"Se eliminó con éxito." });
    }
}