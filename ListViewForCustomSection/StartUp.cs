using ListViewForCustomSection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace ListViewForCustomSection
{
    public class Startup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            var db = applicationContext.DatabaseContext.Database;

            if (db.TableExist("demo_people"))
            {
                db.DropTable<People>();
            }
            db.CreateTable<People>(false);

            var objects = Enumerable.Range(0, 10).Select(i => new People() { FirstName = "Firstname" + i, LastName = "Lastname" + i, Age = i + 20 });
            objects.ForEach(p => db.Save(p));
        }
    }
}