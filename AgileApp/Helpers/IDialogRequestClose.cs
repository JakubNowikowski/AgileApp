using System;
namespace AgileApp.Helpers
{

	public interface IDialogRequestClose
	{
		event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
	}
}