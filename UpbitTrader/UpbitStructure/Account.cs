namespace UpbitTrader.UpbitStructure
{
    public class Account
    {
        public string currency { get; set; } // 화폐를 의미하는 영문 대문자 코드

        public double balance { get; set; } // 주문가능 금액/수량

        public double locked { get; set; } // 주문 중 묶여있는 금액/수량

        public double avg_buy_price { get; set; } // 매수평균가

        public bool avg_buy_price_modified { get; set; } // 매수평균가 수정 여부

        public string unit_currency { get; set; } // 평단가 기준 화폐
    }
}
