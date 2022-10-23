using System;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using static TmWinForms.FrameworkManager;

namespace TmWinForms
{
  public class CxImageLoader // Класс позволяет загружать из файлов кастомные значки для древовидного списка //
  {
    /// <summary>
    /// default value = "nav"
    /// </summary>
    public string MainFolder { get; set; } = "nav";

    /// <summary>
    /// default value = "png"
    /// </summary>
    public string ImageExt { get; set; } = "png";

    /// <summary>
    /// default value = "group"
    /// </summary>
    public string FileNameImageGroup { get; } = "group";

    /// <summary>
    /// default value = "item"
    /// </summary>
    public string FileNameImageItem { get; } = "item";


    /// <summary>
    /// default value = "group_exit"
    /// </summary>
    public string FileNameImageGroupExit { get; } = "group_exit";


    /// <summary>
    /// default value = "item_exit"
    /// </summary>
    public string FileNameImageItemExit { get; } = "item_exit";


    /// <summary>
    /// default value = "group_settings"
    /// </summary>
    public string FileNameImageGroupSettings { get; } = "group_settings";


    /// <summary>
    /// default value = "item_settings"
    /// </summary>
    public string FileNameImageItemSettings { get; } = "item_settings";


    /// <summary>
    /// default value = "item_messages"
    /// </summary>
    public string FileNameImageItemMessages { get; } = "item_messages";



    internal Image ImgGroup { get; private set; }

    internal Image ImgItem { get; private set; }

    internal Image ImgGroupExit { get; private set; }

    internal Image ImgItemExit { get; private set; }

    internal Image ImgGroupSettings { get; private set; }

    internal Image ImgItemSettings { get; private set; }

    internal Image ImgItemMessages { get; private set; }




    CxImageLoader()
    {

    }

    public static CxImageLoader Create() => new CxImageLoader();


    internal void TryToLoadImages()
    {
      if (FrameworkSettings.AllowLoadingImagesForTreeviewFromFiles == false) return;

      if (Directory.Exists(MainFolder) == false) return;

      ImgGroup = LoadFromFile(MainFolder, FileNameImageGroup, ImageExt);
      ImgGroupExit = LoadFromFile(MainFolder, FileNameImageGroupExit, ImageExt);
      ImgGroupSettings = LoadFromFile(MainFolder, FileNameImageGroupSettings, ImageExt);

      ImgItem = LoadFromFile(MainFolder, FileNameImageItem, ImageExt);
      ImgItemExit = LoadFromFile(MainFolder, FileNameImageItemExit, ImageExt);
      ImgItemSettings = LoadFromFile(MainFolder, FileNameImageItemSettings, ImageExt);
      ImgItemMessages = LoadFromFile(MainFolder, FileNameImageItemMessages, ImageExt);
    }

    internal Image LoadFromFile(string folder, string fileName, string fileExt)
    {
      Image image = null;
      string fullFileName = Path.Combine(folder, fileName) + "." + fileExt;
      if (File.Exists(fullFileName)) image = LoadFromFile(fullFileName);
      return image;
    }

    Image LoadFromFile(string fullFileName)
    {
      Image image = null;
      try
      {
        image = Image.FromFile(fullFileName);

        if ((image != null) && ((image.Width > 100) || (image.Height > 100)))
        {
          image = null;
          Trace.WriteLine($"Warning! [TmWinForms] framework: Image loaded from file [{fullFileName}] is too big.");
        }

        if ((image != null) && ((image.Width < 8) || (image.Height < 8)))
        {
          image = null;
          Trace.WriteLine($"Warning! [TmWinForms] framework: Image loaded from file [{fullFileName}] is too small.");
        }
      }
      catch (Exception ex)
      {
        Trace.WriteLine($"Error! [TmWinForms] framework: Failed to load image from a file [{fullFileName}]");
        Trace.WriteLine(ex.Message);
      }
      return image;
    }
  }
}