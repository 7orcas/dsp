
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.App.Labels.Ent
{
    public class Label
    {
        public int Id { get; set; }
        public int? _OrgId { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public string? Tooltip { get; set; }
        public DateTime Updated { get; set; }
        public string? Encoded { get; set; }

        /*
         * Indicates this label has been loaded with this lang code
         */
        [NotMapped]
        public string? LangCode { get; set; }
    }
}
