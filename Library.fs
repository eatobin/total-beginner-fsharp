module total.Library

open Borrower
open Book

let addItem x xs =
    if List.contains x xs then
        xs
    else
        x :: xs

let removeBook bk bks = List.filter (fun b -> b <> bk) bks

let findItem (tgt: string) (coll: 'a list) (f: 'a -> string) : 'a option =
    let res =
        List.filter (fun item -> f item = tgt) coll

    if res.IsEmpty then
        None
    else
        Some(res.Head)

let getBooksForBorrower (br: Borrower.Borrower) (bks: Book.Book list) : Book.Book list =
    List.filter (fun bk -> Option.contains br (getBorrower bk)) bks

let numBooksOut br bks =
    getBooksForBorrower br bks |> List.length

let notMaxedOut br bks = numBooksOut br bks < getMaxBooks br

let bookNotOut bk = getBorrower bk |> Option.isNone

let bookOut bk = getBorrower bk |> Option.isSome

let checkOut (n: string) (t: string) (brs: Borrower.Borrower list) (bks: Book.Book list) : Book.Book list =
    let mbk = findItem t bks getTitle
    let mbr = findItem n brs getName

    if
        mbk |> Option.isSome
        && mbr |> Option.isSome
        && notMaxedOut (mbr |> Option.get) bks
        && bookNotOut (mbk |> Option.get)
    then
        let newBook =
            setBorrower mbr (mbk |> Option.get)

        let fewerBooks =
            removeBook (mbk |> Option.get) bks

        addItem newBook fewerBooks
    else
        bks

let checkIn (t: string) (bks: Book.Book list) : Book.Book list =
    let mbk = findItem t bks getTitle

    if
        mbk |> Option.isSome
        && bookOut (mbk |> Option.get)
    then
        let newBook =
            setBorrower None (mbk |> Option.get)

        let fewerBooks =
            removeBook (mbk |> Option.get) bks

        addItem newBook fewerBooks
    else
        bks
