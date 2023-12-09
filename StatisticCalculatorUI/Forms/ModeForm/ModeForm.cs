using StaticCalculatorUI.Settings;

namespace StaticCalculatorUI.Forms.ModeForm;

public partial class ModeForm : Form
{
    private readonly FormConfigurator _configurator;
    private ModeFormComponents _components;
    
    public ModeForm()
    {
        Load += FormLoad;
        Load += LoadComponents;
        
        _configurator = new FormConfigurator(this);
        
        InitializeComponent();
    }
    
    private void FormLoad(object sender, EventArgs e)
    {
        _configurator.SetFormSize(1900, 1200);
        _components = new ModeFormComponents(this);
    }

    private void LoadComponents(object sender, EventArgs e)
    {
        _components.LoadComponents();
    }
}