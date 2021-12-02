open System.IO

let lines = File.ReadAllLines(".\Input\2.txt") |> Array.map string

let mutable horizontalPosition = 0
let mutable depth = 0
let mutable aim = 0

let calculateNewPosition (direction, value) =
    match direction with
    | "forward" ->  horizontalPosition <- horizontalPosition + value
                    depth <- depth + (aim * value)
    | "down" -> aim <- aim + value
    | "up" -> aim <- aim - value
    | _ -> ()

lines 
|> Array.map (fun line ->  
                let arr = line.Split ' '
                arr.[0], int(arr.[1]))
|> Array.iter calculateNewPosition

printfn "The forward position is: %d" horizontalPosition
printfn "The depth is: %d" depth
printfn "The product is: %d" (horizontalPosition * depth)