open System.IO

let createIncreasingDepthCountSequence (inputArray: string[]) = seq {
    for n in 0..inputArray.Length-2 do
        if int(inputArray.[n]) < int(inputArray.[n+1]) then
            1
        else
            0
    }
    
File.ReadAllLines(".\Input\1.txt") 
|> createIncreasingDepthCountSequence
|> Seq.sum
|> printfn "The sum is %d"