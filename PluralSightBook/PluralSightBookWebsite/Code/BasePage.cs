using System;
using System.Linq;
using StructureMap;

namespace PluralSightBookWebsite.Code
{
    /// <summary>
    /// http://www.gbogea.com/2009/12/07/using-structuremap-with-aspnet-webforms
    /// </summary>
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            ObjectFactory.BuildUp(this);
        }
    }
}