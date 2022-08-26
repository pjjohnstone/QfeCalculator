module CommandLineOptions

type QnhOption = MmHg | InHg | Mbar
type AltOption = Feet | Meters

type CommandLineOptions = {
  baroUnits : QnhOption;
  baroValue: double;
  altUnits : AltOption;
  altValue: double;
}