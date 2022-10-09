using System;
using System.Drawing;
using System.Diagnostics;
using Telerik.WinControls;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static TmWinForms.FrameworkManager;

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

    void AddPageAndFormToDictionary(RadPageViewPage page, RadForm form)
    {
      if (DicPages.ContainsKey(page) == false) DicPages.Add(page, form);
    }

    private void AddFormToPage(SubForm subForm)
    {
      if (PageExists(subForm.UniqueName)) return;

      RadPageViewPage page = CreateNewPage(subForm);

      AddSubFormToDictionary(subForm);

      RadForm form = subForm.Form;

      form.TopLevel = false; /* It is very important */

      form.Dock = DockStyle.Fill;
      form.FormBorderStyle = FormBorderStyle.None;
      form.Visible = true;
      form.BringToFront();

      page.Controls.Add(form);

      AddPageAndFormToDictionary(page, form);


      subForm.SetPage(page);

      page.Tag = subForm;
      
      page.Item.MinSize = new Size(FrameworkSettings.TabMinimumWidth, 0);

      page.Item.Visibility = subForm.FlagTabVisible ? ElementVisibility.Visible : ElementVisibility.Collapsed;

      page.Item.Enabled = subForm.FlagTabEnabled;

      //if ((subForm.FlagTabVisible) && (MainForm.PvMain.Visible)) page.Refresh();
    }
  }
}