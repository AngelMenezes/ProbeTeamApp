using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate;
using ProbeTeam.PlayerMicroservice.Infra.DataAccess;

namespace ProbeTeam.PlayerMicroservice.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/Players
        [HttpGet("/api/players")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return Ok(await _playerService.GetAllPlayersAsync());
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            var player = await _playerService.GetPlayerAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles ="Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(Guid id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            var result = await _playerService.UpdatePlayerAsync(player);

            if (!result)
                return NotFound();

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            var result = await _playerService.AddPlayerAsync(player);

            if (!result)
                BadRequest("Player invalid");

            return Created("api/player", player);
        }

        // DELETE: api/Players/5
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Player>> DeletePlayer(Guid id)
        {
            var result = await _playerService.DeletePlayerAsync(id);

            if (!result)
                return NotFound("Player not found!");

            return Ok(id);
        }

        private bool PlayerExists(Guid id)
        {
            return _playerService.GetPlayerAsync(id) != null;
        }
    }
}
