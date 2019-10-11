namespace UpbitTrader.UpbitStructure
{
    public class Limit
    {
        public string currency { get; set; } // 화폐를 의미하는 영문 대문자 코드

        public string price_unit { get; set; } // 주문금액 단위

        public double min_total { get; set; } // 최소 매도/매수 금액
    }
}
