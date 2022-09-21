using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDeFerias.Core.Notifier;
using ToDeFerias.Rooms.Api.DTOs;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Services;

namespace ToDeFerias.Rooms.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class RoomsController : MainController
{
    private readonly IMapper _mapper;
    private readonly IRoomService _roomService;

    public RoomsController(IMapper mapper,
                           INotifier notifier,
                           IRoomService roomService) : base(notifier)
    {
        _mapper = mapper;
        _roomService = roomService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoomDto roomDto)
    {
        var room = _mapper.Map<Room>(roomDto);
        await _roomService.Add(room);
        
        return CustomResponse<RoomDto>(room, HttpStatusCode.Created);
    }
}
