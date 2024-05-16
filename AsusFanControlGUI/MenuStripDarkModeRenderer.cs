using System.Drawing;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal class MenuStripDarkModeRenderer : ToolStripProfessionalRenderer
    {

        public MenuStripDarkModeRenderer() : base(new DarkModeColors()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Text == "Settings")
                e.Item.BackColor = Color.FromArgb(40, 40, 40);

            base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item is ToolStripDropDownItem)
            {
                e.ArrowColor = Color.White;
            }

            base.OnRenderArrow(e);
        }
    }

    public class DarkModeColors : ProfessionalColorTable
    {

        public override Color MenuItemPressedGradientBegin => Color.FromArgb(40, 40, 40);

        public override Color MenuItemPressedGradientEnd => Color.FromArgb(40, 40, 40);
        
        public override Color MenuItemBorder => Color.DarkGray;

        public override Color MenuBorder => Color.DarkGray;

        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(40, 40, 40);

        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(40, 40, 40);

        public override Color ToolStripDropDownBackground => Color.FromArgb(40, 40, 40);

        public override Color ImageMarginGradientBegin => Color.FromArgb(40, 40, 40);

        public override Color ImageMarginGradientMiddle => Color.FromArgb(40, 40, 40);

        public override Color ImageMarginGradientEnd => Color.FromArgb(40, 40, 40);

        public override Color SeparatorDark => Color.Black;

        public override Color ToolStripPanelGradientBegin => Color.FromArgb(40, 40, 40);

        public override Color MenuItemSelected => Color.FromArgb(40, 40, 40);

        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(40, 40, 40);

    }
}