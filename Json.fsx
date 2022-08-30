#r "nuget: FSharp.Json"
open FSharp.Json

// Your record type
type RecordType =
    { stringMember: string
      intMember: int }

let data: RecordType =
    { stringMember = "The string"
      intMember = 123 }

// serialize record into JSON
let json = Json.serialize data
printfn $"\njson is:\n %s{json}"
// json is """{ "stringMember": "The string", "intMember": 123 }"""

// deserialize from JSON to record
let deserialized =
    Json.deserialize<RecordType> json

printfn $"\ndeserialized is:\n%A{deserialized}"
// deserialized is {stringMember = "some value"; intMember = 123;}
