open System

let wetterFunktion () =
    let wetterbeschreibung = "sonnig" // Beispielwert
    let currentTime = DateTime.Now
    let temperatur = 25.0 // Beispielwert

    (wetterbeschreibung, currentTime, temperatur)


let wetterdaten : List<string * DateTime * double> = [
    ("Stadt1", DateTime(2024, 5, 21, 9, 0, 0), 18.0)
    ("Stadt2", DateTime(2024, 5, 21, 10, 30, 0), 22.5)
    ("Stadt3", DateTime(2024, 5, 21, 12, 15, 0), 17.8)
    // Weitere Daten hier hinzufügen
]

let städteÜberTemperatur (temperatur : double) =
    wetterdaten
    |> List.filter (fun (_, _, t) -> t > temperatur)
    |> List.map (fun (stadt, _, _) -> stadt)

// Beispielaufruf
let städteÜber20Grad = städteÜberTemperatur 20.0
printfn "Städte über 20 Grad: %s" (städteÜber20Grad |> String.concat ", ")
