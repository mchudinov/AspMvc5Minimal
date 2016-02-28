using System;
using System.Collections.Generic;
using Models;

namespace UseCases
{
    public interface IWidgetCase
    {
        IList<Widget> GetAllWidgets();

        Guid CreateWidget(string name, float price);

        void DeleteWidget(Guid id);

        IList<Widget> GetWidgets(string searchString);

        Widget GetWidget(Guid id);
    }
}
