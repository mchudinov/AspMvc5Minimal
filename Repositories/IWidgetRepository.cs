using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public interface IWidgetRepository    
    {
        IList<Widget> GetWidgets();

        IList<Widget> GetWidgets(string searchString);

        Widget GetWidget(Guid id);

        Task SaveWidget(Widget widget);

        Task DeleteWidget(Guid id);
    }
}
