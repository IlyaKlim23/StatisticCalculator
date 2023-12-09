using StaticCalculatorUI.Enums;
using StaticCalculatorUI.Extensions;

namespace StaticCalculatorUI.Forms.ModeForm;

class ModeFormComponents
{
    private readonly ModeForm _form;
    
    private readonly GroupBox _leftGroupBox = new ();
    private readonly GroupBox _rightGroupBox = new();
    private readonly Button _addNumBoxButton = new ();
    private readonly Button _getAnswerButton = new ();
    private readonly Label _answer = new();

    private readonly GroupBox _radioButtonsBox = new();
    private readonly RadioButton _modeRadioButton = new();
    private readonly RadioButton _medianRadioButton = new();

    private readonly List<NumericUpDown> _numBoxes = new ();
    
    private Point _currentNumBoxPosition;

    
    public ModeFormComponents(ModeForm form)
    {
        _form = form;
        ConfigureComponents();
        ConfigureButtons();
    }

    /// <summary>
    /// Загрузить компоненты на форму
    /// </summary>
    public void LoadComponents()
    {
        _form.Controls.Add(_leftGroupBox);
        _form.Controls.Add(_rightGroupBox);
    }

    private void ConfigureComponents()
    {
        _leftGroupBox
            .SetSize(900, 1200)
            .ToNestle(_form, Nestles.TopLeft);
        
        _rightGroupBox
            .SetSize(900, 1200)
            .ToNestle(_form, Nestles.TopRight);

        _radioButtonsBox
            .SetSize(150, 200)
            .ToCenterHorizontal(_rightGroupBox)
            .SetPositionY(300);
        
        CreateNumericBox(null, null);
        
        _addNumBoxButton
            .SetSize(50, 50)
            .SetText("+")
            .SetPositionX(_currentNumBoxPosition.X + 420)
            .SetPositionY(_currentNumBoxPosition.Y - 5);

        _getAnswerButton
            .SetSize(300, 150)
            .ToCenterHorizontal(_rightGroupBox)
            .SetPositionY(100)
            .SetText("Get Answer");

        _answer
            .SetSize(300, 150)
            .ToCenterHorizontal(_rightGroupBox)
            .SetPositionY(600);
        _answer.Font = new Font(_answer.Font.Name, 20, _answer.Font.Style);

        _modeRadioButton
            .SetSize(300, 100)
            .SetText("Mode")
            .ToCenterHorizontal(_radioButtonsBox)
            .ToNestle(_radioButtonsBox, Nestles.TopLeft);
        _modeRadioButton.Checked = true;
        
        _medianRadioButton
            .SetSize(300, 100)
            .SetText("Median")
            .ToCenterHorizontal(_radioButtonsBox)
            .ToNestle(_radioButtonsBox, Nestles.DownLeft);
        
        _radioButtonsBox.Controls.Add(_modeRadioButton);
        _radioButtonsBox.Controls.Add(_medianRadioButton);
        
        _leftGroupBox.Controls.Add(_addNumBoxButton);
        
        _rightGroupBox.Controls.Add(_getAnswerButton);
        _rightGroupBox.Controls.Add(_answer);
        _rightGroupBox.Controls.Add(_radioButtonsBox);
    }
    
    private void ConfigureButtons()
    {
        _addNumBoxButton.Click += CreateNumericBox;
        _getAnswerButton.Click += GetAnswer;
    }

    private void CreateNumericBox(object? sender, EventArgs? e)
    {
        if (_currentNumBoxPosition.Y + 200 > _leftGroupBox.Height)
            return;
        
        var numBox = new NumericUpDown();
        numBox
            .SetSize(400, 300)
            .ToCenterHorizontal(_leftGroupBox)
            .SetPositionY(_currentNumBoxPosition.Y + 50);
        
        numBox.Minimum = 0;
        numBox.Maximum = 1000000000;

        _currentNumBoxPosition = numBox.Location;
        
        _leftGroupBox.Controls.Add(numBox);
        _numBoxes.Add(numBox);
        
        ConfigureCreateNumBoxButton();
    }

    private void ConfigureCreateNumBoxButton()
    {
        _addNumBoxButton
            .SetPositionX(_currentNumBoxPosition.X + 420)
            .SetPositionY(_currentNumBoxPosition.Y - 5);
    }

    private void GetAnswer(object? sender, EventArgs? e)
    {
        var numbers = _numBoxes
            .Select(x => (double)x.Value)
            .ToList();

        var result = _modeRadioButton.Checked 
            ? StatisticCalculator.StatisticCalculator.CalculateMode(numbers)
            : StatisticCalculator.StatisticCalculator.CalculateMedian(numbers);

        _answer.SetText($"Ответ: {result.Data}");
    }
}