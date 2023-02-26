namespace WpfLearn;

public class DataClassForExample
{
    public string Name { get; private set; }
    public string Text { get; private set; }
    public int Key { get; private set; }

    public DataClassForExample(string name, string text, int key)
    {
        Name = name;
        Text = text;
        Key = key;
    }

    public override string ToString()
    {
        return Key + " " + Name + " " + Text;
    }
}