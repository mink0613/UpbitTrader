namespace UpbitTrader.UpbitStructure
{
    public class Ticker
    {
        public string market { get; set; } // 종목 구분 코드

        public string trade_date { get; set; } // 최근 거래 일자(UTC)

        public string trade_time { get; set; } // 최근 거래 시각(UTC)

        public string trade_date_kst { get; set; } // 최근 거래 일자(KST)

        public string trade_time_kst { get; set; } // 최근 거래 시각(KST)

        public double opening_price { get; set; } // 시가

        public double high_price { get; set; } // 고가

        public double low_price { get; set; } // 저가

        public double trade_price { get; set; } // 종가

        public double prev_closing_price { get; set; } // 전일 종가

        public string change { get; set; } // EVEN : 보합, RISE : 상승, FALL : 하락

        public double change_price { get; set; } // 변화액의 절대값

        public double change_rate { get; set; } // 변화율의 절대값

        public double signed_change_price { get; set; } // 부호가 있는 변화액

        public double signed_change_rate { get; set; } // 부호가 있는 변화율

        public double trade_volume { get; set; } // 가장 최근 거래량

        public double acc_trade_price { get; set; } // 누적 거래대금(UTC 0시 기준)

        public double acc_trade_price_24h { get; set; } // 24시간 누적 거래대금

        public double acc_trade_volume { get; set; } // 누적 거래량(UTC 0시 기준)

        public double acc_trade_volume_24h { get; set; } // 24시간 누적 거래대금

        public double highest_52_week_price { get; set; } // 52주 신고가

        public string highest_52_week_date { get; set; } // 52주 신고가 달성일

        public double lowest_52_week_price { get; set; } // 52주 신저가

        public string lowest_52_week_date { get; set; } // 52주 신저가 달성일

        public long timestamp { get; set; } // 타임스탬프
    }
}
