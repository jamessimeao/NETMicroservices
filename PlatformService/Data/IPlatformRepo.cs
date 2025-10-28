using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo
    {
        public bool SaveChanges();
        public IEnumerable<PlatformRepo> GetAllPlatforms();
        public PlatformRepo GetPlatformById(int id);
        public void CreatePlatform(PlatformRepo platform);
    }
}
