module total.Library

let addItem x xs =
    if List.contains x xs then xs else x :: xs

let removeBook bk bks = List.filter (fun b -> b <> bk) bks

let findItem (tgt: string) (coll: 'a list) (f: ('a -> string)): 'a option =
    let res =
        List.filter (fun item -> f (item) = tgt) coll

    if res.IsEmpty then None else Some(res.Head)

let getBooksForBorrower (br: Borrower.Borrower) (bks: Book.Book list): Book.Book list =
    List.filter (fun bk -> Option.contains br (Book.getBorrower bk)) bks

let numBooksOut br bks = List.length (getBooksForBorrower br bks)

let notMaxedOut br bks =
    numBooksOut br bks < Borrower.getMaxBooks br

let bookNotOut bk = Option.isNone (Book.getBorrower bk)
