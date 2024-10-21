﻿using Backend.App.Labels.Ent;
using Backend.Modules._Base;
using Microsoft.Data.SqlClient;

namespace Backend.App.Labels
{
    public class LabelService : BaseService, ILabelService
    {
        private LabelManager? _labelManager;

        public async Task<LabelManager> GetLabelManager(string langCode, int orgId)
        {
            if (_labelManager != null
                && _labelManager.IsConfig(langCode, orgId)
                ) return _labelManager;

            //Step 1: get labels for passed in lang code and org
            var list = await GetLabelList(langCode, orgId);
            _labelManager = new LabelManager(list, langCode, orgId);

            //Step 2: get labels for passed in lang code and null org (default)
            list = await GetLabelList(langCode, null);
            _labelManager.AppendList(list, null);

            //Step 3 Optional: get labels for default lang code and default org 
            var langDefault = LabelManager.GetLanguageCodeDefault();
            if (langDefault != langCode)
            {
                list = await GetLabelList(langDefault, null);
                _labelManager.AppendList(list, langDefault);
            }

            return _labelManager;
        }

        public async Task<List<Label>> GetLabels(string langCode)
        {
            var list = await GetLabelList(langCode, null);
            foreach (var label in list)
                label.LangCode = langCode;
            
            return list;
        }

        private async Task<List<Label>> GetLabelList(string langCode, int? orgId)
        {
            string sql = "SELECT l.* FROM App.Label l "
                    + "WHERE l.Lang = '" + langCode + "' ";

            if (orgId.HasValue) 
                sql += "AND l._OrgId = " + orgId;

            //Step 1: get labels for passed in lang code and org
            var list = new List<Label>();
            await Sql.Run(sql,
                    r => {
                        var m = ReadEntity<Label>(r);
                        list.Add(m);
                    }
            );

            return list;

        }

        private T ReadEntity<T>(SqlDataReader r) where T: Label, new()
        {
            var entity = new T();
            entity._OrgId = GetIdNull(r, "_OrgId");
            entity.Id = GetId(r, "Id");
            entity.Code = (string)r["Code"];
            entity.Description = GetString(r, "Descr");
            entity.Tooltip = GetString(r, "Tooltip");
            entity.Encoded = GetString(r, "Encoded");
            entity.Updated = (DateTime)r["Updated"];

            return entity;
        }
    }
}
