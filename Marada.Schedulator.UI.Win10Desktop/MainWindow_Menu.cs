using System.ComponentModel;    // CancelEventArgs
using System.Windows;

namespace Marada.Schedulator.UI.Win10Desktop
{
	public partial class MainWindow: Window
	{


		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_File_Close_Click(object sender, RoutedEventArgs e)
		{
			MainWindow_Closing(this, new CancelEventArgs(true));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MenuItem_Help_About_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(
				$"Schedulator version {version}",
				"Om Schedulator",
				MessageBoxButton.OK
				);
		}
	}
}
