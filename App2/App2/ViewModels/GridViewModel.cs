using System;
using System.Collections.ObjectModel;

using App2.Models;
using App2.Services;

using GalaSoft.MvvmLight;

namespace App2.ViewModels
{
    public class GridViewModel : ViewModelBase
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
