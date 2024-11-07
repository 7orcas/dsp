using Backend.Modules._Base;

namespace Backend.App.Labels.Ent
{
    public class LabelManager
    {
        static private List<LangCode> langCodes;
        private Dictionary<string, LangLabel> labels;
        private string langCode;
        private int orgId;


        /**
         * Main Constructor
         * Requires language code and organisation id
         */
        public LabelManager(List<LangLabel> list, string langCode, int orgId)
        {
            if (langCodes == null) 
                langCodes = SetupLanguageCodes();
            
            this.langCode = langCode;
            this.orgId = orgId;
            this.labels = list.ToDictionary(x => x.Code, x => x);
        }

        /**
         * Append default labels, ie there maybe missing labels in the constructor list
         */
        public void AppendList(List<LangLabel> list, string? langCode)
        {
            foreach (var label in list)
            {
                if (!labels.ContainsKey(label.Code))
                {
                    label.LangCode = langCode;
                    labels[label.Code] = label;
                }
            }
        }

        /**
         * Has this language manager been created using the language code and orgisational id?
         */
        public bool IsConfig(string langCode, int orgId)
        {
            return this.langCode == langCode && this.orgId == orgId;
        }

        /**
         * Is this label in the loaded language code?
         */
        public bool IsLabel(string code)
        {
            if (!labels.ContainsKey(code)) return false;
            var label = labels[code];
            if (label.LangCode != null) return false;
            return true;
        }

        public string GetLabel(string code)
        {
            if (labels.ContainsKey(code)) return labels[code].Description;
            return code;
        }

        public void UpdateLabel(LangLabel label)
        {
            if (!labels.ContainsKey(label.Code)) return;
            var l = labels[label.Code];
            if (U.IsSameOrg(l._OrgId, label._OrgId))
                labels[label.Code] = label;
        }

        public bool InsertLabel(LangLabel label)
        {
            LangLabel currLabel = null;
            if (labels.ContainsKey(label.Code))
                currLabel = labels[label.Code];

            if (currLabel != null && U.IsSameOrg(currLabel._OrgId, label._OrgId))
                return false;

            labels[label.Code] = label;
            return true;
        }

        public bool IsTooltip(string code)
        {
            return GetTooltip(code) != null;
        }

        public string? GetTooltip(string code) {
            if (labels.ContainsKey(code)) return labels[code].Tooltip;
            return null;
        }

        public string GetLanguageCode()
        {
            return this.langCode;   
        }

        static public string? GetLanguageCodeDefault()
        {
            foreach (var langCode in GetLanguageCodes())
            {
                if (langCode.IsDefault) return langCode.Code;
            }
            return null;
        }

        static public List<LangCode> GetLanguageCodes()
        {
            if (langCodes == null)
                langCodes = SetupLanguageCodes();
            return langCodes;
        }

        /**
         * Manual atm
         */
        static private List<LangCode> SetupLanguageCodes()
        {
            var list = new List<LangCode>();

            list.Add(new LangCode
            {
                Id = 1,
                Code = "en",
                Description = "English",
                IsDefault = true,
            });

            list.Add(new LangCode
            {
                Id = 2,
                Code = "de",
                Description = "Deutsch"
            });

            list.Add(new LangCode
            {
                Id = 3,
                Code = "es",
                Description = "Español"
            });

            list.Add(new LangCode
            {
                Id = 3,
                Code = "it",
                Description = "Italian"
            });

            return list;
        }

    }
}
