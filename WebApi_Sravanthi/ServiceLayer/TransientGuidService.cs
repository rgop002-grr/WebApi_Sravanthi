using WebApi_Sravanthi.Services;

namespace WebApi_Sravanthi.ServiceLayer
{
    public class TransientGuidService : IGuidService
    {
        private readonly Guid _guid;

        public TransientGuidService()
        {
            _guid = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _guid.ToString();
        }
    }
}
