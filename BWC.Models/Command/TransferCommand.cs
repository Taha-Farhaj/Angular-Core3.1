using System;
using System.Collections.Generic;
using System.Text;

namespace BWC.Models.Command
{
    public class TransferCommand
    {
        public long? BuyerId { get; set; }
        public string UserId { get; set; }
        public string BuyerOneAddress { get; set; }
        public string BuyerOneCNIC { get; set; }
        public string BuyerOneName { get; set; }
        public string BuyerOneNumber { get; set; }
        public string BuyerTwoAddress { get; set; }
        public string BuyerTwoCNIC { get; set; }
        public string BuyerTwoName { get; set; }
        public string BuyerTwoNumber { get; set; }
        public long FileId { get; set; }
        public string SellerOneAddress { get; set; }
        public string SellerOneCNIC { get; set; }
        public string SellerOneName { get; set; }
        public string SellerOneNumber { get; set; }
        public string SellerTwoAddress { get; set; }
        public string SellerTwoCNIC { get; set; }
        public string SellerTwoName { get; set; }
        public string SellerTwoNumber { get; set; }
        public int SoceityId { get; set; }
        public bool Ischecked { get; set; }
    }
}
