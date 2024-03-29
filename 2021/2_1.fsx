open System.IO

let mutable horizontalPosition = 0
let mutable depth = 0

let updatePosition (direction, value) =
    match direction with
    | "forward" -> horizontalPosition <- horizontalPosition + value
    | "down" -> depth <- depth + value
    | "up" -> depth <- depth - value
    | _ -> ()

File.ReadAllLines(".\Input\2.txt") 
|> Array.map string
|> Array.map (fun line ->  
                let arr = line.Split(' ')
                arr.[0], int(arr.[1]))
|> Array.iter updatePosition  

printfn "The forward position is: %d" horizontalPosition
printfn "The depth is: %d" depth
printfn "The product is: %d" (horizontalPosition * depth)