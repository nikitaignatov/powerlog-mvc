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
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using PowerLog.Parser;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lolobox.Text = "bacon 10x12x20 2x10";
            ParseValue();
        }

        private void TextBox_KeyUp_1(object sender, KeyEventArgs e)
        {
            ParseValue();
        }

        private void ParseValue()
        {
            baconTV.ItemsSource = new[]
            {
                // meget vigtigt detalje 
                // at man smider roden i ienumerable
                PowerLogParser.Convert(lolobox.Text)
            };

            try
            {
                PowerLogParser.ParseInput(lolobox.Text).ToList().ForEach(x => syso.Text += x.ToString());
            }
            catch (Exception ex)
            {
                syso.Text = ex.Message;
            }
        }

        private static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                var node = ((CommonTree)treeViewItem.DataContext);
                var position = node.CharPositionInLine;
                lolobox.SelectionStart = position;
                lolobox.SelectionLength = node.Text.Length;
                lolobox.Select(position, node.Text.Length);
                lolobox.Focus();
            }
        }
    }
}
