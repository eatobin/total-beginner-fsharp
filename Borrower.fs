module total.Borrower

open FSharp.Json

type Borrower = { name: string; maxBooks: int }
type JsonString = string

let getName (b: Borrower): string = b.name

let setName (b: Borrower) (n: string): Borrower = { b with name = n }

let getMaxBooks (b: Borrower): int = b.maxBooks

let setMaxBooks (b: Borrower) (mb: int): Borrower = { b with maxBooks = mb }

let borrowerToString (b: Borrower): string =
    sprintf "%s (%i books)" (getName b) (getMaxBooks b)

let borrowerJsonStringToBorrower (borrowerString: JsonString): Borrower =
    Json.deserialize<Borrower> borrowerString

let borrowerToJsonString (br: Borrower): JsonString = Json.serializeU br
