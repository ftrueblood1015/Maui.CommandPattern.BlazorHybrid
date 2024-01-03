using System.Globalization;

namespace Maui.CommandPattern.BlazorHybrid.Constants
{
    public class Splats
    {
        public static Dictionary<string, object> CancelButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_cancel" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Error },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Cancel },
            };

            return attributes;
        }

        public static Dictionary<string, object> CheckBox(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"checkbox_{label.ToLower()}" },
                { "Label", label },
                { "Color", MudBlazor.Color.Primary },
                { "LabelPosition", MudBlazor.LabelPosition.Start },
                { "Required", true },
            };

            return attributes;
        }

        public static Dictionary<string, object> DataGrid(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"datagrid_{GenerateId(label)}" },
                { "SortMode", MudBlazor.SortMode.Multiple },
                { "Filterable", true },
                { "FilterMode", MudBlazor.DataGridFilterMode.Simple },
                { "FilterCaseSensitivity", MudBlazor.DataGridFilterCaseSensitivity.CaseInsensitive },
                { "Dense", true },
                { "Striped", true },
            };

            return attributes;
        }

        public static Dictionary<string, object> DatePicker(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"datagrid_{GenerateId(label)}" },
                { "Label", label },
                { "DateFormat", "MM/dd/yyyy" },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
            };

            return attributes;
        }

        public static Dictionary<string, object> DeleteButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_delete" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Error },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Delete },
            };

            return attributes;
        }

        public static Dictionary<string, object> EditButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_edit" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Warning },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Edit },
            };

            return attributes;
        }

        public static string GenerateId(string label)
        {
            return label.ToLower(CultureInfo.CurrentCulture);
        }

        public static Dictionary<string, object> NewButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_new" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Success },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Add },
            };

            return attributes;
        }

        public static Dictionary<string, object> NumericRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"numeric_{GenerateId(label)}" },
                { "Variant", MudBlazor.Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
                { "Min", 0 },
            };

            return attributes;
        }

        public static Dictionary<string, object> PageHeader(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"header_{GenerateId(label)}" },
                { "Typo", MudBlazor.Typo.h4 }
            };

            return attributes;
        }

        public static Dictionary<string, object> ResetButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_reset" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Warning },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Redo },
            };

            return attributes;
        }

        public static Dictionary<string, object> SaveButton()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"button_save" },
                { "Variant",MudBlazor.Variant.Filled },
                { "Color", MudBlazor.Color.Success },
                { "StartIcon", MudBlazor.Icons.Material.Filled.Save },
            };

            return attributes;
        }

        public static Dictionary<string, object> SearchField()
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", "text_search" },
                { "Placeholder", "Search" },
                { "Adornment", MudBlazor.Adornment.Start },
                { "AdornmentIcon", MudBlazor.Icons.Material.Filled.Search },
                { "IconSize", MudBlazor.Size.Medium },
                { "Immediate", true },
            };

            return attributes;
        }

        public static Dictionary<string, object> SelectOptional(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"select_{GenerateId(label)}" },
                { "Variant", MudBlazor.Variant.Outlined },
            };

            return attributes;
        }

        public static Dictionary<string, object> SelectRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"select_{GenerateId(label)}" },
                { "Variant", MudBlazor.Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
            };

            return attributes;
        }

        public static Dictionary<string, object> TextRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"text_{GenerateId(label)}" },
                { "Variant", MudBlazor.Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
                { "OnlyValidateIfDirty", true }
            };

            return attributes;
        }

        public static Dictionary<string, object> TextAreaRequired(string label)
        {
            Dictionary<string, object> attributes = new ()
            {
                { "id", $"textarea_{GenerateId(label)}" },
                { "Variant", MudBlazor.Variant.Outlined },
                { "Required", true },
                { "RequiredError", $"{label} is required." },
                { "Label", label },
                { "Lines", 3 },
            };

            return attributes;
        }
    }
}
