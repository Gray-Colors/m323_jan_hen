// Aufgabe 1
let numbers = [ [1; 2]; [3; 4]; [5; 6] ]

let doubledNumbers = numbers |> List.collect (List.map (fun x -> x * 2))

printfn "Doubled numbers: %A" doubledNumbers

// Aufgabe 2
let people = [("Max", ["Blau"; "Grün"]); ("Anna", ["Rot"]); ("Julia", ["Gelb"; "Blau"; "Grün"])]

let uniqueFavouriteColors =
    people
    |> List.collect (fun (_, colors) -> colors)
    |> List.distinct

printfn "Unique favourite colors: %A" uniqueFavouriteColors
