using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Customized.Model;
using Customized.View;
using Xamarin.Forms;

namespace Customized.PageModel
{
    public class ClockinPageModel : INotifyPropertyChanged
    {

        //IMPLEMENT INTERFACES BEGIN
        public event PropertyChangedEventHandler PropertyChanged;

        //IMPLEMENT INTERFACES END




        //OBSERVABLE COLLECTION PROPERTY BEGIN, THIS COLLECTION USES THE <TYPE> WORKITEM CLASS
        ObservableCollection<WorkItem> _workItems;
        public ObservableCollection<WorkItem> WorkItems
        {
            get => _workItems;
            set
            {
                _workItems = value;
                OnPropertyChanged(nameof(WorkItems));
            }
        }
        //OBSERVABLE COLLECTION PROPERTY END
        




        //COMMAND PROPERTIES BEGIN
        public ICommand ClockinCommand { get; set; }
        public ICommand ClockoutCommand { get; set; }

        //COMMAND PROPERTIES END






        //PROPERTY DECLARATIONS BEGIN

        private DateTime _clockIn;
        public DateTime Clockin
        {
            get => _clockIn;
            set
            {
                _clockIn = value;
                OnPropertyChanged(nameof(Clockin));
               

            }
        }



        private DateTime _clockOut;
        public DateTime Clockout
        {
            get => _clockOut;
            set
            {
                _clockOut = value;
                OnPropertyChanged(nameof(Clockout));
            }
        }




        private bool _isClockedIn;
        public bool IsClockedIn
        {
            get => _isClockedIn;
            set
            {
                _isClockedIn = value;
                OnPropertyChanged(nameof(IsClockedIn));
            }
        }

        //PROPERTY DECLARATIONS END 









        //METHOD DECLARATIONS BEGIN
        public void ClockinMethod()
        {
            if (IsClockedIn == false)
            {
            Clockin = DateTime.Now;
            IsClockedIn = !IsClockedIn;
            }
            
            
        }

        public void ClockoutMethod()
        {
            if (IsClockedIn == true)
            {
                Clockout = DateTime.Now;
                WorkItems.Insert(0, new WorkItem
                {
                    End = Clockout,
                    Start = Clockin,

                });

                IsClockedIn = false;
                
            }

            else
            {
                ClockoutCommand = null;
            }

        }



        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //METHOD DECLARATIONS END 
















        //PROPERTY TO DISPLAY TIME EACH SECOND BEGIN
        DateTime _dateTime;

        public DateTime DateTime
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DateTime"));

            }
        }
        //PROPERTY TO DISPLAY TIME EACH SECOND END


        //CONSTRUCTOR BEGIN
        public ClockinPageModel()
        {
            //INITIALIZE COLLECTION
            WorkItems = new ObservableCollection<WorkItem>();
            //INITIALIZE COMMANDS
            ClockinCommand = new Command(ClockinMethod);
            ClockoutCommand = new Command(ClockoutMethod);
            //INITIALIZE DISPLAY TIME EACH SECOND 
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime = DateTime.Now;
                return true;
            });
        }
        //CONSTRUCTOR END
    }
}
