using CQRS.Infrastructure.Context;
using CQRS.Infrastructure.DbModel;
using CQRS.Infrastructure.Repositories.Interfaces;

namespace CQRS.Infrastructure.Repositories
{
    public class ScheduleRepository : BaseRepository<ScheduleDbModel>, IScheduleRepository
    {
        public ScheduleRepository(APIContext contextAPI) : base(contextAPI)
        { }
    }
}
