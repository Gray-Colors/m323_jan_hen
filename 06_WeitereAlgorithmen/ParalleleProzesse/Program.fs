open System.Threading

type Smartphone = { Id: int; Name: string; Price: decimal }

type Warenkorb = { Id: int; UserId: int; Items: Map<int, int> }

module Shop =

    let mutable lagerbestand = 10
    let lagerbestandMutex = new Mutex()

    let smartphones = [
        { Id = 1; Name = "Smartphone 1"; Price = 599.99m }
        { Id = 2; Name = "Smartphone 2"; Price = 699.99m }
        { Id = 3; Name = "Smartphone 3"; Price = 799.99m }
    ]

    let addToWarenkorb (warenkorb: Warenkorb) (smartphoneId: int) =
        let smartphone = smartphones |> Seq.find (fun s -> s.Id = smartphoneId)
        lagerbestandMutex.WaitOne() |> ignore
        try
            if lagerbestand > 0 then
                let newItems =
                    if warenkorb.Items.ContainsKey(smartphoneId) then
                        warenkorb.Items.Add(smartphoneId, warenkorb.Items.[smartphoneId] + 1)
                    else
                        warenkorb.Items.Add(smartphoneId, 1)
                { warenkorb with Items = newItems } |> ignore
                lagerbestand <- lagerbestand - 1
                printfn $"{smartphone.Name} wurde dem Warenkorb hinzugefügt. Noch {lagerbestand} Stück verfügbar."
            else
                printfn $"{smartphone.Name} ist leider ausverkauft."
        finally
            lagerbestandMutex.ReleaseMutex() |> ignore

    let getWarenkorb (userId: int) =
        // Dummy implementation, in a real application this would query the database
        { Id = 1; UserId = userId; Items = Map.empty }

    let checkout (warenkorb: Warenkorb) =
        // Dummy implementation, in a real application this would process the payment and update the database
        printfn "Bestellung abgeschlossen. Vielen Dank für Ihren Einkauf!"
