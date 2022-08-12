open CommandLineParser

[<EntryPoint>]
let main(args) =
  let options = 
    args
    |> Array.toList
    |> parseCommandLine

  printfn "%A" options
  0