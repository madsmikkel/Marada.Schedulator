using Marada.Schedulator.Core;
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
	public partial class MainWindow: Window
	{
		protected double stationEditorCanvasWidth;
		protected double stationEditorCanvasHeight;
		protected double[] stationEditorCanvasCenterXY = new double[2];
		protected readonly double defaultLineThickness = 4;

		protected virtual void DrawBaseTrack()
		{
			GetAndSetStationEditorCanvasDimensions();
			Line baseLine = new Line();
			AttachHandlersTo(baseLine);

			baseLine.Stroke = Brushes.Black;
			baseLine.StrokeThickness = 4;
			baseLine.X1 = stationEditorCanvasWidth * 0.1;
			baseLine.X2 = stationEditorCanvasWidth * 0.9;
			baseLine.Y1 = stationEditorCanvasCenterXY[1];
			baseLine.Y2 = stationEditorCanvasCenterXY[1];
			canvas_StationLayout.Children.Add(baseLine);
		}

		private void AttachHandlersTo(Shape shape)
		{
			if(shape is Line)
			{
				shape.MouseEnter += new MouseEventHandler(LineMouseEnter);
				shape.MouseLeave += new MouseEventHandler(LineMouseLeave);
				shape.MouseLeftButtonUp += new MouseButtonEventHandler(LineMouseLeftButtonUp);
				shape.MouseRightButtonUp += new MouseButtonEventHandler(LineMouseRightButtomUp);
			}
			else if(shape is Ellipse)
			{
				shape.MouseEnter += new MouseEventHandler(EllipseMouseEnter);
				shape.MouseLeave += new MouseEventHandler(EllipseMouseLeave);
				shape.MouseLeftButtonUp += new MouseButtonEventHandler(EllipseMouseLeftButtonUp);
				shape.MouseRightButtonUp += new MouseButtonEventHandler(EllipseMouseRightButtomUp);
			}
		}

		private void EllipseMouseRightButtomUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void EllipseMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{

		}

		private void EllipseMouseLeave(object sender, MouseEventArgs e)
		{
			((Ellipse)sender).Fill = Brushes.Black;
		}

		private void EllipseMouseEnter(object sender, MouseEventArgs e)
		{
			((Ellipse)sender).Fill = Brushes.Gray;
			DrawNewMaybeLine((Ellipse)sender);
		}

		private void DrawNewMaybeLine(Ellipse ellipse)
		{
			Line newLine = GetNewLine(Brushes.Gray);
			AttachHandlersTo(newLine);
			
			

		}

		private Line GetNewLine(SolidColorBrush color)
		{
			Line newLine = new Line();
			newLine.Stroke = color;
			newLine.StrokeThickness = defaultLineThickness;
			return newLine;
		}

		private void LineMouseRightButtomUp(object sender, MouseButtonEventArgs e)
		{
			Line line = sender as Line;

			// Place switch track (ellipse)
			Ellipse ellipse = new Ellipse();
			AttachHandlersTo(ellipse);
			ellipse.Width = 20;
			ellipse.Height = 20;
			ellipse.Fill = Brushes.Black;
			Point mousePoint = new Point(
				Mouse.GetPosition(canvas_StationLayout).X,
				Mouse.GetPosition(canvas_StationLayout).Y
				);
			Point snapPoint = GetEllipseSnapTpLinePosition(line, mousePoint);
			ellipse.SetValue(Canvas.LeftProperty, snapPoint.X);
			ellipse.SetValue(Canvas.TopProperty, snapPoint.Y);
			canvas_StationLayout.Children.Add(ellipse);
		}

		private Point GetEllipseSnapTpLinePosition(Line line, Point mousePoint) =>
			new Point(x: mousePoint.X - 10, y: line.Y1 - 10);



		private void LineMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			// tHE LINE WAS MARKED BY USER. dISPLAY DATA IN THE GROUP BOX.
		}

		private void LineMouseLeave(object sender, MouseEventArgs e)
		{
			((Line)sender).Stroke = Brushes.Black;
		}

		private void LineMouseEnter(object sender, MouseEventArgs e)
		{
			((Line)sender).Stroke = Brushes.Gray;
		}



		protected virtual void GetAndSetStationEditorCanvasDimensions()
		{
			stationEditorCanvasHeight = canvas_StationLayout.ActualHeight;
			stationEditorCanvasWidth = canvas_StationLayout.ActualWidth;
			stationEditorCanvasCenterXY[0] = stationEditorCanvasWidth / 2.0;
			stationEditorCanvasCenterXY[1] = stationEditorCanvasHeight / 2.0;
		}



		protected virtual void Layout(Station station)
		{

		}
	}
}