open System.IO

let input = File.ReadAllLines(".\Input\1.txt") |> Array.map int

let createIncreasingDepthCountSequence (inputArray: int[]) = [|
    for n in 0..inputArray.Length-2 do
        if inputArray.[n] < inputArray.[n+1] then
            1
        else
            0
    |]

let part1 =    
    input
    |> createIncreasingDepthCountSequence
    |> Seq.sum 
    |> printfn "Day 1 - Part 1: %d"

let createTriples (inputArray: int[])= [|
    for n in 0..inputArray.Length-3 do
        inputArray.[n], inputArray.[n+1], inputArray.[n+2]
    |]

let part2 =
    input
    |> createTriples
    |> Array.map (fun (x,y,z) -> x+y+z)
    |> createIncreasingDepthCountSequence
    |> Seq.sum
    |> printfn "Day 1 - Part 2: %d"