using AgileApp;
using AgileApp.Helpers;
using AgileApp.ViewModels;
using AgileApp.Views;
using System.Windows;

namespace AgileApp
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			IDialogService dialogService = new DialogService(MainWindow);

			dialogService.Register<AddWindowViewModel, AddWindow>();

			var viewModel = new MainWindowViewModel(dialogService);
			var view = new MainWindow { DataContext = viewModel };

			view.ShowDialog();
		}
	}
}
