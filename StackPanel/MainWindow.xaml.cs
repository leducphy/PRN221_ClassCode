using StackPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StackPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly StackPanelContext _context;
        public MainWindow( StackPanelContext context)
        {
            InitializeComponent();
            _context = context;
            Load();
        }

        public void Load()
        {
            if (_context != null)
            {
                DGVStackPanel.ItemsSource = _context.StackPanels.ToList();
            }
        }

        

    }
}
