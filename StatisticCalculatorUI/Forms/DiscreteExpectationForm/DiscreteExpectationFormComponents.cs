using StaticCalculatorUI.Enums;
using StaticCalculatorUI.Extensions;

namespace StaticCalculatorUI.Forms.DiscreteExpectationForm;

class DiscreteExpectationFormComponents
{
    private readonly DiscreteExpectationForm _form;
    
    private readonly GroupBox _leftGroupBox = new ();
    private readonly GroupBox _rightGroupBox = new();
    private readonly Button _addNumBoxButton = new ();
    private readonly Button _getAnswerButton = new ();
    private readonly Label _answer = new();

    private readonly GroupBox _radioButtonsBox = new();
    private readonly RadioButton _discreteExpectationRadioButton = new();
    private readonly RadioButton _varianceRadioButton = new();

    private readonly Dictionary<NumericUpDown, NumericUpDown> _numBoxes = new ();
    
    private Point _currentLeftNumBoxPosition;
    
    public DiscreteExpectationFormComponents(DiscreteExpectationForm form)
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
        
        CreateNumericBoxes(null, null);
        
        _addNumBoxButton
            .SetSize(50, 50)
            .SetText("+")
            .SetPositionX(_currentLeftNumBoxPosition.X + 630)
            .SetPositionY(_currentLeftNumBoxPosition.Y - 5);

        _getAnswerButton
            .SetSize(300, 150)
            .ToCenterHorizontal(_rightGroupBox)
            .SetPositionY(100)
            .SetText("Get Answer");

        _answer
            .SetSize(900, 150)
            .ToCenterHorizontal(_rightGroupBox)
            .SetPositionY(600);
        _answer.Font = new Font(_answer.Font.Name, 20, _answer.Font.Style);

        _discreteExpectationRadioButton
            .SetSize(300, 100)
            .SetText("Discrete Expectation")
            .ToCenterHorizontal(_radioButtonsBox)
            .ToNestle(_radioButtonsBox, Nestles.TopLeft);
        _discreteExpectationRadioButton.Checked = true;
        
        _varianceRadioButton
            .SetSize(300, 100)
            .SetText("Variance")
            .ToCenterHorizontal(_radioButtonsBox)
            .ToNestle(_radioButtonsBox, Nestles.DownLeft);
        
        _radioButtonsBox.Controls.Add(_discreteExpectationRadioButton);
        _radioButtonsBox.Controls.Add(_varianceRadioButton);
        
        _leftGroupBox.Controls.Add(_addNumBoxButton);
        
        _rightGroupBox.Controls.Add(_getAnswerButton);
        _rightGroupBox.Controls.Add(_answer);
        _rightGroupBox.Controls.Add(_radioButtonsBox);
    }
    
    private void ConfigureButtons()
    {
        _addNumBoxButton.Click += CreateNumericBoxes;
        _getAnswerButton.Click += GetAnswer;
    }

    private void CreateNumericBoxes(object? sender, EventArgs? e)
    {
        if (_currentLeftNumBoxPosition.Y + 200 > _leftGroupBox.Height)
            return;
        
        var leftNumBox = new NumericUpDown();
        leftNumBox
            .SetSize(300, 300)
            .SetPositionX(100)
            .SetPositionY(_currentLeftNumBoxPosition.Y + 50);
        
        _currentLeftNumBoxPosition = leftNumBox.Location;
        
        leftNumBox.Minimum = 0;
        leftNumBox.Maximum = 10000000000;
        
        var rightNumBox = new NumericUpDown();
        rightNumBox
            .SetSize(300, 300)
            .SetPositionX(_currentLeftNumBoxPosition.X + 320)
            .SetPositionY(_currentLeftNumBoxPosition.Y);
        
        rightNumBox.Minimum = 0;
        rightNumBox.Maximum = 1;
        rightNumBox.DecimalPlaces = 2;
        
        _leftGroupBox.Controls.Add(leftNumBox);
        _leftGroupBox.Controls.Add(rightNumBox);
        _numBoxes[leftNumBox] = rightNumBox;
        
        ConfigureCreateNumBoxButton();
    }

    private void ConfigureCreateNumBoxButton()
    {
        _addNumBoxButton
            .SetPositionX(_currentLeftNumBoxPosition.X + 630)
            .SetPositionY(_currentLeftNumBoxPosition.Y - 5);
    }

    private void GetAnswer(object? sender, EventArgs? e)
    {
        var numbers = _numBoxes
            .ToDictionary(
                x => (double)x.Key.Value,
                x => (double)x.Value.Value);

        var result = _discreteExpectationRadioButton.Checked 
            ? StatisticCalculator.StatisticCalculator.CalculateDiscreteExpectation(numbers)
            : StatisticCalculator.StatisticCalculator.CalculateVariance(numbers);

        _answer.SetText($"Ответ: {result.Data}");
    }
}