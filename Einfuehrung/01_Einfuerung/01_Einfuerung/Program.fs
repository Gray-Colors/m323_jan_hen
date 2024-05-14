let calculateScore (word: string) =
    word.Replace("a", "")
         .ToCharArray()
         |> Array.length
         |> (+) 0

let wordCount (word:string) = 
    String.length word

let print (word: string, count: int) = 
    printfn "'%s' has %d letters" word count

print ("imperative", calculateScore "imperative")
print ("no", calculateScore "no")
print ("declarative", wordCount "declarative")
print ("yes", wordCount "yes")