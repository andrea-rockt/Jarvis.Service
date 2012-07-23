using System;
using NHibernate;

namespace Jarvis.Service.Domain.Repos
{
    public class LocationNhRepository : DomainModel.NhRepository<Location.Location,Guid>, ILocationRepository
    {
        public LocationNhRepository(ISession session) : base(session)
        {
        }
    }
}