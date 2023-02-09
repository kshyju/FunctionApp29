using System.Globalization;

namespace FunctionApp29
{
    public interface IMyScopedService
    {
        string GetMessage();
    }
    public class MyScopedService : IMyScopedService
    {
        private DateTime _created;
        public MyScopedService()
        {
            _created = DateTime.Now;
        }

        public string GetMessage()
            => _created.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
    }
}
