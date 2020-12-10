using OdeToParties.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToParties.Data.Services
{
    public class SqlPartyData : IPartyData
    {
        private readonly OdeToPartyDbContext db;
        public SqlPartyData(OdeToPartyDbContext db)
        {
            this.db = db;
        }
        
        public void Add(Party party)
        {
            db.Parties.Add(party);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var party = db.Parties.Find(id);
            db.Parties.Remove(party);
            db.SaveChanges();
        }

        public Party Get(int id)
        {
            return db.Parties.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Party> GetAll()
        {
            return from r in db.Parties
                   orderby r.Host
                   select r;
        }

        public void Update(Party party)
        {
            var entry = db.Entry(party);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
