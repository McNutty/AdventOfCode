open System.IO

let lines = File.ReadLines(".\Input\1.txt") |> Seq.toArray |> Array.map int

let triples = [|
    for n in 0..lines.Length-3 do
        lines.[n], lines.[n+1], lines.[n+2]
|]

let newinput = triples |> Array.map (fun (x,y,z) -> x+y+z)

let sequence = seq {
    for n in 0..newinput.Length-2 do
        if newinput.[n] < newinput.[n+1] then
            1
        else
            0
    }

let result = sequence |> Seq.sum
printfn "The sum is %s" (result.ToString())