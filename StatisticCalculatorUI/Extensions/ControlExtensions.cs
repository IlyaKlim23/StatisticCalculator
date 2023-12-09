using StaticCalculatorUI.Enums;

namespace StaticCalculatorUI.Extensions;

public static class ControlExtensions
{
    /// <summary>
    /// Установить текст для элемента
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="text">Текст</param>
    /// <returns>Элемент</returns>
    public static Control SetText(this Control control, string text)
    {
        control.Text = text;
        
        return control;
    }
    
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
    /// Установить позицию элемента по X
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="x">Расположение по X</param>
    /// <returns>Элемент</returns>
    public static Control SetPositionX(this Control control, int x)
    {
        control.Location = control.Location with { X = x };
        
        return control;
    }
    
    /// <summary>
    /// Установить позицию элемента по Y
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="y">Расположение по Y</param>
    /// <returns>Элемент</returns>
    public static Control SetPositionY(this Control control, int y)
    {
        control.Location = control.Location with { Y = y };

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
    /// Переместить элемент в угол
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="mainControl">Главный элемент</param>
    /// <param name="nestle">Угол</param>
    /// <returns>Элемент</returns>
    public static Control ToNestle(this Control control, Control mainControl, Nestles nestle)
    {
        int x = GetNestleX(control, mainControl, nestle);
        int y = GetNestleY(control, mainControl, nestle);
        
        control.Location = new Point(x, y);

        return control;
    }

    /// <summary>
    /// Центрировать элемент
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
    
    /// <summary>
    /// Центрировать элемент по вертикали
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="mainControl">Главный элемент</param>
    /// <returns>Элемент</returns>
    public static Control ToCenterVertical(this Control control, Control mainControl)
    {
        int y = (mainControl.ClientSize.Height - control.Height) / 2;

        control.Location = control.Location with { Y = y };

        return control;
    }
    
    /// <summary>
    /// Центрировать элемент по горизонтали
    /// </summary>
    /// <param name="control">Элемент</param>
    /// <param name="mainControl">Главный элемент</param>
    /// <returns>Элемент</returns>
    public static Control ToCenterHorizontal(this Control control, Control mainControl)
    {
        int x = (mainControl.ClientSize.Width - control.Width) / 2;

        control.Location = control.Location with { X = x };

        return control;
    }
    
    private static int GetNestleX(Control control, Control mainControl, Nestles nestle)
    {
        return nestle switch
        {
            Nestles.TopRight => mainControl.Width - control.Width,
            Nestles.DownRight => mainControl.Width - control.Width,
            Nestles.TopLeft => 0,
            Nestles.DownLeft => 0,
            _ => throw new ArgumentOutOfRangeException(nameof(nestle), nestle, null)
        };
    }
    
    private static int GetNestleY(Control control, Control mainControl, Nestles nestle)
    {
        return nestle switch
        {
            Nestles.TopRight => 15,
            Nestles.TopLeft => 15,
            Nestles.DownRight => mainControl.Height - control.Height,
            Nestles.DownLeft => mainControl.Height - control.Height,
            _ => throw new ArgumentOutOfRangeException(nameof(nestle), nestle, null)
        };
    }
}