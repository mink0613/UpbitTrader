using System.Collections.Generic;

namespace UpbitTrader.UpbitStructure
{
    public class Market
    {
        public string id { get; set; } // 마켓의 유일 키

        public string name { get; set; } // 마켓 이름

        public List<string> order_types { get; set; } // 지원 주문 방식

        public List<string> order_sides { get; set; } // 지원 주문 종류

        public double max_total { get; set; } // 최대 매도/매수 금액

        public string state { get; set; } // 마켓 운영 상태

        public Limit bid { get; set; } // 매수 시 제약사항

        public Limit ask { get; set; } // 매도 시 제약사항

        public Account bid_account { get; set; } // 매수 시 사용하는 화폐의 계좌 상태

        public Account ask_account { get; set; } // 매도 시 사용하는 화폐의 계좌 상태
    }
}
