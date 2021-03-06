module total.Book

open total.Borrower

type InBook = InBook of title: string * author: string
type OutBook = OutBook of title: string * author: string * borrower: Borrower

type Book =
    | InBook of title: string * author: string
    | OutBook of title: string * author: string * borrower: Borrower



//let getTitle (InBook (titleX, _)): string = titleX
//    match bk with
//    | InBook (t, _) -> t
//    | OutBook (t, _, _) -> t
//
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
let availableString (bk: Book): string =
    match bk with
    | InBook _ -> "Available"
    | OutBook (_, _, br) -> sprintf "Checked out to %s" (getName br)
