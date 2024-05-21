// Aufgabe 1
type Mitarbeiter = { Name: string; Abteilung: string; Gehalt: int }

let getNamesOfITEmployeesWithSalaryAtLeast50000 (mitarbeiter: Mitarbeiter list) =
    mitarbeiter
    |> List.filter (fun x -> x.Abteilung = "IT" && x.Gehalt >= 50000)
    |> List.map (fun x -> x.Name.Split(' ') |> Array.head |> (fun y -> y.ToUpper()))
let mitarbeiter = [
    { Name = "Max Mustermann"; Abteilung = "IT"; Gehalt = 50000 }
    { Name = "Erika Musterfrau"; Abteilung = "Marketing"; Gehalt = 45000 }
    { Name = "Klaus Klein"; Abteilung = "IT"; Gehalt = 55000 }
    { Name = "Julia Gross"; Abteilung = "HR"; Gehalt = 40000 }
]

let names = getNamesOfITEmployeesWithSalaryAtLeast50000 mitarbeiter

printfn "%A" names // Output: ["MAX"; "KLAUS"]

// Aufgabe 2
let processCourseNames (kurse: string list) =
    kurse
    |> List.filter (fun x -> x.Contains("Daten"))
    |> List.map (fun x -> x.Replace(" ", ""))
    |> List.sort
    |> List.rev

let kurse = [
    "Programmierung in Scala"
    "Datenbanken"
    "Webentwicklung mit JavaScript"
    "Algorithmen und Datenstrukturen"
]

let processedCourseNames = processCourseNames kurse

printfn "%A" processedCourseNames // Output: ["DatenstrukturenAlgorithmenund", "Datenbanken"]
