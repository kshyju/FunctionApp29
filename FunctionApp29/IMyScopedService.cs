using System.Globalization;

namespace FunctionApp29
{
    public interface IMyScopedService
    {
        string GetId();
    }
    public class MyScopedService : IMyScopedService
    {
        private Guid _id;
        public MyScopedService()
        {
            // set the id during creation of this class instance.
            _id = Guid.NewGuid();
        }

        public string GetId() => _id.ToString();
    }
}
