module total.Borrower

open FSharp.Json

type Borrower = { Name: string; MaxBooks: int }

let getName (b: Borrower) = b.Name

let setName (b: Borrower) (n: string) = { b with Name = n }

let getMaxBooks (b: Borrower) = b.MaxBooks

let setMaxBooks (b: Borrower) mb = { b with MaxBooks = mb }

let borrowerToString b =
    sprintf "%s (%i books)" (getName b) (getMaxBooks b)

let config =
    JsonConfig.create (jsonFieldNaming = Json.lowerCamelCase)

let borrowerJsonStringToBorrower (borrowerString: string) =
    Json.deserializeEx<Borrower> config borrowerString

let borrowerToJsonString (br: Borrower) = Json.serializeU br
