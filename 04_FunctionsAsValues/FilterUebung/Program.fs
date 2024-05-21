// Aufgabe 1
let filterEvenNumbers (numbers: int list) =
    numbers
    |> List.filter (fun x -> x % 2 = 0)

let numbers = [1; 2; 3; 4; 5]
let evenNumbers = filterEvenNumbers numbers

printfn "%A" evenNumbers // Output: [2; 4]

// Aufgbae 2
let filterLongNames (names: string list) =
    names
    |> List.filter (fun x -> x.Length > 4)
let names = ["Alice"; "Bob"; "Charlie"; "Diana"]
let longNames = filterLongNames names

printfn "%A" longNames // Output: ["Alice"; "Charlie"; "Diana"]

// Aufgabe 3
let filterLargeNumbers (numbers: int list) =
    numbers
    |> List.filter (fun x -> x > 50)
let numbersA3 = [12; 45; 68; 100]
let largeNumbers = filterLargeNumbers numbersA3

printfn "%A" largeNumbers // Output: [68; 100]

// Aufgabe 4
let filterWordsStartingWithS (words: string list) =
    words
    |> List.filter (fun x -> x.StartsWith("S"))
let words = ["Scala"; "ist"; "fantastisch"]
let wordsStartingWithS = filterWordsStartingWithS words

printfn "%A" wordsStartingWithS // Output: ["Scala"]

// Aufgabe 5
type Buch = { Titel: string; Autor: string; Jahr: int }

let getTitlesOfBooksPublishedBefore1950 (buecher: Buch list) =
    buecher
    |> List.filter (fun x -> x.Jahr < 1950)
    |> List.map (fun x -> x.Titel)
let buecher = [
    { Titel = "1984"; Autor = "George Orwell"; Jahr = 1949 }
    { Titel = "Brave New World"; Autor = "Aldous Huxley"; Jahr = 1932 }
    { Titel = "Fahrenheit 451"; Autor = "Ray Bradbury"; Jahr = 1953 }
]

let titles = getTitlesOfBooksPublishedBefore1950 buecher

printfn "%A" titles // Output: ["1984"; "Brave New World"]
