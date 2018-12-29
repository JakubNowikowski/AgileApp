using System.Windows;
using System.Windows.Input;
using AgileApp.ViewModels;

namespace AgileApp.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new MainWindowViewModel(stkpnlProductOwner, stkpnlProjectManager,stkpnlScrumMaster,stkpnlArchitect,stkpnlDevTeam);

		}

		private void OnCloseExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			this.Close();
		}
	}
}
