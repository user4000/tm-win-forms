using System;
using System.IO;
using Telerik.WinControls.UI;


namespace TmWinForms
{
  public partial class FxMessage : RadForm
  {
    private static bool FormHasBeenShown = false;

    private static FxMessage instance = null;

    private FxMessage()
    {
      InitializeComponent();
      this.Load += EventFormLoad;
    }

    public static FxMessage Create()
    {
      if (instance == null)
      {
        instance = new FxMessage();
      }
      return instance;
    }

    private void EventFormLoad(object sender, EventArgs e)
    {
      BxClose.Click += new EventHandler(EventClose);
      //PnMessage.ZzHideBorder();
      //PnTop.ZzHideBorder();
    }

    private void EventClose(object sender, EventArgs e)
    {
      this.Close();
    }

    public void ShowMessage(string message)
    {
      if (FormHasBeenShown) return;

      FormHasBeenShown = true;

      TxMessage.Text = message;
      TxMessage.SelectionStart = 0;  
      TxMessage.SelectionLength = 0;
      try
      {
        LogErrorToFile(message);
      }
      catch
      {

      }
      this.ShowDialog();
    }

    public static void LogErrorToFile(string message)
    { 
      /*
      string IdFile = CxSecurity.GenerateRandomId(10);
      string filePath = $@"log\Application_Error_{CxConvert.DateTimeForFileName}_{IdFile}.txt";
      using (StreamWriter writer = new StreamWriter(filePath, true))
      {
        writer.WriteLine("-----------------------------------------------------------------------------");
        writer.WriteLine("Date : " + DateTime.Now.ToString());
        writer.WriteLine();
        writer.WriteLine(message);
      }
      */
    }
  }
}