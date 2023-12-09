using StaticCalculatorUI.Settings;

namespace StaticCalculatorUI.Forms.DiscreteExpectationForm;

public partial class DiscreteExpectationForm : Form
{
    private readonly FormConfigurator _configurator;
    private DiscreteExpectationFormComponents _components;
    
    public DiscreteExpectationForm()
    {
        Load += FormLoad;
        Load += LoadComponents;
        
        _configurator = new FormConfigurator(this);
        
        InitializeComponent();
    }
    
    private void FormLoad(object sender, EventArgs e)
    {
        _configurator.SetFormSize(1900, 1200);
        _components = new DiscreteExpectationFormComponents(this);
    }

    private void LoadComponents(object sender, EventArgs e)
    {
        _components.LoadComponents();
    }
}