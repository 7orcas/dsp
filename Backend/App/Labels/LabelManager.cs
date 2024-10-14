using Backend.App.Labels.Ent;
using System.Collections.Generic;

namespace Backend.App.Labels
{
    public class LabelManager
    {
        private Dictionary<string, Label> labels;

        public LabelManager(List<Label>? list, int? org) 
        {
            labels = list.ToDictionary(x => x.Code, x => x);
        }

        public string GetLabel(string code)
        {
            if (labels.TryGetValue(code, out Label label)) return label.Code;
            return code;
        }
        public bool IsLabel(string code)
        {
            return labels.ContainsKey(code);
        }

    }
}
