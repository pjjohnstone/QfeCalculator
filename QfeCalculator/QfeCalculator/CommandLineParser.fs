module CommandLineParser

open CommandLineOptions

let parseFloat s = try Some (float s) with | _ -> None

let parseCommandLine args =
  let defaults = {
    baroUnits = Mbar;
    baroValue = 1012.0;
    altUnits = Feet;
    altValue = 100;
  }
  let rec parseCommandLine args optionsSoFar =
    match args with
    | [] ->
      optionsSoFar
    | "--mmhg"::xs | "-h"::xs ->   
      match (parseFloat xs.Head) with
      | Some x ->
        let optionsSoFar = { optionsSoFar with baroUnits = MmHg; baroValue = x}
        parseCommandLine xs.Tail optionsSoFar
      | None -> 
        eprintfn "--mmhg must be followed by a value"
        parseCommandLine xs.Tail optionsSoFar
    | "--inhg"::xs | "-i"::xs ->   
      match (parseFloat xs.Head) with
      | Some x ->
        let optionsSoFar = { optionsSoFar with baroUnits = InHg; baroValue = x}
        parseCommandLine xs.Tail optionsSoFar
      | None -> 
        eprintfn "--inhg must be followed by a value"
        parseCommandLine xs.Tail optionsSoFar
    | "--mbar"::xs | "-b"::xs ->   
      match (parseFloat xs.Head) with
      | Some x ->
        let optionsSoFar = { optionsSoFar with baroUnits = Mbar; baroValue = x}
        parseCommandLine xs.Tail optionsSoFar
      | None -> 
        eprintfn "--mbar must be followed by a value"
        parseCommandLine xs.Tail optionsSoFar
    | "--feet"::xs | "-f"::xs ->   
      match (parseFloat xs.Head) with
      | Some x ->
        let optionsSoFar = { optionsSoFar with altUnits = Feet; altValue = x}
        parseCommandLine xs.Tail optionsSoFar
      | None -> 
        eprintfn "--feet must be followed by a value"
        parseCommandLine xs.Tail optionsSoFar
    | "--meters"::xs | "-m"::xs ->   
      match (parseFloat xs.Head) with
      | Some x ->
        let optionsSoFar = { optionsSoFar with altUnits = Meters; altValue = x}
        parseCommandLine xs.Tail optionsSoFar
      | None -> 
        eprintfn "--meters must be followed by a value"
        parseCommandLine xs.Tail optionsSoFar
    | x::xs ->
      eprintfn "Option '%s' is unrecognized" x
      parseCommandLine xs optionsSoFar
  parseCommandLine args defaults