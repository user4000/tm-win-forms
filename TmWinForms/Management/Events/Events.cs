using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace TmWinForms
{
  public class UserEvents
  {
    public Action<RadPageViewPage> UserVisitedPage { get; set; }

    public Action<RadPageViewPage> UserLeftPage { get; set; }


    public Action MainFormResize { get; set; }

    public Action MainFormResizeEnd { get; set; }

    public Action MainFormResizeBegin { get; set; }



    public Action BeforeMainFormIsCreated { get; set; }


    /// <summary>
    /// Here you can override framework settings loaded from text file.
    /// </summary>
    public Action OverrideLoadedFrameworkSettings { get; set; }









    /// <summary>
    /// Order of execution 1
    /// </summary>
    public Action MainFormLoad { get; set; }

    /// <summary>
    /// Order of execution 2
    /// </summary>
    public Action BeforeSubFormsAreCreated { get; set; }

    /// <summary>
    /// Order of execution 3
    /// </summary>
    public Action BeforeMainFormBecomesVisible { get; set; }

    /// <summary>
    /// Order of execution 4
    /// </summary>
    public Action MainFormShown { get; set; }

    /// <summary>
    /// Order of execution 5
    /// </summary>
    public Action Start { get; set; }


    /// <summary>
    /// Order of execution 6
    /// </summary>
    public Func<Task> StartAsync { get; set; }


    /// <summary>
    /// Order of execution 7
    /// </summary>
    public Action StartByTimer { get; set; }


    /// <summary>
    /// Order of execution 8
    /// </summary>
    public Func<Task> StartByTimerAsync { get; set; }








    #region События, выполняемые при попытке закрытия формы OnFromClosing


    public Action UserClickedExitButton { get; set; }

    public Action MainFormClosing { get; set; }

    public Func<Task> MainFormClosingAsync { get; set; }




    #endregion






    public Action<object, FormClosedEventArgs> MainFormClosed { get; set; }

 

 


    UserEvents()
    {

    }

    public static UserEvents Create() => new UserEvents();
  }
}