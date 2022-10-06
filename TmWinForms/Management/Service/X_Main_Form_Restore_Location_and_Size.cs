using System;
using System.Drawing;
using Telerik.WinControls;

namespace TmWinForms
{
  partial class FrameworkService
  {
    internal void RestoreMainFormLocationAndSize(Point location, Size size)
    {
      if (FrameworkManager.FrameworkSettings.RememberMainFormLocation == false) return;

      if ((location.X < 0) || (location.Y < 0))
      {
        location = new Point(20, 20);
      }

      if ((size.Width < MainForm.MinimumSize.Width) || (size.Height < MainForm.MinimumSize.Height))
      {
        size = new Size(MainForm.MinimumSize.Width + 100, MainForm.MinimumSize.Height + 100);
      }

      MainForm.Location = location;
      MainForm.Size = size;
    }
  }
}