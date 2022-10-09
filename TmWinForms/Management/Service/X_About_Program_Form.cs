using System;

namespace TmWinForms
{
  public partial class FrameworkService
  {
    public void SetAboutProgramForm(ushort idForm)
    {
      IdAboutProgramForm = idForm;
    }

    public void SetAboutProgramForm(string UniqueFormName)
    {
      CodeAboutProgramForm = UniqueFormName;
    }

    bool IsAboutProgramForm(SubForm form)
    {
      return

        (
          (form.IdForm == IdAboutProgramForm) && (IdAboutProgramForm > 0)
        )

        ||

        (
          (form.UniqueName == CodeAboutProgramForm) && (string.IsNullOrWhiteSpace(CodeAboutProgramForm) == false)
        );
    }
  }
}