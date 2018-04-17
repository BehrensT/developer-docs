Imports System.Xml.Serialization
Imports GeniusSale.TransportService
Module Module1

    Sub Main()
        ' Declare credentials to be used with the Stage Transaction Request 
        Dim transportSoapClient As New TransportServiceSoapClient
        Dim credentialsName = "TEST MERCHANT"
        Dim credentialsSiteId = "XXXXXXXX"
        Dim credentialsKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX"
        Dim ipAddress = "10.4.50.151"
        ' Build Transport request details
        Dim transportRequest As New TransportRequest With {
            .TransactionType = "SALE",
            .Amount = 1.01,
            .ClerkId = "1",
            .OrderNumber = "INV1234",
            .Dba = "TEST MERCHANT",
            .SoftwareName = "Test Software",
            .SoftwareVersion = "1.0",
            .TerminalId = "01",
            .PoNumber = "PO1234",
            .TaxAmount = "0.10",
            .EntryMode = EntryMode.Undefined,
            .ForceDuplicate = True
        }
        ' Stage Transaction
        Console.WriteLine("Staging Transaction{0}", Environment.NewLine)
        Dim transportResponse = transportSoapClient.CreateTransaction(credentialsName, credentialsSiteId, credentialsKey, transportRequest)
        Console.WriteLine("TransportKey Received {0}{1}", transportResponse.TransportKey, Environment.NewLine)
        ' Initiate transaction with TransportKey
        Using webClient = New Net.WebClient()
            Dim geniusResponse = webClient.OpenRead($"http://{ipAddress}:8080/v2/pos?TransportKey={transportResponse.TransportKey}&Format=XML")
            'Validate XML to Genius XSD class
            Using streamReader As New IO.StreamReader(geniusResponse)
                Dim xmlSerializer As New XmlSerializer(GetType(TransactionResult))
                Dim transactionResult As TransactionResult = xmlSerializer.Deserialize(streamReader)
                Console.WriteLine("Transaction Result: {0}", transactionResult.Status)
                Console.WriteLine("Amount: {0}", transactionResult.AmountApproved)
                Console.WriteLine("AuthCode: {0}", transactionResult.AuthorizationCode)
                Console.WriteLine("Token: {0}", transactionResult.Token)
                Console.WriteLine("AccountNumber: {0}", transactionResult.AccountNumber)
            End Using
        End Using
        Console.WriteLine("Press Any Key to Close")
        Console.ReadKey()
    End Sub

End Module
