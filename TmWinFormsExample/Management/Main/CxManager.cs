using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TmWinFormsExample
{
  public class CxManager
  {

    public CxLocalizer Localizer { get; } = new CxLocalizer();

    private CxManager()
    {
      
    }

    public static CxManager Create()
    {
      CxManager manager = new CxManager();
      return manager;
    }
  }
}