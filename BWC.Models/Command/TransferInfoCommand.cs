using System;
using System.Collections.Generic;
using System.Text;

namespace BWC.Models.Command
{
    public class TransferInfoCommand
    {
        public string FileName { get; set; }
        public string SellerName { get; set; }
        public string SellerOneName { get; set; }
        public string SellerOneCNIC { get; set; }
        public string SellerOneNumber { get; set; }
        public string SellerOneAddress { get; set; }
        public string BuyerName { get; set; }
        public string BuyerOneName { get; set; }
        public string BuyerOneCNIC { get; set; }
        public string BuyerOneNumber { get; set; }
        public string BuyerOneAddress { get; set; }
        public string SellerImage { get; set; }
        public string TransferSellerImage { get; set; }
        public string BuyerImage { get; set; }
        public string TransferBuyerImage { get; set; }
        public string SellerThumbImage { get; set; }
        public string BuyerThumbImage { get; set; }

    }
}
