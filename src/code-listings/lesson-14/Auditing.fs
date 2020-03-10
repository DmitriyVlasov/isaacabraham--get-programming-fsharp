module Capstone2.Auditing

open Capstone2.Domain
open System.IO

/// Base Path
[<Literal>]
let BASE_PATH = @"D:\temp\getprogrammingwithfsharp\lesson14"

/// Logs to the console
let console account message = printfn "Account %O: %s" account.AccountId message

/// Logs to the file system
let fileSystem account message =
    sprintf @"%s\%s" BASE_PATH account.Owner.Name
    |> Directory.CreateDirectory 
    |> ignore
    let filePath = 
        sprintf @"%s\%s\%O.txt" BASE_PATH account.Owner.Name account.AccountId
    File.AppendAllLines(filePath, [ message ])