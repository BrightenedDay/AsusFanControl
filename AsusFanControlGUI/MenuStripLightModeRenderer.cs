using System.Drawing;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal class MenuStripLightModeRenderer : ToolStripProfessionalRenderer
    {
        public MenuStripLightModeRenderer() : base(new LightModeColors()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item is ToolStripMenuItem && e.Item.OwnerItem == null)
                e.Item.BackColor = Color.White;

            base.OnRenderMenuItemBackground(e);
        }

    }

    public class LightModeColors : ProfessionalColorTable
    {
        public override Color ImageMarginGradientBegin => Color.White;

        public override Color ImageMarginGradientMiddle => Color.White;

        public override Color ImageMarginGradientEnd => Color.White;
    }
}