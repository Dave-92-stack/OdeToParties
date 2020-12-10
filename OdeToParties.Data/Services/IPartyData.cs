using OdeToParties.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToParties.Data.Services
{
    public interface IPartyData
    {
        IEnumerable<Party> GetAll();
        Party Get(int id);
        void Add(Party party);
        void Update(Party party);
        void Delete(int id);
    }
}
