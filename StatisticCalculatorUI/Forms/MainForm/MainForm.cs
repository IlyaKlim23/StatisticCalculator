using StaticCalculatorUI.Settings;

namespace StaticCalculatorUI.Forms.MainForm;

public sealed partial class MainForm : Form
{
    private readonly FormConfigurator _configurator;
    private MainFormComponents _components;
    
    public MainForm()
    {
        Load += FormLoad;
        Load += LoadComponents;
        
        _configurator = new FormConfigurator(this);
        
        InitializeComponent();
    }
    
    private void FormLoad(object sender, EventArgs e)
    {
        _configurator.SetFormSize(1900, 1200);
        _components = new MainFormComponents(this);
    }

    private void LoadComponents(object sender, EventArgs e)
    {
        _components.LoadComponents();
    }
}