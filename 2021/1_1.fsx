open System.IO

let lines = File.ReadLines(".\Input\1.txt") |> Seq.toArray 

let sequence = seq {
    for n in 0..lines.Length-2 do
        if int(lines.[n]) < int(lines.[n+1]) then
            1
        else
            0
    }
    
let result = sequence |> Seq.sum
printfn "The sum is %s" (result.ToString())