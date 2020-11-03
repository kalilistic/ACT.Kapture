using System;
using System.Drawing;
using System.Windows.Forms;

namespace ACT_FFXIV.Aetherbridge
{
	public sealed class CustomLabel : Label
	{
		public CustomLabel()
		{
			ForeColor = Color.Blue;
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			Font = new Font(Font, FontStyle.Regular);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseLeave(e);
			Font = new Font(Font, FontStyle.Underline);
		}
	}
}