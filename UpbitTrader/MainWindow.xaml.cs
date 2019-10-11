using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using UpbitTrader.UpbitAPI;
using UpbitTrader.UpbitStructure;

namespace UpbitTrader
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string marketAll = HttpAPI.GetMarketAll();
            List<MarketInfo> all = JsonConvert.DeserializeObject<List<MarketInfo>>(marketAll);
            Console.WriteLine(marketAll);

            string[] markets = new string[1];
            markets[0] = "KRW-BTC";

            ObservableCollection<Ticker> tickerList = JsonConvert.DeserializeObject<ObservableCollection<Ticker>>(HttpAPI.GetTicker(markets));
            List<Account> accountList = JsonConvert.DeserializeObject<List<Account>>(HttpAPI.GetAccount());
            List<Account> accountList2 = JsonConvert.DeserializeObject<List<Account>>(HttpAPI.GetAccount());
            string data = HttpAPI.GetOrderChance(markets);
            Console.WriteLine(data);
            OrderChance orderChance = JsonConvert.DeserializeObject<OrderChance>(HttpAPI.GetOrderChance(markets));
        }
    }
}
