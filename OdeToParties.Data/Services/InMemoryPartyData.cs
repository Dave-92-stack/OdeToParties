using OdeToParties.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToParties.Data.Services
{
    public class InMemoryPartyData : IPartyData
    {
        List<Party> parties;
        public InMemoryPartyData()
        {
            parties = new List<Party>()
            {
                new Party { Id = 1, Host = "Dave", Venue = VenueType.Residential},
                new Party { Id = 2, Host = "Paul", Venue = VenueType.Park},
                new Party { Id = 3, Host = "John", Venue = VenueType.Hall}

            };
        }
        public void Add(Party party)
        {
            parties.Add(party);
            party.Id = parties.Max(r => r.Id) + 1;
        }

        public void Update(Party party)
        {
            var existing = Get(party.Id);
            if(existing != null)
            {
                existing.Host = party.Host;
                existing.Venue = party.Venue;
            }
        }
        public Party Get(int id)
        {
            return parties.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Party> GetAll()
        {
            return parties.OrderBy(r => r.Host);
        }

        public void Delete(int id)
        {
            var party = Get(id);
            if(party != null)
            {
                parties.Remove(party);
            }
        }
    }
}
