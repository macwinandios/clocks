using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Customized.Model;
using Xamarin.Forms;

namespace Customized.PageModel
{
    public class PayPageModel : ClockinPageModel
    {


        ClockinPageModel model = new ClockinPageModel();
        public PayPageModel()
        {
            
            model.WorkItems = new ObservableCollection<WorkItem>();
            
            
        }
    }
}
