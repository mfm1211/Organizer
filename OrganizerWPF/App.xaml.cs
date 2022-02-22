using Microsoft.Extensions.DependencyInjection;
using Organizer.EntityFramework;
using Organizer.EntityFramework.Services;
using OrganizerLibrary.Models;
using OrganizerLibrary.Services;
using OrganizerWPF.State.ItemListStates;
using OrganizerWPF.State.Navigators;
using OrganizerWPF.ViewModels;
using OrganizerWPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OrganizerWPF
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    public partial class App : Application
    {
        public static Skin Skin { get; set; } = Skin.Dark;
        protected override async void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            IDataService<ListModel> listmodelService = serviceProvider.GetRequiredService<IDataService<ListModel>>();

            ListModel temp = await listmodelService.Get(1);
            MainWindow = serviceProvider.GetRequiredService<MainWindow>();

            MainWindow.Show();


            RetractableWindow retractableWindow = serviceProvider.GetRequiredService<RetractableWindow>();

            if (System.Windows.SystemParameters.WorkArea.Width - (MainWindow.Left + MainWindow.Width) > retractableWindow.Width)
            {
                retractableWindow.Left = MainWindow.Left + MainWindow.Width + 5;
            }
            else
            {
                retractableWindow.Left = MainWindow.Left - (retractableWindow.Width + 5);
            }
            retractableWindow.Top = MainWindow.Top;
            retractableWindow.Owner = MainWindow;

            retractableWindow.Show();

            base.OnStartup(e);
        }


        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<OrganizerDbContextFactory>();

            services.AddSingleton<IDataService<ListModel>, ListsDataServices>();

            services.AddSingleton<IDataService<EventModel>, GenericDataService<EventModel>>();

            services.AddSingleton<INavigator, Navigator>();

            services.AddSingleton<IChosenIndexesStore, ChosenIndexesStore>();

            services.AddSingleton<IOrganizerViewModelFactory, OrganizerViewModelFactory>();


            services.AddScoped<MainViewModel>();
            services.AddScoped<RetractableMainViewModel>();

            services.AddSingleton<SelectionBarViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            services.AddScoped<RetractableWindow>(s => new RetractableWindow(s.GetRequiredService<RetractableMainViewModel>()));





            services.AddSingleton<CreateViewModel<ListOfListsViewModel>>(services =>
            {
                return () => new ListOfListsViewModel(services.GetRequiredService<IDataService<ListModel>>(), 
                    services.GetRequiredService<INavigator>());
            });

            services.AddSingleton<CreateViewModel<EventListViewModel>>(services =>
            {
                return () => new EventListViewModel(services.GetRequiredService<IDataService<EventModel>>(), 
                    services.GetRequiredService<INavigator>());
            });
            services.AddSingleton<CreateViewModel<SelectionBarViewModel>>(services =>
            {
                return () => services.GetRequiredService<SelectionBarViewModel>();
            });
            services.AddSingleton<CreateViewModel<RetractableEventListViewModel>>(services =>
            {
                return () => new RetractableEventListViewModel(services.GetRequiredService<IDataService<EventModel>>(),
                    services.GetRequiredService<IDataService<ListModel>>(),
                    services.GetRequiredService<INavigator>(),
                    services.GetRequiredService<IChosenIndexesStore>());
            });

            return services.BuildServiceProvider();


        }

      
    }
}
