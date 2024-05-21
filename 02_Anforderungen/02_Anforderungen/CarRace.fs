
module Anforderungen

type LapTime = { CarId: int; LapTime: float }

let calculateTotalAndAverageTimes (laptimes: LapTime list) =
    let laptimesByCar =
        laptimes
        |> List.filter (fun lp -> lp.LapTime > 1) // filter out warm-up lap
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
