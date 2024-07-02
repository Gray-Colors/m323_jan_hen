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

[<EntryPoint>]
let main argv =
    printfn "Hello, World!" 
    0
