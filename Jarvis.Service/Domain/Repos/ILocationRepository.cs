using System;
using Jarvis.Service.Domain.DomainModel;

namespace Jarvis.Service.Domain.Repos
{
    public interface ILocationRepository : IRepository<Location.Location,Guid>
    {
    }
}
