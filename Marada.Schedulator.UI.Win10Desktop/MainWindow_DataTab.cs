using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

using Marada.Schedulator.Core;
using Marada.Schedulator.DataAccess;

namespace Marada.Schedulator.UI.Win10Desktop
{
	public partial class MainWindow: Window
	{
		#region Fields
		private ObservableCollection<Station> stations;
		StationDataRepository stationRepo;
		#endregion


		#region Properties
		protected List<string> DataSelectionList
		{
			get
			{
				return new List<string> { "Stationer", "Linjer", "Rullende materiel" };
			}
		}

		public ObservableCollection<Station> Stations
		{
			get
			{
				return stations;
			}

			set
			{
				stations = value;
			}
		}


		#endregion

		#region Event Handlers
		private void TabData_Loaded(object sender, RoutedEventArgs e)
		{

		}
		#endregion
	}
}
