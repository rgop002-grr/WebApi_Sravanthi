using WebApi_Sravanthi.Services;

namespace WebApi_Sravanthi.ServiceLayer
{
    public class ScopedGuidService : IGuidService
    {
        private readonly string _message;

        public ScopedGuidService()
        {
            _message = "My name is Sravanthi";
        }

        public string GetGuid()
        {
            return _message;
        }
    }
}
