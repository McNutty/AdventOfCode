open System.IO

let createTriples (inputArray: int[])= [|
    for n in 0..inputArray.Length-3 do
        inputArray.[n], inputArray.[n+1], inputArray.[n+2]
    |]

let createIncreasingDepthCountSequence (inputArray: int[]) = [|
    for n in 0..inputArray.Length-2 do
        if inputArray.[n] < inputArray.[n+1] then
            1
        else
            0
    |]

File.ReadAllLines(".\Input\1.txt")
|> Array.map int 
|> createTriples
|> Array.map (fun (x,y,z) -> x+y+z)
|> createIncreasingDepthCountSequence
|> Seq.sum
|> printfn "The sum is %d"