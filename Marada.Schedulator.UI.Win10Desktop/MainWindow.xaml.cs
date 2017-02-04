using System;
using System.Collections.Generic;
using System.ComponentModel;    // CancelEventArgs.
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marada.Schedulator.UI.Win10Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
		/// <summary>
		/// The version of the solution.
		/// </summary>
		private string version;

		public MainWindow()
		{
			try
			{

				InitializeComponent();

				version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
					.ToString();
#if DEBUG
				Title += $"     DEBUGGING version: {version}";
#endif
				
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
				Application.Current.Shutdown();
			}
		}

		/// <summary>
		/// User selection: Click on X. Offers the user the choice to close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainWindow_Closing(object sender, CancelEventArgs e)
		{
			string caption = "Luk programmet";
			string message = "Vil du afslutte Schedulator? Hvis ikke dine ændringer er gemt, går"
				+ " de tabt";
			MessageBoxResult result = MessageBox.Show(
				message,
				caption,
				MessageBoxButton.YesNo,
				MessageBoxImage.Information,
				MessageBoxResult.No,
				MessageBoxOptions.None
				);
			if(result == MessageBoxResult.Yes)
			{
				//e.Cancel = false;
				Application.Current.Shutdown();
			}
			else
			{
				e.Cancel = true;
			}
		}

		
	}
}
