using Backend.App.Labels.Ent;
using Backend.Modules._Base;
using Microsoft.Data.SqlClient;

namespace Backend.App.Labels
{
    public class LabelService : BaseService, ILabelService
    {
        private LabelManager? _labelManager;

        public async Task<LabelManager> GetLabelManager(int? org)
        {
            if (_labelManager != null) return _labelManager;

            var list = new List<Label>();
            await Sql.Run(
                    "SELECT * FROM App.Label l",
                    r => {
                        var m = ReadEntity<Label>(r);
                        list.Add(m);
                    }
            );
            _labelManager = new LabelManager(list, org);
            return _labelManager;
        }

        private T ReadEntity<T>(SqlDataReader r) where T: Label, new()
        {
            var entity = new T();
            entity._OrgId = GetIdNull(r, "_OrgId");
            entity.Id = GetId(r, "Id");
            entity.Code = (string)r["Code"];
            entity.Description = GetString(r, "Descr");
            entity.Encoded = GetString(r, "Encoded");
            entity.Updated = (DateTime)r["Updated"];

            return entity;
        }
    }
}
