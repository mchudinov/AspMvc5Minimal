using System;
using System.Collections.Generic;
using Models;

namespace UseCases
{
    public interface IWidgetCase
    {
        IList<Widget> GetWidgets();

        IList<Widget> GetWidgets(string searchString);

        Widget GetWidget(Guid id);

        Guid CreateWidget(string name, float price);

        void UpdateWidget(Widget widget);

        void DeleteWidget(Guid id);
    }
}
