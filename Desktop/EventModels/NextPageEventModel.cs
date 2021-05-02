using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.EventModels
{
    public class NextPageEventModel
    {
        public readonly Type _ViewModelType;

        public NextPageEventModel(Type ViewModelType)
        {
            _ViewModelType = ViewModelType;
        }
        
        
        
    }
}
