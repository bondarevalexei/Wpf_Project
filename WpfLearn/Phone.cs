using System.Windows;

namespace WpfLearn;

// Dependency -> 
// Validation -> 
// 1. ValidateValue -> if true ->
// 2. CorrectValue.

public class Phone : DependencyObject
{
    public static readonly DependencyProperty TitleProperty;
    public static readonly DependencyProperty PriceProperty;

    static Phone()
    {
        TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));

        var metadata = new FrameworkPropertyMetadata
        {
            CoerceValueCallback = CorrectValue
        };

        PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata, ValidateValue);
    }

    private static object CorrectValue(DependencyObject d, object baseValue)
    {
        var currentValue = (int)baseValue;
        return currentValue > 1000 ? 1000 : currentValue;
    }

    private static bool ValidateValue(object value)
    {
        var currentValue = (int)value;
        return currentValue >= 0;
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public int Price
    {
        get => (int)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }
}