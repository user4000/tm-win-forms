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




    internal RadPageViewPage CreateNewPage(SubForm form)
    {
      RadPageViewPage page = null;

      if (FlagItIsTimeToAddStandardForms == false)
      {
        page = new RadPageViewPage() { Name = form.UniqueName, Text = form.PageText };
        MainForm.PvMain.Pages.Insert(++IndexPage, page);
      }
      else
      {
        page = TryToFindExistingPage(form.Form);
      }

      if (page == null) throw new ApplicationException("Error! Failed to find a [PageView] for standard form!");

      MainForm.PvMain.SelectedPage = null;

      page.ItemSize = new SizeF(120F, 30);
      page.Location = new Point(10, 10);
      page.TextAlignment = ContentAlignment.MiddleCenter;

      RadPageViewStripElement element = (RadPageViewStripElement)MainForm.PvMain.GetChildAt(0);

      element.ShowItemPinButton = false;
      element.StripButtons = StripViewButtons.Scroll;
      element.ItemAlignment = StripViewItemAlignment.Near;
      element.ItemFitMode = StripViewItemFitMode.FillHeight;
      element.ShowItemCloseButton = false;
      element.ItemSpacing = FrameworkSettings.PageViewItemSpacing;

      if (FrameworkSettings.StripOrientation != StripViewAlignment.Top) SetMainPageViewTabOrientation(FrameworkSettings.StripOrientation);

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