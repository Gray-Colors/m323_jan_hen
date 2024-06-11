open System

let countingLazyList = Seq.initInfinite (fun i -> i + 1) // 1

let evenNumbersLazyList = Seq.initInfinite (fun i -> i * 2) // 2

let powerOfTwoLazyList = Seq.initInfinite (fun i -> int (Math.Pow(2.0, double i))) // 3

let alphabetLazyList =
    Seq.initInfinite (fun i -> char (i % 26 + 97)) // 4a
    |> Seq.map (fun c -> c.ToString()) // 4b
    |> Seq.collect (fun letter ->
        Seq.initInfinite (fun i -> char (i % 26 + 97))
        |> Seq.map (fun c -> c.ToString())
        |> Seq.map (fun c -> letter + c)
    )

let random = new Random()
let randomNumbersLazyList = Seq.initInfinite (fun _ -> random.Next(1, 7) ) // 5

// Example usage and printing first 10 elements of each sequence
let printFirstN seq n =
    seq |> Seq.take n |> Seq.iter (printf "%A ")
        
printfn "First 10 of countingLazyList:"
printFirstN countingLazyList 10

printfn "\nFirst 10 of evenNumbersLazyList:"
printFirstN evenNumbersLazyList 10

printfn "\nFirst 10 of powerOfTwoLazyList:"
printFirstN powerOfTwoLazyList 10

printfn "\nFirst 10 of alphabetLazyList:"
printFirstN alphabetLazyList 10

printfn "\nFirst 10 of randomNumbersLazyList:"
printFirstN randomNumbersLazyList 10
