using System.Drawing;
using System.Windows.Forms;

namespace ACT_FFXIV.Aetherbridge
{
	public class CustomPanel : Panel
	{
		public CustomPanel()
		{
			SetStyle(ControlStyles.UserPaint |
			         ControlStyles.ResizeRedraw |
			         ControlStyles.DoubleBuffer |
			         ControlStyles.AllPaintingInWmPaint,
				true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			using (var brush = new SolidBrush(BackColor))
			{
				e.Graphics.FillRectangle(brush, ClientRectangle);
			}

			e.Graphics.DrawRectangle(Pens.Transparent, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
		}
	}
}