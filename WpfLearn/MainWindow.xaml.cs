using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfLearn;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();

        List<DataClassForExample> list = new()
        {
            new DataClassForExample("item1", "item1d", 0),
            new DataClassForExample("item2", "item2d", 1),
            new DataClassForExample("item3", "item3d", 2)
        };

        DataGrid.ItemsSource = list;
        EraserButton.Click += ShowEraserMessage;
    }

    private void MinimizeButtonClick(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow!.WindowState = WindowState.Minimized;
    }

    private void MaximizedOrNormalButtonClick(object sender, RoutedEventArgs e)
    {
        Application.Current.MainWindow!.WindowState = Application.Current.MainWindow.WindowState == WindowState.Normal
            ? WindowState.Maximized
            : WindowState.Normal;
    }

    private void ShutdownButtonClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState == MouseButtonState.Pressed)
            DragMove();
    }

    private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        ((Slider)sender).SelectionEnd = e.NewValue;
        ProgressBar.Value = e.NewValue;
    }

    private void Calendar_OnSelectedDatesChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedDate = Calendar.SelectedDate;
        DatePicker.SelectedDate = selectedDate;
    }

    private void EraserButtonClick(object sender, RoutedEventArgs e)
    {
        InkCanvas.EditingMode = InkCanvas.EditingMode == InkCanvasEditingMode.Ink
            ? InkCanvasEditingMode.EraseByPoint
            : InkCanvasEditingMode.Ink;
    }

    private void ShowEraserMessage(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(InkCanvas.EditingMode == InkCanvasEditingMode.EraseByPoint 
            ? "Switch to eraser!" 
            : "Switch to Ink!");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var phone = (Phone)Resources["Phone"];
        MessageBox.Show(phone.Price.ToString());
    }

    private void TextBoxPrevTInput(object sender, TextCompositionEventArgs e)
    {
        if (!int.TryParse(e.Text, out var value) && e.Text != "-")
            e.Handled = true;
        else
            OutputBlock.Text += value.ToString();
    }

    private void TextBoxPrevKDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Space)
            e.Handled = true;
    }

    private void MouseEvTextBox_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        DragDrop.DoDragDrop(MouseEvTextBox, MouseEvTextBox.Text, DragDropEffects.Copy);
    }

    private void MouseEvButton_OnDrop(object sender, DragEventArgs e)
    {
        MouseEvButton.Content = e.Data.GetData(DataFormats.Text);
    }

    private void MouseEvTextBox_OnGotFocus(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Focus!");
    }

    private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
    {
        using (var sw = new StreamWriter("log.txt", true))
        {
            sw.WriteLine("Exit. Time: " + DateTime.Now.ToShortDateString() + ". Time: " + DateTime.Now.ToLongTimeString());
        }
        
        Close();
    }
}