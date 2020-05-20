using System;
using Countr.Core.Repositories;
using Countr.Core.Services;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;

namespace Countr.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            Console.WriteLine("Tatiana: START");
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();



            //Mvx.RegisterSingleton<ICountersService>(() => new CountersService(Mvx.Resolve<ICountersRepository>(), Mvx.Resolve<IMvxMessenger>()));

            Console.WriteLine("Tatiana: after Create Service");
            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Console.WriteLine("Tatiana: after Create Repository");
            RegisterNavigationServiceAppStart<ViewModels.CountersViewModel>();
            Console.WriteLine("Tatiana: after RegisterNavigationService");
        }
    }
}
