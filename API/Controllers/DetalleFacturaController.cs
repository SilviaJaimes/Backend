using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
/* [Authorize] */

public class DetalleFacturaController : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public DetalleFacturaController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> Get()
    {
        var entidad = await unitofwork.DetalleFacturas.GetAllAsync();
        return mapper.Map<List<DetalleFacturaDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleFacturaDto>> Get(int id)
    {
        var entidad = await unitofwork.DetalleFacturas.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<DetalleFacturaDto>(entidad);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleFacturaDto>>> GetPaginacion([FromQuery] Params entidadeParams)
    {
        var entidad = await unitofwork.DetalleFacturas.GetAllAsync(entidadeParams.PageIndex, entidadeParams.PageSize, entidadeParams.Search);
        var listEntidad = mapper.Map<List<DetalleFacturaDto>>(entidad.registros);
        return new Pager<DetalleFacturaDto>(listEntidad, entidad.totalRegistros, entidadeParams.PageIndex, entidadeParams.PageSize, entidadeParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleFactura>> Post(DetalleFacturaDto entidadDto)
    {
        var entidad = this.mapper.Map<DetalleFactura>(entidadDto);
        this.unitofwork.DetalleFacturas.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetalleFacturaDto>> Put(int id, [FromBody]DetalleFacturaDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<DetalleFactura>(entidadDto);
        unitofwork.DetalleFacturas.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.DetalleFacturas.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.DetalleFacturas.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}
