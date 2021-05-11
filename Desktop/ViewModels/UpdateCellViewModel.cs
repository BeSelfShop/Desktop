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
    public class UpdateCellViewModel : Screen, IHandle<SelectedCellEventModel>
    {
        private IEventAggregator _eventAggregator;
        private ICellTypeEndpoint _cellTypeEndpoint;
        private ICellEndpoint _cellEndpoint;
        private string _cellNumber;
        private int _bedsCount;
        private BindingList<CellType> _cellTypes;
        private CellType _cellType;
        private Cell _cell;

        public UpdateCellViewModel(IEventAggregator eventAggregator, ICellTypeEndpoint cellTypeEndpoint, ICellEndpoint cellEndpoint)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _cellTypeEndpoint = cellTypeEndpoint;
            _cellEndpoint = cellEndpoint;
        }

        private async Task LoadCellDetails()
        {
            var cellType = await _cellTypeEndpoint.AllCellType();
            CellTypes = new BindingList<CellType>(cellType);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadCellDetails();
        }

        public void Handle(SelectedCellEventModel message)
        {
            _cell = message.SelectedCell;
        }
        public string CellNumber
        {
            get { return _cellNumber; }
            set
            {
                _cellNumber = value;
                NotifyOfPropertyChange(() => CellNumber);
                NotifyOfPropertyChange(() => CanAddPrisoner);

            }

        }
        public int BedsCount
        {
            get { return _bedsCount; }
            set
            {
                _bedsCount = value;
                NotifyOfPropertyChange(() => BedsCount);
                NotifyOfPropertyChange(() => CanAddPrisoner);

            }

        }

        public BindingList<CellType> CellTypes
        {
            get { return _cellTypes; }
            set
            {
                _cellTypes = value;
                NotifyOfPropertyChange(() => CellTypes);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }

        }
        public CellType SelectedCellType
        {
            get { return _cellType; }
            set
            {
                _cellType = value;
                NotifyOfPropertyChange(() => SelectedCellType);
                NotifyOfPropertyChange(() => CanAddPrisoner);
            }
        }
        public bool CanAddPrisoner
        {
            get
            {
                bool output = false;

                if ((CellNumber.Length > 0) && (BedsCount > 0) && (SelectedCellType != null))
                {
                    output = true;
                }

                return output;

            }

        }

        public void UpdateCell()
        {
            Cell cell;
            cell = _cell;
            if(CellNumber != null)
            {
                cell.CellNumber = CellNumber;
            }
            if (BedsCount != 0)
            {
                cell.BedsCount = BedsCount;
            }
            if (SelectedCellType != null)
            {
                cell.IdCellType = SelectedCellType.Id;
            }                       
            _cellEndpoint.UpdateCell(cell.Id,cell);
            _eventAggregator.PublishOnUIThread(new NextPageEventModel(typeof(CellViewModel)));
        }
    }
}

