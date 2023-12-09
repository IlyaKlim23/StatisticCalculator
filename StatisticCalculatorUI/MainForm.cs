using StaticCalculatorUI.Extensions;
using StaticCalculatorUI.Settings;

namespace StaticCalculatorUI;

public partial class MainForm : Form
{
    private readonly FormConfigurator _configurator;
    
    public MainForm()
    {
        _configurator = new FormConfigurator(this);
        
        Load += FormLoad;
        Load += LoadComponents;
        InitializeComponent();
    }
    
    private void FormLoad(object sender, EventArgs e)
    {
        _configurator.SetFormSize(1900, 1200);
    }

    private void LoadComponents(object sender, EventArgs e)
    {
        var groupBox = new GroupBox();
        groupBox
            .SetSize(1300, 700)
            .ToCenter(this);

        var button1 = new Button();
        button1
            .SetSize(600, 300)
            .ToCenter(groupBox);
        
        groupBox.Controls.Add(button1);
        
        button1.Text = "Закрыть";
        button1.Click += button1_Click;
        
        //_configurator.CenterElement(groupBox);
        Controls.Add(groupBox);
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}