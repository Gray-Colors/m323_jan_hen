open System

type LapTime = { CarId: int; Lap: int; LapTime: float }

let calculateTotalAndAverageTimes (laptimes: LapTime list) =
    let laptimesByCar =
        laptimes
        |> List.filter (fun lp -> lp.Lap > 1) // filter out warm-up lap
        |> List.groupBy (fun lp -> lp.CarId)

    let totalTimes =
        laptimesByCar
        |> Seq.map (fun (carId, laps) -> carId, laps |> Seq.sumBy (fun lp -> lp.LapTime))
        |> dict

    let averageTimes =
        laptimesByCar
        |> Seq.map (fun (carId, laps) -> carId, laps |> Seq.averageBy (fun lp -> lp.LapTime))
        |> dict

    (totalTimes, averageTimes)

let rec getLapTime carId lap =
    Console.Write(sprintf "Enter lap time for Car %d, Lap %d (seconds) or 'q' to quit: " carId lap)
    let input = Console.ReadLine()

    let mutable lapTime = 0.0
    match input with
    | "q" -> None
    | lapTimeStr when Double.TryParse(lapTimeStr, &lapTime) ->
        Some { CarId = carId; Lap = lap; LapTime = lapTime }
    | _ ->
        Console.WriteLine("Invalid input. Please enter a number or 'q' to quit.")
        getLapTime carId lap

let rec getLapTimesForCar carId =
    let rec loop lap acc =
        match getLapTime carId lap with
        | Some laptime -> loop (lap + 1) (laptime :: acc)
        | None -> List.rev acc
    loop 1 []

let rec getCars() =
    Console.Write("Enter number of cars or 'q' to quit: ")
    let input = Console.ReadLine()

    let mutable numCars = 0
    match input with
    | "q" -> None
    | _ when Int32.TryParse(input, &numCars) ->
        Some (Seq.init numCars (fun i -> i + 1) |> Seq.map getLapTimesForCar |> Seq.concat |> List.ofSeq)
    | _ ->
        Console.WriteLine("Invalid input. Please enter a number or 'q' to quit.")
        getCars()

[<EntryPoint>]
let main _ =
    match getCars() with
    | Some laptimes ->
        let (totalTimes, averageTimes) = calculateTotalAndAverageTimes laptimes

        Console.WriteLine("\nTotal times:\n")
        totalTimes |> Seq.iter (fun kvp -> Console.WriteLine(sprintf "  Car %d: %.2f seconds" kvp.Key kvp.Value))

        Console.WriteLine("\nAverage times:\n")
        averageTimes |> Seq.iter (fun kvp -> Console.WriteLine(sprintf "  Car %d: %.2f seconds" kvp.Key kvp.Value))
    | None -> ()

    0
