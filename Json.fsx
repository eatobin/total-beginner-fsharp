#r "nuget: FSharp.Json"

open System
open FSharp.Json

// Your record type
type RecordType =
    { stringMember: string
      intMember: int
      boolOptMember: Boolean option }

let data: RecordType =
    { stringMember = "The string"
      intMember = 123
      boolOptMember = None }

let data2: RecordType =
    { stringMember = "The string"
      intMember = 123
      boolOptMember = Some(false) }

// serialize record into JSON
let json = Json.serialize data
printfn $"\njson is:\n %s{json}"
// json is """{ "stringMember": "The string", "intMember": 123 }"""

// deserialize from JSON to record
let deserialized =
    Json.deserialize<RecordType> json

printfn $"\ndeserialized is:\n%A{deserialized}"
// deserialized is {stringMember = "some value"; intMember = 123;}

let json2 = Json.serialize data2
printfn $"\njson2 is:\n %s{json2}"
// json is """{ "stringMember": "The string", "intMember": 123 }"""

// deserialize from JSON to record
let deserialized2 =
    Json.deserialize<RecordType> json2

printfn $"\ndeserialized2 is:\n%A{deserialized2}"
// deserialized is {stringMember = "some value"; intMember = 123;}
