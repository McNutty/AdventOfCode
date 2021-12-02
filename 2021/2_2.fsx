open System.IO

let lines = File.ReadLines(".\Input\2.txt") |> Seq.map string

let movements = seq {
    for line in lines do
        let tuple = line.Split ' '
        tuple.[0], int(tuple.[1])
}

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


movements |> Seq.iter calculateNewPosition 

printfn "The forward position is: %d" horizontalPosition
printfn "The depth is: %d" depth
printfn "The product is: %d" (horizontalPosition * depth)
