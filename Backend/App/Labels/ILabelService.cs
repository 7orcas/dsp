using Backend.App.Labels.Ent;

namespace Backend.App.Labels
{
    public interface ILabelService
    {
        Task<LabelManager> GetLabelManager(string langCode, int orgId);
        Task<List<Label>> GetLabels(string langCode);
    }
}
