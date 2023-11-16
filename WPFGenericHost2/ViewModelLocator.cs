using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFGenericHost2.ViewModels;

namespace WPFGenericHost2
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel MainWindow => ServiceLocator.Services.GetRequiredService<MainViewModel>();
        public Window1ViewModel Window1 => ServiceLocator.Services.GetRequiredService<Window1ViewModel>();
    }
}
