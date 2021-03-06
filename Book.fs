module total.Book

open total.Borrower
open FSharp.Json

type Book =
    { title: string
      author: string
      maybeBorrower: Borrower option }

let defaultBook =
    { title = ""
      author = ""
      maybeBorrower = None }

let getTitle bk = bk.title

let getAuthor bk = bk.author

let getMaybeBorrower bk = bk.maybeBorrower

let setMaybeBorrower bk br = { bk with maybeBorrower = br }

let availableString bk =
    match (getMaybeBorrower bk) with
    | Some br -> sprintf "Checked out to %s" (getName br)
    | None -> "Available"

let toString bk =
    sprintf "%s by %s; %s" (getTitle (bk)) (getAuthor (bk)) (availableString (bk))

let bookJsonStringToBook (bookString: JsonString): Book = Json.deserialize<Book> bookString

let bookToJsonString (bk: Book): JsonString = Json.serializeU bk
