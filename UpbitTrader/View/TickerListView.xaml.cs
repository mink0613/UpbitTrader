using System.Windows;
using UpbitTrader.ViewModel;

namespace UpbitTrader.View
{
    /// <summary>
    /// TickerListView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TickerListView : Window
    {
        public TickerListViewModel ViewModel
        {
            get
            {
                return DataContext as TickerListViewModel;
            }
        }

        public TickerListView()
        {
            InitializeComponent();
        }
    }
}
