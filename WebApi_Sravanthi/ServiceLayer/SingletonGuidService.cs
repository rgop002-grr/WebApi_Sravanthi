using WebApi_Sravanthi.Services;

namespace WebApi_Sravanthi.ServiceLayer
{
    public class SingletonGuidService : IGuidService
    {
        private readonly Guid _guid;

        public SingletonGuidService()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
