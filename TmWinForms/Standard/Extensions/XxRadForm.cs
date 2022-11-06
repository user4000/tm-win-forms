using System.Drawing;
using Telerik.WinControls.UI;

namespace TmWinForms.Extensions
{
  public static class XxRadForm
  {
    static ushort Zero { get; } = 0;

    public static FormTreeview ZzTreeview(this RadForm form)
    {
      return FrameworkManager.TvNodes.Select(form);
    }

    public static ushort ZzGetIdForm(this RadForm form)
    {
      SubForm subForm = SubForm.GetSubForm(form);
      return ((subForm == null) ? Zero : subForm.IdForm);
    }

    public static string ZzGetFormUniqueCode(this RadForm form)
    {
      SubForm subForm = SubForm.GetSubForm(form);
      return ((subForm == null) ? string.Empty : subForm.UniqueName);
    }

    public static string ZzGetGroupUniqueCode(this RadForm form)
    {
      if (form.ZzCheckIsTreeviewForm() == false) return string.Empty;

      TvForm tvForm = ZzGetTvForm(form);

      if ((tvForm == null) || (tvForm.FormGroup == null)) return string.Empty;

      return tvForm.FormGroup.Code;
    }

    public static Group ZzGetGroup(this RadForm form)
    {
      if (form.ZzCheckIsTreeviewForm() == false) return null;

      TvForm tvForm = ZzGetTvForm(form);

      if ((tvForm == null) || (tvForm.FormGroup == null)) return null;

      return tvForm.FormGroup;
    }



    public static bool ZzCheckIsTreeviewForm(this RadForm form)
    {
      SubForm subForm = SubForm.GetSubForm(form);
      return ((subForm is TvForm) && ((subForm as TvForm).Treeview != null));
    }

    public static SubForm ZzGetSubForm(this RadForm form)
    {
      return SubForm.GetSubForm(form);
    }

    public static TvForm ZzGetTvForm(this RadForm form)
    {
      SubForm subForm = SubForm.GetSubForm(form);
      if (subForm is TvForm) return (subForm as TvForm);
      return null;
    }





    public static bool ZzEnableMe(this RadForm form, bool enable)
    {
      ushort idForm = form.ZzGetIdForm();

      if (idForm == 0) return false;

      if (form.ZzCheckIsTreeviewForm())
      {
        FormTreeview tv = form.ZzTreeview();
        return tv.EnableNode(idForm, enable);
      }

      return FrameworkManager.Pages.EnablePage(idForm, enable);
    }

    public static bool ZzShowMe(this RadForm form, bool show)
    {
      ushort idForm = form.ZzGetIdForm();

      if (idForm == 0) return false;

      if (form.ZzCheckIsTreeviewForm())
      {
        FormTreeview tv = form.ZzTreeview();
        return tv.ShowNode(idForm, show);
      }

      return FrameworkManager.Pages.ShowPage(idForm, show);
    }

    public static bool ZzGotoMe(this RadForm form)
    {
      ushort idForm = form.ZzGetIdForm();

      if (idForm == 0) return false;

      if (form.ZzCheckIsTreeviewForm())
      {
        FormTreeview tv = form.ZzTreeview();
        return tv.GotoForm(idForm);
      }

      return FrameworkManager.Pages.GotoPage(idForm);
    }

    public static bool ZzSetMyText(this RadForm form, string text)
    {
      ushort idForm = form.ZzGetIdForm();

      if (idForm == 0) return false;

      if (form.ZzCheckIsTreeviewForm())
      {
        FormTreeview tv = form.ZzTreeview();
        return tv.SetText(idForm, text);
      }

      return FrameworkManager.Pages.SetText(idForm, text);
    }

    public static bool ZzSetMyImage(this RadForm form, Image image)
    {
      ushort idForm = form.ZzGetIdForm();

      if (idForm == 0) return false;

      if (form.ZzCheckIsTreeviewForm())
      {
        FormTreeview tv = form.ZzTreeview();
        return tv.SetImage(idForm, image);
      }

      return FrameworkManager.Pages.SetImage(idForm, image);
    }
  }
}