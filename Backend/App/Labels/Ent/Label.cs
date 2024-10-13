
namespace Backend.App.Labels.Ent
{
    public class Label
    {
        public int Id { get; set; }
        public int? _OrgId { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public DateTime Updated { get; set; }
        public string? Encoded { get; set; }
    }
}
