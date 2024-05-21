// Aufgabe 1
let numbers = [1..10]

let squaredNumbers =
    [for number in numbers do
        yield number * number]

printfn "%A" squaredNumbers

// Aufgabe 2
let numbersA2 = [1..20]

let evenNumbers =
    [for number in numbersA2 do
        if number % 2 = 0 then
            yield number]

printfn "%A" evenNumbers

// Aufgabe 3
let colors = ["Red"; "Green"; "Blue"]
let fruits = ["Apple"; "Banana"; "Orange"]

let colorFruitPairs =
    [for color in colors do
        for fruit in fruits do
            yield (color, fruit)]

printfn "%A" colorFruitPairs

// Aufgabe 4
type User = { Name: string; Tasks: string list }

let users = [
    { Name = "Alice"; Tasks = ["Task 1"; "Task 2"; "Task 3"] }
    { Name = "Bob"; Tasks = ["Task 1"; "Task 4"; "Task 5"] }
    { Name = "Charlie"; Tasks = ["Task 2"; "Task 3"; "Task 6"] }
]

let tasksCompleted = ["Task 1"; "Task 3"; "Task 5"]

let pendingTasks =
    [for user in users do
        for task in user.Tasks do
            if not (List.contains task tasksCompleted) then
                yield (user.Name, task)]

printfn "%A" pendingTasks