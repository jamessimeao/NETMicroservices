using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;
using System.Collections.Specialized;

namespace PlatformService.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;
        public PlatformsController(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Get platforms...");
            IEnumerable<Platform> platforms = _repository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDTO?> GetPlatformById(int id)
        {
            Platform? platform = _repository.GetPlatformById(id);
            if (platform == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<PlatformReadDTO>(platform));
            }

        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            Platform platform = _mapper.Map<Platform>(platformCreateDTO);
            _repository.CreatePlatform(platform);
            _repository.SaveChanges();

            PlatformReadDTO platformReadDTO = _mapper.Map<PlatformReadDTO>(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.Id}, platformReadDTO);
        }
    }
}
