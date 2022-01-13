open System.IO
open System

let getMostCommonCharIn s = 
    let numberOfZeroes = 
        s
        |> String.filter (fun c -> c = '0')
        |> String.length
    let numberOfOnes = 
        s
        |> String.filter (fun c -> c = '1')
        |> String.length

    if numberOfZeroes > numberOfOnes then
        '0'
    else
        '1'       
    

let getLeastCommonCharIn s = 
    if getMostCommonCharIn s = '1' then
        '0'
    else
        '1'

let getValueFromBitString s = 
    Convert.ToInt32(s,2)

let input = File.ReadAllLines(".\Input\3.txt") 

let transposedInput = 
    input    
    |> Array.map (fun s -> s.ToCharArray())
    |> Array.transpose 
    |> Array.map (fun array -> new string(array) )

let leastCommonChars =
    transposedInput
    |> Array.map (fun s -> getMostCommonCharIn s)
      
let mostCommonChars =
    transposedInput
    |> Array.map (fun s -> getLeastCommonCharIn s)
    
let calculateGammaRate = 
    leastCommonChars
    |> String
    |> getValueFromBitString

let calculateEpsilonRate = 
    mostCommonChars
    |> String
    |> getValueFromBitString

printfn "1-1: %d" (calculateGammaRate * calculateEpsilonRate)
