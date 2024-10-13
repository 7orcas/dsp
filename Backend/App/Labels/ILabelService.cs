using Backend.App.Labels.Ent;

namespace Backend.App.Labels
{
    public interface ILabelService
    {
        Task<List<Label>> GetLabels();
    }
}
