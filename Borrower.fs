module total.Borrower

open FSharp.Json

type Borrower = { name: string; maxBooks: int }
type JsonString = string

let getName (br: Borrower): string = br.name

let setName (n: string) (br: Borrower): Borrower = { br with name = n }

let getMaxBooks (br: Borrower): int = br.maxBooks

let setMaxBooks (mb: int) (br: Borrower): Borrower = { br with maxBooks = mb }

let toString (br: Borrower): string =
    sprintf "%s (%i books)" (getName br) (getMaxBooks br)

let borrowerJsonStringToBorrower (borrowerString: JsonString): Borrower =
    Json.deserialize<Borrower> borrowerString

let borrowerToJsonString (br: Borrower): JsonString = Json.serializeU br
