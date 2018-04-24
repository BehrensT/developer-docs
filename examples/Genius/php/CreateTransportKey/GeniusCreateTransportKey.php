<?php
    header("Content-Type: application/json");
    $client = new SoapClient("https://transport.merchantware.net/v4/transportservice.asmx?WSDL");
    $credentailsName = "TEST MERCHANT";
    $credentailsSiteID = "XXXXXXXX";
    $credentialsKey = "XXXXX-XXXXX-XXXXX-XXXXX-XXXXX";
    $response = $client->CreateTransaction(
        array(
            "merchantName"          => $credentailsName,
            "merchantSiteId"        => $credentailsSiteID,
            "merchantKey"           => $credentialsKey,
            "request"               => array (
                "TransactionType"   => "SALE",
                "Amount"            => "1.01",
                "ClerkId"           => "01",
                "Dba"               => "TEST MERCHANT",
                "SoftwareName"      => "Test Software",
                "SoftwareVersion"   => "1.0",
                "OrderNumber"       => "INV1234",
                "ForceDuplicate"    => "True",
                "PoNumber"          => "PO1234",
                "TaxAmount"         => "0.00",
                "TerminalId"        => "01",
                "EntryMode"         => "Undefined"
            )
        )
    );
    echo(json_encode($response->CreateTransactionResult));
?>