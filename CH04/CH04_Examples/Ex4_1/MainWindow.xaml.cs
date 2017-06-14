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

namespace Ex4_1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        #region イベントハンドラー

        /// <summary>
        /// ウィンドウが表示されるとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            StoreControls();
        }
        
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // UIコントロールをListコレクションに入れて管理する
        private List<Button> _buttons;
        private List<RadioButton> _radioButtons;

        private void StoreControls()
        {
            // このウィンドウが持っているすべてのButtonことロール
            _buttons = this.Descendants<Button>().ToList();

            
        }

        #endregion
    }
}
