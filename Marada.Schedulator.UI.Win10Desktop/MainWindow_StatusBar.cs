using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;	// Brushes

namespace Marada.Schedulator.UI.Win10Desktop
{
	public partial class MainWindow: Window
	{

		List<string> statusBarErrors = new List<string>();
		bool errorIndicatedInStatusBar = false;

		
		/// <summary>
		/// Turns the status bar red and displays the error message. If the status bar already
		/// indicates an error, then the new error message will also be displayed.
		/// </summary>
		/// <param name="errorMessage">The error message to display. If this parameter contains 
		/// null, String.Empty or white space characters only, a default error message is shown.
		/// </param>
		protected virtual void IndicateErrorInStatusbar(string errorMessage)
		{
			if(String.IsNullOrWhiteSpace(errorMessage))
			{
				statusBarErrors.Add("Fejl");
			}
			else
			{
				statusBarErrors.Add(errorMessage);
			}
			if(!statusBarErrors.Contains(errorMessage))
			{
				textStatusBar.Text = String.Empty;
				for(int i = 0; i < statusBarErrors.Count; i++)
				{
					if(i == 0)
					{
						textStatusBar.Text = statusBarErrors[0];
					}
					else
					{
						textStatusBar.Text += $"  |  {statusBarErrors[i]}";
					}
				}
			}
			statusBar.Background = Brushes.Red;
			errorIndicatedInStatusBar = true;
		}

		/// <summary>
		/// Clears any errors in the status bar and returns the color to default, and displays
		/// an optional message.
		/// </summary>
		/// <param name="message">The optional message to display.</param>
		protected virtual void ClearErrorInStatusBar(string message = "")
		{
			statusBarErrors.Clear();
			statusBar.Background = Brushes.RoyalBlue;
			textStatusBar.Text = !String.IsNullOrWhiteSpace(message) ? message : String.Empty;
		}

		protected virtual void IndicateErrorFor(TextBox textbox)
		{
			if(textbox != null)
			{
				textbox.BorderBrush = Brushes.Red;
			}
		}

		protected virtual void ClearErrorIndicationFor(TextBox textbox)
		{
			textbox.ClearValue(TextBox.BorderBrushProperty);
		}
		
	}
}
