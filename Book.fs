module total.Book

open FSharp.Json

type Book =
    { title: string
      author: string
      borrower: Borrower.Borrower option }

type JsonString = string

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
    | Some br -> sprintf "Checked out to %s" (Borrower.getName br)
    | None -> "Available"

let toString bk =
    sprintf "%s by %s; %s" (getTitle (bk)) (getAuthor (bk)) (availableString (bk))

let jsonStringToBook (bookString: JsonString): Book = Json.deserialize<Book> bookString

let bookToJsonString (bk: Book): JsonString = Json.serializeU bk
