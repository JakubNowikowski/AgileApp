using System;
namespace AgileApp.Helpers
{

	public class DialogCloseRequestedEventArgs : EventArgs
	{
		public DialogCloseRequestedEventArgs(bool? dialogResult)
		{
			DialogResult = dialogResult;
		}

		public bool? DialogResult { get; }
	}
}