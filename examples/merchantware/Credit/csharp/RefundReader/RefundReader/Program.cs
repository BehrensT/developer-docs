﻿using System;
using RefundReader.MWCredit45;

namespace RefundReader
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Create Soap Client
            CreditSoapClient soapClient = new CreditSoapClient("CreditSoap");
            // Create MerchantCredentails object
            MerchantCredentials merchantCredentials = new MerchantCredentials
            {
                MerchantName = "TEST MERCHANT",
                MerchantSiteId = "XXXXXXXX",
                MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
            };
            // Create PaymentData object
            PaymentData paymentData = new PaymentData
            {
                Source = "Reader",
                TrackData = "%B4012000033330026^TEST CARD/GENIUS^181210054321000000000000000 150 A?;4012000033330026=18121011000012345678?",
            };
            // Create RefundRequest Object
            RefundRequest refundRequest = new RefundRequest
            {
                Amount = "1.01",
                InvoiceNumber = "INV1234",
                CardAcceptorTerminalId = "01"
            };
            // Run Refund
            TransactionResponse45 transactionResponse45 = soapClient.Refund(merchantCredentials, paymentData, refundRequest);
            // Print Results
            Console.WriteLine("Refund Response: {0} Token: {1} Amount: ${2}", transactionResponse45.ApprovalStatus, transactionResponse45.Token, transactionResponse45.Amount);
            Console.WriteLine("Press Any Key to Close");
            Console.ReadKey();
        }
    }
}
