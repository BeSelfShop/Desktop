using Caliburn.Micro;
using Desktop.Api.Endpoints;
using Desktop.EventModels;
using Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ViewModels
{
    public class CellViewModel : Screen
    { 
        private IEventAggregator _eventAggregator;
        private ICellEndpoint _cellEndpoint;
        private BindingList<Cell> _allCell;


        public CellViewModel(ICellEndpoint cellEndpoint, IEventAggregator eventAggregator)
        {
            _cellEndpoint = cellEndpoint ;
            _eventAggregator = eventAggregator;
        }

        private async Task LoadCells()
        {
            var cellList = await _cellEndpoint.AllCell();
            AllCell = new BindingList<Cell>(cellList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadCells();
        }

        public BindingList<Cell> AllCell
        {
            get { return _allCell; }
            set
            {
                _allCell = value;
                NotifyOfPropertyChange(() => AllCell);
            }
        }

        public async Task DeleteCell(Cell Cell)
        {

            await _cellEndpoint.DeleteCell(Cell.Id);
            await LoadCells();

        }

        public void AddCell()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(AddCellViewModel)));
        }
        public void UpdateCell()
        {
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(UpdateCellViewModel)));
        }


    }
}
