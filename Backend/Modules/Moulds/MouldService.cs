using Backend.App;
using Backend.Modules._Base;
using Backend.Modules.Moulds.Ent;

namespace Backend.Modules.Moulds
{
    public class MouldService : BaseService, IMouldService
    {

        public async Task<List<MouldGroup>> GetMouldGroups()
        {
            List <MouldGroup> groups = new List<MouldGroup>();
            await Sql.Run(
                    "SELECT * FROM MouldGroup m" + Sql.AddBaseEntity("m"),
                    r => {
                        groups.Add(ReadBaseEntity<MouldGroup>(r));
                    }
            );
            return groups;
        }
    }
}
