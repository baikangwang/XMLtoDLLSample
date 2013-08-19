using System;
using System.Windows.Forms;

namespace XMLtoDLLSample
{
    public static class ComboBoxExt
    {
        public static string GetSelectedValue(this ComboBox cmb)
        {
            object item = cmb.SelectedItem;
            if (item == null)
                return string.Empty;
            object key = item.GetType().GetProperty("Value").GetValue(item, null);
            return key == null ? string.Empty : Convert.ToString(key);

        }

        public static string GetSelectedText(this ComboBox cmb)
        {
            object item = cmb.SelectedItem;
            if (item == null)
                return string.Empty;
            object value = item.GetType().GetProperty("Text").GetValue(item, null);
            return value == null ? string.Empty : Convert.ToString(value);
        }
    }
}
