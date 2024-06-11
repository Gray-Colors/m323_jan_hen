let extractName (rawShow: string) : string option =
    let bracketOpen = rawShow.IndexOf('(')
    if bracketOpen <> -1 then
        Some (rawShow.Substring(0, bracketOpen - 1).Trim())
    else
        None

let extractYearEnd (rawShow: string) : int option =
    let dash = rawShow.IndexOf('-')
    let bracketClose = rawShow.IndexOf(')')
    if dash <> -1 && bracketClose > dash + 1 then
        let yearStr = rawShow.Substring(dash + 1, bracketClose - dash - 1).Trim()
        match System.Int32.TryParse(yearStr) with
        | true, year -> Some year
        | _ -> None
    else
        None