using System.Windows;
namespace AgileApp.Helpers
{

	public interface IDialog
	{
		object DataContext { get; set; }
		bool? DialogResult { get; set; }
		Window Owner { get; set; }
		void Close();
		bool? ShowDialog();
	}
}