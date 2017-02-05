using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
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
				if(stationRepo == null)
				{
					stationRepo = new StationDataRepository();
				}
				stations = new ObservableCollection<Station>(stationRepo.GetAll());
				return stations;
			}

			set
			{
				stations = value;
			}
		}


		#endregion


		#region Event Handlers
		private void DataGrid_Stations_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DrawBaseTrack();
		}

		private void TabData_Loaded(object sender, RoutedEventArgs e)
		{
			listBox_DataSelection.ItemsSource = DataSelectionList;
		}
		#endregion
	}
}
