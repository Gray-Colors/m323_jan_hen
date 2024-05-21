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
