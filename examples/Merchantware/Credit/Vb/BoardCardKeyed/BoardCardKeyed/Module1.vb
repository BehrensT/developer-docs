Imports BoardCardKeyed.MWCredit

Module Module1

    Sub Main()
        'Create Soap Client
        Dim MWCredit As New CreditSoapClient

        'Create Credentials Object
        Dim Credentials As New MerchantCredentials With {
        .MerchantName = "TEST MERCHANT",
        .MerchantSiteId = "XXXXXXXX",
        .MerchantKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
        }

        'Create PaymentData Object
        Dim PaymentData As New PaymentData With {
        .Source = "KEYED",
        .CardNumber = "4012000033330026",
        .ExpirationDate = "1221",
        .CardHolder = "John Doe",
        .AvsStreetAddress = "1 Federal St",
        .AvsZipCode = "02110",
        .CardVerificationValue = "123"
        }

        'Create Request Object
        Dim BoardingRequest As New BoardingRequest

        'Process Request
        Dim BoardingResponse As VaultBoardingResponse45
        BoardingResponse = MWCredit.BoardCard(Credentials, PaymentData, BoardingRequest)

        'Display Results
        Console.WriteLine(" Vault Token: {0} Error Code: {1} Error Message: {2} RFMIQ: {3}", BoardingResponse.VaultToken + vbNewLine, BoardingResponse.ErrorCode + vbNewLine, BoardingResponse.ErrorMessage + vbNewLine, BoardingResponse.Rfmiq + vbNewLine)
        Console.WriteLine("Press Any Key to Close")
        Console.ReadKey()
    End Sub

End Module
