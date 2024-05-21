// Aufgabe 1
let doubleNumbers (numbers: int list) =
    numbers
    |> List.map (fun x -> x * 2)

let numbers = [1; 2; 3; 4; 5]
let doubledNumbers = doubleNumbers numbers

printfn "%A" doubledNumbers // Output: [2; 4; 6; 8; 10]

// Aufgabe 2
let namesToUppercase (names: string list) =
    names
    |> List.map (fun x -> x.ToUpper())

let names = ["Alice"; "Bob"; "Charlie"]
let uppercaseNames = namesToUppercase names

printfn "%A" uppercaseNames // Output: ["ALICE"; "BOB"; "CHARLIE"]

// Aufgabe 3
let halveNumbers (numbers: float32 list) =
    numbers
    |> List.map (fun x -> x / 2.0f)

let numbersA3 = [12.0f; 45.0f; 68.0f; 100.0f]
let halvedNumbers = halveNumbers numbersA3

printfn "%A" halvedNumbers // Output: [6; 22.5; 34; 50]


// Aufgabe 4
type Address = { Street: string; Number: int; ZipCode: string; City: string }

let formatAddresses (addresses: Address list) =
    addresses
    |> List.map (fun addr -> sprintf "%s %d, %s %s" addr.Street addr.Number addr.ZipCode addr.City)

let addresses = [
    { Street = "Hauptstrasse"; Number = 10; ZipCode = "12345"; City = "Musterstadt" }
    { Street = "Nebenstrasse"; Number = 5; ZipCode = "23456"; City = "Beispielburg" }
]

let formattedAddresses = formatAddresses addresses

printfn "%A" formattedAddresses // Output: ["Hauptstrasse 10, 12345 Musterstadt"; "Nebenstrasse 5, 23456 Beispielburg"]

// Aufgabe 5
let firstNamesToUppercase (names: string list) =
    names
    |> List.map (fun x -> x.Split(' ') |> Array.head |> (fun y -> y.ToUpper()))

let namesA5 = ["Max Mustermann"; "Erika Mustermann"]
let uppercaseFirstNames = firstNamesToUppercase namesA5

printfn "%A" uppercaseFirstNames // Output: ["MAX"; "ERIKA"]
