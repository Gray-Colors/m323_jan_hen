type Course = { Title: string; Students: string list }

type CourseSubscriptions = { Title: string; TotalStudents: int }

let courses = [
    { Title = "M323"; Students = ["Peter"; "Petra"; "Paul"; "Paula"] }
    { Title = "M183"; Students = ["Paula"; "Franz"; "Franziska"] }
    { Title = "M117"; Students = ["Paul"; "Paula"] }
    { Title = "M114"; Students = ["Petra"; "Paul"; "Paula"] }
]

// Number of courses containing student "Peter"
printfn "%d" (courses |> List.filter (fun course -> course.Students |> List.contains "Peter") |> List.length) // 1

// Number of courses containing student "Petra"
printfn "%d" (courses |> List.filter (fun course -> course.Students |> List.contains "Petra") |> List.length) // 2

// Titles of courses containing student "Peter"
printfn "%A" (courses |> List.filter (fun course -> course.Students |> List.contains "Peter") |> List.map (fun course -> course.Title))

// Titles of courses containing student "Petra"
printfn "%A" (courses |> List.filter (fun course -> course.Students |> List.contains "Petra") |> List.map (fun course -> course.Title))

// List of course titles and total students for each course
printfn "%A" (courses |> List.map (fun course -> { Title = course.Title; TotalStudents = course.Students.Length }))
