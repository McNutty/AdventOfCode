open System.IO

let lines = File.ReadLines(".\Input\2.txt") |> Seq.map string

let movements = seq {
    for line in lines do
        let arr = line.Split ' '
        let direction = arr.[0]
        let value = int(arr.[1])
        direction, value
}

let mutable horizontalPosition = 0
let mutable depth = 0

let calculateNewPosition (direction, value) =
    match direction with
    | "forward" -> horizontalPosition <- horizontalPosition + value
    | "down" -> depth <- depth + value
    | "up" -> depth <- depth - value
    | _ -> ()

movements |> Seq.iter calculateNewPosition 

printfn "The forward position is: %d" horizontalPosition
printfn "The depth is: %d" depth
printfn "The product is: %d" (horizontalPosition * depth)
