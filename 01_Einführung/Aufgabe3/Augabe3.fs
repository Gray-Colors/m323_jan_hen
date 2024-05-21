module Aufgabe3

type TipCalculator = {
    Names: string list
    TipPercentage: int
}
 
module TipCalculator = 
    let addPerson name (calculator: TipCalculator) = 
        let updatedNames = name :: calculator.Names
        let updatedTipPercentage = 
            match List.length updatedNames with
            | count when count > 5 -> 20
            | count when count > 0 -> 10
            | _ -> 0
        { calculator with Names = updatedNames; TipPercentage = updatedTipPercentage }
 
    let getNames calculator = calculator.Names
 
    let getTipPercentage calculator = calculator.TipPercentage
 
// Example usage:
let initialCalculator = { Names = []; TipPercentage = 0 }
 
let updatedCalculator = 
    initialCalculator
    |> TipCalculator.addPerson "Alice"
    |> TipCalculator.addPerson "Bob"
    |> TipCalculator.addPerson "Charlie"
    |> TipCalculator.addPerson "Diana"
    |> TipCalculator.addPerson "Eve"
    |> TipCalculator.addPerson "Frank"
 
printfn "Names: %A" (TipCalculator.getNames updatedCalculator)
printfn "Tip Percentage: %d" (TipCalculator.getTipPercentage updatedCalculator)