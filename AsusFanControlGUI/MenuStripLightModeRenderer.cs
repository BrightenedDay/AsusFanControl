using System.Drawing;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal class MenuStripLightModeRenderer : ToolStripProfessionalRenderer
    {
        public MenuStripLightModeRenderer() : base() { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Text == "Settings")
                e.Item.BackColor = SystemColors.Control;

            base.OnRenderMenuItemBackground(e);
        }

    }
}