namespace StaticCalculatorUI.Settings;

public class FormConfigurator
{
    private readonly Form _form;
    
    public FormConfigurator(Form form)
    {
        _form = form;
    }

    public void SetFormSize(int width, int height)
    {
        _form.Size = new Size()
        {
            Width = width,
            Height = height
        };
    }
}