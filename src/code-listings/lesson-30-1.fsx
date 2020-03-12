//  Listing 30.1
#I @"..\..\.paket\load\netcoreapp2.1\"
#load @"FSharp.Data.fsx"
#load @"Newtonsoft.Json.fsx"

open FSharp.Data
[<Literal>]
let DATASOUCE_PATH = @"..\..\data\FootballResults.csv"
type Football = CsvProvider< DATASOUCE_PATH >
let data = Football.GetSample().Rows |> Seq.toArray 

//  Listing 30.2
#I @"..\..\.paket\load\netcoreapp2.1\"
#load @"Google.DataTable.Net.Wrapper.fsx"
#load @"XPlot.GoogleCharts.fsx"

open XPlot.GoogleCharts

data
|> Seq.filter(fun row ->
    row.``Full Time Home Goals`` > row.``Full Time Away Goals``)
|> Seq.countBy(fun row -> row.``Home Team``)
|> Seq.sortByDescending snd
|> Seq.take 10
|> Chart.Column
|> Chart.Show