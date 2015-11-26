using ListViewForCustomSection.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Persistence;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace ListViewForCustomSection.Controllers
{
    /// <summary>
    /// People Api controller used by the people resource to get people for our custom section
    /// </summary>
    [PluginController("ListViewDemo")]
    public class PeopleApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<People> GetAll()
        {
            return Enumerable.Empty<People>();
        }

        public PagedPeopleResult GetPaged(int itemsPerPage, int pageNumber, string sortColumn,
            string sortOrder, string searchTerm)
        {
            var items = new List<People>();
            var db = DatabaseContext.Database;

            var currentType = typeof(People);

            var query = new Sql().Select("*").From("demo_people");

            if (!string.IsNullOrEmpty(searchTerm))
            {
                int c = 0;
                foreach (var property in currentType.GetProperties())
                {
                    string before = "WHERE";
                    if (c > 0)
                    {
                        before = "OR";
                    }

                    var columnAttri =
                           property.GetCustomAttributes(typeof(ColumnAttribute), false);

                    var columnName = property.Name;
                    if (columnAttri.Any())
                    {
                        columnName = ((ColumnAttribute)columnAttri.FirstOrDefault()).Name;
                    }

                    query.Append(before + " [" + columnName + "] like @0", "%" + searchTerm + "%");
                    c++;
                }
            }
            if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortOrder))
                query.OrderBy(sortColumn + " " + sortOrder);
            else
            {
                query.OrderBy("id asc");
            }

            var p = db.Page<People>(pageNumber, itemsPerPage, query);
            var result = new PagedPeopleResult
            {
                TotalPages = p.TotalPages,
                TotalItems = p.TotalItems,
                ItemsPerPage = p.ItemsPerPage,
                CurrentPage = p.CurrentPage,
                People = p.Items.ToList()
            };
            return result;
        }
    }
}