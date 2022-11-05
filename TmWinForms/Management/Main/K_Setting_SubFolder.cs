using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TmWinForms
{
  partial class FrameworkManager
  {
    internal static string SettingSubFolderName { get; set; } = string.Empty;

    internal static bool IncorrectCharacter(string testName)
    {
      Regex containsBadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
      if (containsBadCharacter.IsMatch(testName)) return true;

      containsBadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars())) + "]");
      if (containsBadCharacter.IsMatch(testName)) return true;

      return false;
    }

    internal static void SetSubFolderForSettings(string settingSubFolderName)
    {
      SettingSubFolderName = settingSubFolderName.Trim();
      if (IncorrectCharacter(SettingSubFolderName))
      {
        SettingSubFolderName = string.Empty;
        //SettingSubFolderName = Assembly.GetExecutingAssembly().GetName().Name ;
        //MessageBox.Show("Folder name contains incorrect character", "ArgumentName = [settingSubFolderName]");
      }
    }

    internal static string CheckIfSettingSubFolderIsSpecified(string FileName)
    {
      /*
      Example:
      settings\my_file_name.txt    =>   settings\subfolder\my_file_name.txt
      */

      if (SettingSubFolderName != string.Empty) FileName = FileName.Replace(@"\", @"\" + SettingSubFolderName + @"\");
      return FileName;
    }

    internal static void SaveErrorToTextFile(string message, Exception ex)
    {
      string filePath = @"1______Error______1.txt";

      using (StreamWriter writer = new StreamWriter(filePath, true))
      {
        writer.WriteLine("-----------------------------------------------------------------------------");
        writer.WriteLine("Date : " + DateTime.Now.ToString());
        writer.WriteLine();

        while (ex != null)
        {
          writer.WriteLine(ex.GetType().FullName);
          writer.WriteLine("Message : " + ex.Message);
          writer.WriteLine("StackTrace : " + ex.StackTrace);

          ex = ex.InnerException;
        }
      }
    }
  }
}