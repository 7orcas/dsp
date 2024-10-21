using System.Collections.Generic;
using System.Security.Cryptography;

namespace Backend.App.Labels.Ent
{
    public class LabelManager
    {
        static private List<LangCode> langCodes;
        private Dictionary<string, Label> labels;
        private string langCode;
        private int orgId;


        /**
         * Main Constructor
         * Requires language code and organisation id
         */
        public LabelManager(List<Label> list, string langCode, int orgId)
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
        public void AppendList(List<Label> list, string? langCode)
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

        public bool IsLabel(string code)
        {
            return labels.ContainsKey(code);
        }

        public string GetLabel(string code)
        {
            if (labels.ContainsKey(code)) return labels[code].Description;
            return code;
        }

        public void UpdateLabel(Label label)
        {
            labels[label.Code] = label;
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

            return list;
        }

    }
}
