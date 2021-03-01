module total.Borrower

open FSharp.Json

type Borrower = { name: string; maxBooks: int }
type JsonString = string

let getName (b: Borrower) = b.name

let setName (b: Borrower) (n: string) = { b with name = n }

let getMaxBooks (b: Borrower) = b.maxBooks

let setMaxBooks (b: Borrower) mb = { b with maxBooks = mb }

let borrowerToString b =
    sprintf "%s (%i books)" (getName b) (getMaxBooks b)

let borrowerJsonStringToBorrower (borrowerString: JsonString) =
    Json.deserialize<Borrower> borrowerString

let borrowerToJsonString (br: Borrower): JsonString = Json.serializeU br
