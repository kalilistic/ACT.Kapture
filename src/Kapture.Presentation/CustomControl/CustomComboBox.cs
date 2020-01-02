using System;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation.CustomControl
{
    internal class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            try
            {
                int i;
                SelectedIndex = (i = FindString(Text)) >= 0 ? i : 0;
            }
            catch
            {
            }
        }
    }
}