module Queen

type BoardSolution = int[]

let bedroht pos (teilloesung: BoardSolution) =
    let row = Array.length teilloesung
    let rec check (r: int) =
        if r >= row then false
        else
            let c = teilloesung.[r]
            if c = pos || abs (c - pos) = abs (r - row) then true
            else check (r + 1)
    check 0

let solve n (solution: BoardSolution) =
    let rec solve row board solutions =
        if row = n then
            board :: solutions
        else
            let availableColumns = [0 .. n-1] |> List.filter (fun col -> not (bedroht col board))
            let newSolutions =
                availableColumns
                |> List.map (fun col -> solve (row + 1) (Array.append board [|col|]) solutions)
                |> List.fold (fun acc sol -> acc @ sol) []
            newSolutions
    solve 0 [||] []


[<EntryPoint>]
let main argv =
    let a = solve 8 [||]
    printfn "Found %d possible solutions!" a.Length
    0
