using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;

namespace Countr.Core.ViewModels
{
    public class CountersViewModel : MvxViewModel
    {
        readonly ICountersService service;
        readonly MvxSubscriptionToken token;
        readonly IMvxNavigationService navigationService;

        public CountersViewModel(ICountersService service, IMvxNavigationService navigationService)
        {
            Console.WriteLine("Tatiana: inside CountersViewModel() constructor");
            this.service = service;
            this.navigationService = navigationService;
            Counters = new ObservableCollection<CounterViewModel>();
            ShowAddNewCounterCommand = new MvxAsyncCommand(ShowAddNewCounter);
        }
        //public CountersViewModel(ICountersService service, IMvxMessenger messenger, IMvxNavigationService navigationService)
        //{
        //    Console.WriteLine("Tatiana: inside CountersViewModel() constructor");
        //    this.service = service;
        //    this.navigationService = navigationService;
        //    token = messenger.SubscribeOnMainThread<CountersChangedMessage>(async m => await LoadCounters());
        //    Counters = new ObservableCollection<CounterViewModel>();
        //    ShowAddNewCounterCommand = new MvxAsyncCommand(ShowAddNewCounter);
        //}

        public ObservableCollection<CounterViewModel> Counters { get; }

        public override async Task Initialize()
        {
            Console.WriteLine("Tatiana: inside Initialize() in CountersViewModel.cs");

            await LoadCounters();
        }

        public async Task LoadCounters()
        {
            Counters.Clear();
            var counters = await service.GetAllCounters();
            Console.WriteLine("Tatiana: inside LoadCounters() in CountersViewModel.cs;  counters number = " + counters);
            foreach (var counter in counters)
            {
                var viewModel = new CounterViewModel(service, navigationService);
                viewModel.Prepare(counter);
                Counters.Add(viewModel);
            }
            

        }
        public IMvxAsyncCommand ShowAddNewCounterCommand { get; }

        async Task ShowAddNewCounter()
        {
            await navigationService.Navigate(typeof(CounterViewModel), new Counter());
        }
    }
}