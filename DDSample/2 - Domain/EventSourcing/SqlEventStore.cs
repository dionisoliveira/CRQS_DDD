using Newtonsoft.Json;
using DDDSample.Domain.Core.Events;

namespace DDDSample.Domain.EventSourcing
{
    public class SqlEventStore : IEventStore
    {


        public SqlEventStore()
        {
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);
        }
    }
}
