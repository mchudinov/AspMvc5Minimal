using System;

namespace UseCases
{
    public interface IWidgetCase
    {
        Guid CreateWidget(string name, float price);

        void DeleteWidget(Guid id);
    }
}
