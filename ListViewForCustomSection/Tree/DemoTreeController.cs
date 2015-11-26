using System;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;

namespace ListViewForCustomSection.Tree
{
    [Tree("demoSection", "demoTree", "ListView Demo")]
    [PluginController("ListViewDemo")]
    public class DemoTreeController : TreeController
    {
        protected override Umbraco.Web.Models.Trees.MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            return null;
        }

        protected override Umbraco.Web.Models.Trees.TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //check if we're rendering the root node's children
            if (id == "-1")
            {
                var nodes = new TreeNodeCollection();
                nodes.Add(CreateTreeNode("people", id, queryStrings, "People", "icon-people", false, FormDataCollectionExtensions.GetValue<string>(queryStrings, "application") + StringExtensions.EnsureStartsWith(this.TreeAlias, '/') + "/overviewPeople/all"));
                return nodes;
            }

            //this tree doesn't suport rendering more than 2 levels
            throw new NotSupportedException();
        }
    }
}