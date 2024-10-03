using Backend.Modules.Moulds.Ent;

namespace Backend.Modules.Moulds
{
    public interface IMouldService
    {
        Task<List<MouldGroup>> GetMouldGroups();
    }
}
