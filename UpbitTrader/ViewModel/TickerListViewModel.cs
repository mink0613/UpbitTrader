using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UILibrary.Base;
using UpbitTrader.UpbitAPI;
using UpbitTrader.UpbitStructure;

namespace UpbitTrader.ViewModel
{
    public class TickerListViewModel : BaseViewModel
    {
        private ObservableCollection<Ticker> _tickerList;

        private Ticker _selectedTicker;

        public ObservableCollection<Ticker> TickerList
        {
            get
            {
                return _tickerList;
            }
            set
            {
                _tickerList = value;
                OnPropertyChanged();
            }
        }

        public Ticker SelectedTicker
        {
            get
            {
                return _selectedTicker;
            }
            set
            {
                _selectedTicker = value;
                OnPropertyChanged();
            }
        }

        private List<MarketInfo> GetMarketList()
        {
            string marketAll = HttpAPI.GetMarketAll();
            return JsonConvert.DeserializeObject<List<MarketInfo>>(marketAll);
        }

        private void UpdateTickerList()
        {
            var marketList = GetMarketList();
            List<string> markets = new List<string>();
            for (int i = 0; i < marketList.Count; i++)
            {
                if (marketList[i].market.ToUpper().Contains("KRW"))
                {
                    markets.Add(marketList[i].market);
                }
            }

            TickerList = JsonConvert.DeserializeObject<ObservableCollection<Ticker>>(HttpAPI.GetTicker(markets.ToArray()));
        }

        private void RunUpdateTickerList()
        {
            Timer timer = new Timer();
            timer.Interval = 10000; // 10 seconds
            timer.Elapsed += (s, e) =>
            {
                UpdateTickerList();
            };
            timer.Start();
        }

        public TickerListViewModel()
        {
            UpdateTickerList();
            RunUpdateTickerList();
        }
    }
}
