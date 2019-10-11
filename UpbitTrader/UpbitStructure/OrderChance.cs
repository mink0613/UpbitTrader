namespace UpbitTrader.UpbitStructure
{
    public class OrderChance
    {
        public double bid_fee { get; set; } // 매수 수수료 비율

        public double ask_fee { get; set; } // 매도 수수료 비율

        public Market market { get; set; } // 마켓에 대한 정보
    }
}
