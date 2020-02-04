using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACT_FFXIV_Kapture.Presentation
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			BackColor = SystemColors.ControlLight;
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 1;
			FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
			SetStyle(ControlStyles.Selectable, false);
			Size = new Size
			{
				Height = 23,
				Width = 85
			};
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			BackColor = SystemColors.ControlLight;
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseLeave(e);
			BackColor = SystemColors.ControlDark;
		}
	}
}