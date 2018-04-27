Imports RemovePoints.MWGift45
Module Module1
    Sub Main()
        'Create Soap Client
        Dim giftSoapClient As New GiftcardSoapClient
        'Create Credentials Object
        Dim merchantCredentials As New MerchantCredentials With {
            .MerchantName = "TEST MERCHANT",
            .MerchantSiteId = "XXXXXXXX",
            .MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
        }
        'Create PaymentData Object
        Dim giftPaymentData As New GiftPaymentData With {
            .Source = "PREVIOUSTRANSACTION",
            .Token = "1234567890"
        }
        'Create Request Object
        Dim removePointsRequest As New RemovePointsRequest With {
            .Amount = "10.00",
            .AmountType = "POINTS",
            .InvoiceNumber = "INV1234",
            .MerchantTransactionId = "TRAN1234"
        }
        'Process Request
        Dim giftResponse45 As GiftResponse45
        giftResponse45 = giftSoapClient.RemovePoints(merchantCredentials, giftPaymentData, removePointsRequest)
        'Display Results
        Console.WriteLine(" Approval Status: {0} Response Message: {1} Points Balance: {2}", giftResponse45.ApprovalStatus + vbNewLine, giftResponse45.ResponseMessage + vbNewLine, giftResponse45.Loyalty.PointsBalance + vbNewLine)
        Console.WriteLine("Press Any Key to Close")
        Console.ReadKey()
    End Sub
End Module