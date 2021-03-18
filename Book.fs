module total.Book

open total.Borrower
open FSharp.Json

type Book =
    { title: string
      author: string
      borrower: Borrower option }

let defaultBook =
    { title = ""
      author = ""
      borrower = None }

let getTitle bk = bk.title

let getAuthor bk = bk.author

let getBorrower bk = bk.borrower

let setBorrower br bk = { bk with borrower = br }

let availableString bk =
    match (getBorrower bk) with
    | Some br -> sprintf "Checked out to %s" (getName br)
    | None -> "Available"

let toString bk =
    sprintf "%s by %s; %s" (getTitle (bk)) (getAuthor (bk)) (availableString (bk))

let bookJsonStringToBook (bookString: JsonString): Book = Json.deserialize<Book> bookString

let bookToJsonString (bk: Book): JsonString = Json.serializeU bk
