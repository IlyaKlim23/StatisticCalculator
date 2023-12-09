using StaticCalculatorUI.Enums;
using StaticCalculatorUI.Extensions;

namespace StaticCalculatorUI.Forms.MainForm;

class MainFormComponents
{
    private GroupBox _groupBox = new ();
    
    private readonly Button _modeButton = new ();
    private readonly Button _discreteExpectationButton = new ();

    private readonly MainForm _form;
    
    public MainFormComponents(MainForm form)
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
        _form.Controls.Add(_groupBox);
    }

    private void ConfigureComponents()
    {
        _groupBox
            .SetSize(1300, 700)
            .ToCenter(_form);

        _modeButton
            .SetSize(600, 300)
            .ToNestle(_groupBox, Nestles.TopLeft)
            .SetText("Мода ряда | Медиана ряда")
            .ToCenterVertical(_groupBox);
        
        _discreteExpectationButton
            .SetSize(600, 300)
            .ToNestle(_groupBox, Nestles.TopRight)
            .SetText("Математическое ожидание | Дисперсия")
            .ToCenterVertical(_groupBox);

        
        _groupBox.Controls.Add(_modeButton);
        _groupBox.Controls.Add(_discreteExpectationButton);
    }

    private void ConfigureButtons()
    {
        _modeButton.Click += ModeButtonClick;
        _discreteExpectationButton.Click += DiscreteExpectationButtonClick;
    }
    
    private void ModeButtonClick(object sender, EventArgs e)
    {
        ModeForm.ModeForm modeForm = new ModeForm.ModeForm();
        modeForm.Show();
    }
    
    private void DiscreteExpectationButtonClick(object sender, EventArgs e)
    {
        DiscreteExpectationForm.DiscreteExpectationForm modeForm = new DiscreteExpectationForm.DiscreteExpectationForm();
        modeForm.Show();
    }
}