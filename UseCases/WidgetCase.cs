using System;
using System.Collections.Generic;
using Models;
using Repositories;

namespace UseCases
{
    public class WidgetCase : IWidgetCase
    {
        private readonly IWidgetRepository _repo;

        public WidgetCase(IWidgetRepository repo)
        {
            _repo = repo;
        }

        public Guid CreateWidget(string name, float price)
        {
            var w = new Widget {Name = name, Price = price};
            _repo.SaveWidget(w);
            return w.Id;
        }

        public void DeleteWidget(Guid id)
        {
            _repo.DeleteWidget(id);
        }

        public IList<Widget> GetAllWidgets()
        {
            return _repo.GetAllWidgets();
        }

        public Widget GetWidget(Guid id)
        {
            return _repo.GetWidget(id);
        }

        public IList<Widget> GetWidgets(string searchString)
        {
            return _repo.GetWidgets(searchString);
        }
    }
}
