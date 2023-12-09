namespace StaticCalculatorUI.Extensions;

public static class ControlExtensions
{
    /// <summary>
    /// Установить позицию элемента
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="x">Расположение по X</param>
    /// <param name="y">Расположение по Y</param>
    /// <returns>Элемент</returns>
    public static Control SetPosition(this Control control, int x, int y)
    {
        control.Location = new Point()
        {
            X = x,
            Y = y
        };

        return control;
    }
    
    /// <summary>
    /// Установить размер элемента
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="width">Ширина</param>
    /// <param name="height">Высота</param>
    /// <returns>Элемент</returns>
    public static Control SetSize(this Control control, int width, int height)
    {
        control.Size = new Size
        {
            Width = width,
            Height = height
        };

        return control;
    }
    
    /// <summary>
    /// Центрировать элемент относительно формы
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="form">Главный элемент</param>
    /// <returns>Элемент</returns>
    public static Control ToCenter(this Control control, Form form)
    {
        int x = (form.ClientSize.Width - control.Width) / 2;
        int y = (form.ClientSize.Height - control.Height) / 2;

        control.Location = new Point(x, y);

        return control;
    }
    
    /// <summary>
    /// Центрировать элемент относительно другого элемента
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="mainControl">Главный элемент</param>
    /// <returns>Элемент</returns>
    public static Control ToCenter(this Control control, Control mainControl)
    {
        int x = (mainControl.ClientSize.Width - control.Width) / 2;
        int y = (mainControl.ClientSize.Height - control.Height) / 2;

        control.Location = new Point(x, y);

        return control;
    }
}