using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  partial class FrameworkService
  {
    int IndexPage { get; set; } = 0;

    bool PageExists(string uniqueName) => DicForms.ContainsKey(uniqueName);




    internal void AddSubFormToDictionary(SubForm form)
    {
      try
      {
        if (DicForms.ContainsKey(form.UniqueName) == false) DicForms.Add(form.UniqueName, form);
      }
      catch
      {
        if (form != null)
          RadMessageBox.Show($"Error ! Failed to add a Sub-form [{form.UniqueName}] to dictionary!");
        throw;
      }
    }


    internal RadPageViewPage CreateNewPage(SubForm form)
    {
      RadPageViewPage page = new RadPageViewPage() { Name = form.UniqueName, Text = form.PageText };

      MainForm.PvMain.Pages.Insert(++IndexPage, page);

      MainForm.PvMain.SelectedPage = null;

      page.ItemSize = new SizeF(120F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;

      return page;
    }

    private void AddFormToPage(SubForm subForm)
    {
      if (PageExists(subForm.UniqueName)) return;

      var page = CreateNewPage(subForm);

      AddSubFormToDictionary(subForm);

      RadForm form = subForm.Form;

      form.TopLevel = false; /* It is very important */

      form.Dock = DockStyle.Fill;
      form.FormBorderStyle = FormBorderStyle.None;
      form.Visible = true;
      form.BringToFront();

      page.Controls.Add(form);

      subForm.SetPage(page);

      page.Tag = subForm;

      page.Item.MinSize = new Size(FrameworkManager.FrameworkSettings.TabMinimumWidth, 0);

      page.Item.Visibility = subForm.FlagTabVisible ? ElementVisibility.Visible : ElementVisibility.Collapsed;

      page.Item.Enabled = subForm.FlagTabEnabled;

      if ((subForm.FlagTabVisible) && (MainForm.PvMain.Visible)) page.Refresh();

      //CheckIsSettingsForm(subForm.ChildForm);
      //CheckIsLogForm(subForm.ChildForm);
      //CheckIsExitForm(subForm.ChildForm);
    }
  }
}
