using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDeFerias.Rooms.Api.DTOs;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Domain.Interfaces.Services;

namespace ToDeFerias.Rooms.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class RoomsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRoomService _roomService;

    public RoomsController(IMapper mapper,
                           IRoomService roomService)
    {
        _mapper = mapper;
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoomDto roomDto)
    {
        var room = _mapper.Map<Room>(roomDto);
        await _roomService.Add(room);

        // TODO: criar infra de notification pattern
        return Created("", _mapper.Map<RoomDto>(room));
    }
}
