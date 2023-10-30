using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraScheduler.Commands;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public class CustomFlyoutDialog : FlyoutDialog
    {
        public CustomFlyoutDialog(RibbonForm owner, FlyoutAction actions, Control UserControlToShow) : base(owner, actions)
        {
            this.Properties.HeaderOffset = 0;
            this.Properties.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Properties.Style = FlyoutStyle.Popup;
            this.FlyoutControl = UserControlToShow;
        }

        public static DialogResult ShowForm(RibbonForm owner, FlyoutAction action, Control UserControl)
        {
            CustomFlyoutDialog customDialog = new CustomFlyoutDialog(owner, action, UserControl);
            DialogResult result = customDialog.ShowDialog();
            return result;//;'lfgn;xdfioj
        }
    }

}
