// Aufgabe 1
let sumOfNumbers (numbers: int list) =
    numbers
    |> List.fold (fun acc x -> acc + x) 0

let numbers = [1; 2; 3; 4; 5]

let sum = sumOfNumbers numbers

printfn "%d" sum // Output: 15


// Aufgabe 2
let strings = ["Hallo"; " "; "Welt"; "!"]

let concatenatedString =
    strings
    |> List.fold (fun acc string -> acc + string) ""

printfn "%s" concatenatedString

// Aufgabe 3
let points = [(1.0, 3.0); (2, 5); (4, 8); (6, 2)]

let centerOfMass (points: (float * float) list) =
    let n = float points.Length
    let sumX, sumY = points |> List.fold (fun (sumX, sumY) (x, y) -> (sumX + x, sumY + y)) (0.0, 0.0)
    (sumX / n, sumY / n)

let center = centerOfMass points
printfn "Center of mass: (%f, %f)" center.Item1 center.Item2
