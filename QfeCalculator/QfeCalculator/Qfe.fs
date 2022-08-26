module Qfe

open CommandLineOptions

let qfe qnh alt = qnh - (alt / 30.0)

let calculate options =
  match options.altUnits with
  | Feet ->
    match options.baroUnits with
    | Mbar -> qfe options.baroValue options.altValue
    | MmHg -> Mbar.toMmHg (qfe (MmHg.toMbar options.baroValue)  options.altValue)
    | InHg -> Mbar.toInHg (qfe (InHg.toMbar options.baroValue) options.altValue)
  | Meters ->
    match options.baroUnits with
    | Mbar -> qfe (Meters.toFeet options.baroValue) options.altValue
    | MmHg -> Mbar.toMmHg (qfe (MmHg.toMbar options.baroValue) (Meters.toFeet options.altValue))
    | InHg -> Mbar.toInHg (qfe (InHg.toMbar options.baroValue) (Meters.toFeet options.altValue))
    