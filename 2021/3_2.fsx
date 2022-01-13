open System.IO
open System

let getMostCommonChar charArray = 
    let numberOfZeroes = 
        charArray
        |> Array.filter (fun c -> c = '0')
        |> Array.length
    let numberOfOnes = 
        charArray
        |> Array.filter (fun c -> c = '1')
        |> Array.length

    if numberOfZeroes > numberOfOnes then
        '0'
    else
        '1'       
    

let getLeastCommonChar charArray = 
    if getMostCommonChar charArray = '1' then
        '0'
    else
        '1'

let convertBitStringToInt s = 
    Convert.ToInt32(s,2)

let input = File.ReadAllLines(".\Input\3.txt") |> Array.map (fun s -> s.ToCharArray())

let transposedInput = input |> Array.transpose 
let mostCommonBitInPosition = transposedInput |> Array.map getMostCommonChar
let leastCommonBitInPosition = transposedInput |> Array.map getLeastCommonChar
    
let gammaRate = 
    mostCommonBitInPosition
    |> String
    |> convertBitStringToInt

let epsilonRate = 
    leastCommonBitInPosition
    |> String
    |> convertBitStringToInt

    // To find oxygen generator rating, determine the most common value (0 or 1) in the current bit position, and keep only numbers with that bit in that position. If 0 and 1 are equally common, keep values with a 1 in the position being considered.
    0        

let oxygenFilter (input : char[]) (i : int)= 
    if input.[i] = mostCommonBitInPosition.[i] then
        true
    else
        false

let oxygenGeneratorRating i = 
    input
    |> 

for i in 0..12 do
    oxygenGeneratorRating i





let CO2ScrubberRating =
    0

printfn "1-1: %d" (gammaRate * epsilonRate)
printfn "1-2: %d"
