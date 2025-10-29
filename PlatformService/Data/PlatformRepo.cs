
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePlatform(Platform platform)
        {
            _dbContext.Platforms.Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList<Platform>();
        }

        public Platform? GetPlatformById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault<Platform>(
                (Platform platform) => platform.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
