open System

type Destination = string

type TravelRoute =
    {
        Destinations : Destination list
    }
    member this.AddDestination (destination : Destination) =
        { this with Destinations = this.Destinations @ [destination] }

    member this.ChangeDestination (index : int, newDestination : Destination) =
        let destinations = this.Destinations
        if index >= 0 && index < List.length destinations then
            let newDestinations = List.take index destinations @ [newDestination] @ List.skip (index + 1) destinations
            { this with Destinations = newDestinations }
        else
            failwith "Invalid index"

let createTravelRoute =
    {
        Destinations = []
    }

let rec getDestination() =
    Console.Write("Enter the name of the destination or 'q' to quit: ")
    let input = Console.ReadLine()

    match input with
    | "q" -> None
    | _ -> Some input

let rec getIndex() =
    Console.Write("Enter the index of the destination to change or 'q' to quit: ")
    let input = Console.ReadLine()

    let mutable index = 0
    match Int32.TryParse(input, &index) with
    | true -> Some index
    | false ->
        Console.WriteLine("Invalid input. Please enter a number or 'q' to quit.")
        getIndex()

let rec mainLoop(route: TravelRoute) =
    Console.WriteLine("Current route:")
    route.Destinations |> List.iter (fun dest -> Console.WriteLine(dest))

    Console.WriteLine("1. Add a destination")
    Console.WriteLine("2. Change a destination")
    Console.WriteLine("3. Quit")

    Console.Write("Choose an option: ")
    let input = Console.ReadLine()

    match input with
    | "1" ->
        match getDestination() with
        | Some destination -> mainLoop(route.AddDestination(destination))
        | None -> mainLoop(route)
    | "2" ->
        match getIndex() with
        | Some index ->
            match getDestination() with
            | Some destination -> mainLoop(route.ChangeDestination(index, destination))
            | None -> mainLoop(route)
        | None -> mainLoop(route)
    | "3" -> ()
    | _ ->
        Console.WriteLine("Invalid input. Please enter a number between 1 and 3.")
        mainLoop(route)

[<EntryPoint>]
let main argv =
    mainLoop(createTravelRoute)

    0
