using System.Drawing;
using System.Reflection;
using Microsoft.Win32;

namespace System.Windows.Forms
{
	[System.ComponentModel.DesignerCategory("")]
	public class VPropertyGrid : System.Windows.Forms.PropertyGrid
    {
        public VPropertyGrid()
        {
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        }

        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);
            SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        }

        private void SystemEvents_UserPreferenceChanged(Object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.Color)
            {
                FieldInfo fi = typeof(PropertyGrid).GetField("selectedItemWithFocusBackBrush", BindingFlags.Instance | BindingFlags.NonPublic);
                if (fi != null)
                {
                    Brush selectedItemWithFocusBackBrush = fi.GetValue(this) as Brush;
                    if (selectedItemWithFocusBackBrush != null)
                    {
                        selectedItemWithFocusBackBrush.Dispose();
                        fi.SetValue(this, null);
                    }
                }
            }
        }
    }
}
