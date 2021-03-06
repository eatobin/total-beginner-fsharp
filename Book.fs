module total.Book

open total.Borrower
//open FSharp.Json

type Book =
    { title: string
      author: string
      maybeBorrower: Borrower option }

let getTitle bk = bk.title

let getAuthor bk = bk.author

let getMaybeBorrower bk = bk.maybeBorrower
let setMaybeBorrower bk br = { bk with maybeBorrower = br }

let availableString bk =
    match (getMaybeBorrower bk) with
    | Some br -> sprintf "Checked out to %s" (getName br)
    | None -> "Available"






//let setTitle (bk: Book) (title: string): Book =
//    match bk with
//    | InBook (_, a) -> InBook(title, a)
//    | OutBook (_, a, b) -> OutBook(title, a, b)
//
//let getAuthor (bk: Book): string =
//    match bk with
//    | InBook (_, a) -> a
//    | OutBook (_, a, _) -> a
//
//let setAuthor (bk: Book) (author: string): Book =
//    match bk with
//    | InBook (t, _) -> InBook(t, author)
//    | OutBook (t, _, b) -> OutBook(t, author, b)
//
//let getBorrower (bk: OutBook): Borrower =
//    match bk with
//    | Book.OutBook (t,)
//
//
//let setBorrower (bk: Book) (br: Borrower): Book =
//    match bk with
//    | InBook (t, a) -> OutBook(t, a, br)
//    | OutBook _ -> bk
//
////let setTitle (iBk: InBook) (t: string): InBook = { iBk with title = t }
////
////let getAuthor (iBk: InBook): string = iBk.author
////
////let setAuthor (iBk: InBook) (a: string): InBook = { iBk with author = a }
////
////let getBorrower (oBk: OutBook): Borrower = oBk.borrower
////
////let setBorrower (iBk: InBook) (br: Borrower): OutBook = { inBook = iBk; borrower = br }
////
