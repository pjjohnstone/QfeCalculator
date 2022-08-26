open CommandLineParser

[<EntryPoint>]
let main(args) =
  let options = 
    args
    |> Array.toList
    |> parseCommandLine

  printfn "QFE at %.2f %A with QNH of %.2f %A is %.2f %A" options.altValue options.altUnits options.baroValue options.baroUnits (Qfe.calculate options) options.baroUnits
  0