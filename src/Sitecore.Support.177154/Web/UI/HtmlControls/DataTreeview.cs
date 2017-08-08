using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web.UI.HtmlControls;

namespace Sitecore.Support.Web.UI.HtmlControls
{
    public class DataTreeview : Sitecore.Web.UI.HtmlControls.DataTreeview
    {
        protected override TreeNode GetTreeNode(Item item, System.Web.UI.Control parent)
        {
            Assert.ArgumentNotNull(item, "item");
            Assert.ArgumentNotNull(parent, "parent");
            DataTreeNode child = new DataTreeNode(); // Updated version of DataTreeNode is used instead. 
            parent.Controls.Add(child);
            child.Expandable = item.HasChildren;
            child.Expanded = false;
            child.Header = item.DisplayName;
            child.Icon = item.Appearance.Icon;
            child.ID = Control.GetUniqueID("T");
            child.ItemID = item.Paths.LongID;
            child.ToolTip = item.Name;
            child.DataContext = this.DataContext;
            if (item.TemplateID != TemplateIDs.TemplateField)
            {
                child.ItemStyle = item.Appearance.Style;
            }
            if (child.ItemStyle.Length == 0)
            {
                if (item.Appearance.Hidden)
                {
                    child.ItemStyle = "color:#666666";
                }
                else if (item.RuntimeSettings.IsVirtual)
                {
                    child.ItemStyle = "color:#666666";
                }
            }
            child.ShowCheckBox = base.ShowCheckboxes;
            if (this.AllowDragging)
            {
                child.Drag = "item:" + item.Uri;
                child.Drop = this.ID + ".DropItem(\"$Data\")";
            }
            foreach (string str in base.ColumnNames.Keys)
            {
                string str2 = item[str];
                if (str2.Length > 0)
                {
                    child.ColumnValues[str] = str2;
                }
            }
            return child;
        }

    }
}