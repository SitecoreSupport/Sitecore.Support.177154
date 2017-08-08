using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Web.UI.HtmlControls
{
    public class DataTreeNode : Sitecore.Web.UI.HtmlControls.DataTreeNode
    {
        protected new void Check()
        {
            Checked = !Checked; // The missing instruction to change Checked value was added.
            Sitecore.Context.ClientPage.ClientResponse.SetReturnValue(true);
        }
    }
}