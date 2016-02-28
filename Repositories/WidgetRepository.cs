using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class WidgetRepository : IWidgetRepository
    {
        public IList<Widget> GetAllWidgets()
        {
            using (var db = new AppDbContext())
            {
                return db.Widgets.AsNoTracking().OrderBy(u => u.Name).ToList();
            }
        }

        public Widget GetWidget(Guid id)
        {
            using (var db = new AppDbContext())
            {
                return db.Widgets.FirstOrDefault(u => u.Id == id);
            }
        }

        public IList<Widget> GetWidgets(string searchString)
        {
            using (var db = new AppDbContext())
            {
                return db.Widgets.AsNoTracking().Where(u => u.Name.ToLower().Contains(searchString.ToLower())).OrderBy(u => u.Name).ToList();
            }
        }

        public async Task SaveWidget(Widget widget)
        {
            using (var db = new AppDbContext())
            {
                db.Widgets.AddOrUpdate(widget);
                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteWidget(Guid id)
        {
            using (var db = new AppDbContext())
            {
                var user = GetWidget(id);
                db.Widgets.Attach(user);
                db.Widgets.Remove(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
