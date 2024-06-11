open System

// Create a single instance of Random to be used for rolling dice
let random = new Random()

let rollDiceImpure() =
    random.Next(1, 7)

// Example call
let initialResult = rollDiceImpure()
printfn "Der Würfel zeigt: %d" initialResult

let rollDice() =
    async {
        return rollDiceImpure()
    }

let allowToLeaveHome() =
    async {
        let! checkRoll = rollDice()
        return checkRoll = 6
    }

// Call the function... allowToLeave is now an async<bool>
let allowToLeave = allowToLeaveHome()
let finalResult = Async.RunSynchronously(allowToLeave)
printfn "Allow to leave: %b" finalResult
