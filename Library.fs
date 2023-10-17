module total.Library

type Borrower = { name: string; maxBooks: int }

type Book =
    | BookIn of title: string * author: string
    | BookOut of title: string * author: string * borrower: Borrower

let setName (n: string) (br: Borrower) : Borrower = { br with name = n }

let setMaxBooks (mb: int) (br: Borrower) : Borrower = { br with maxBooks = mb }

let borrowerToString (br: Borrower) : string = $"%s{br.name} (%d{br.maxBooks} books)"

let getBorrower (bkOut: Book) : Borrower =
    match bkOut with
    | BookOut(_, _, br) -> br
    | bookIn -> failwithf $"%A{bookIn} has no borrower"

let setBorrower (br: Borrower) (bkIn: Book) : Book =
    match bkIn with
    | BookIn(t, a) -> BookOut(title = t, author = a, borrower = br)
    | bookOut -> failwithf $"%A{bookOut} already has a borrower"

// let private availableString bk =
//     match (getBorrower bk) with
//     | Some br -> $"Checked out to %s{getName br}"
//     | None -> "Available"
//
// let toString bk =
//     $"%s{getTitle bk} by %s{getAuthor bk}; %s{availableString bk}"






// let addItem x xs =
//     if List.contains x xs then xs else x :: xs
//
// let removeBook bk bks = List.filter (fun b -> b <> bk) bks
//
// let findItem (tgt: string) (coll: 'a list) (f: 'a -> string) : 'a option =
//     let res = List.filter (fun item -> f item = tgt) coll
//
//     if res.IsEmpty then None else Some(res.Head)
//
// let getBooksForBorrower (br: Borrower) (bks: Book list) : Book list =
//     List.filter (fun bk -> Option.contains br (getBorrower bk)) bks
//
// let numBooksOut br bks =
//     getBooksForBorrower br bks |> List.length
//
// let notMaxedOut br bks = numBooksOut br bks < getMaxBooks br
//
// let bookNotOut bk = getBorrower bk |> Option.isNone
//
// let bookOut bk = getBorrower bk |> Option.isSome
//
// let checkOut (n: string) (t: string) (brs: Borrower list) (bks: Book list) : Book list =
//     let mbk = findItem t bks getTitle
//     let mbr = findItem n brs getName
//
//     if
//         mbk |> Option.isSome
//         && mbr |> Option.isSome
//         && notMaxedOut (mbr |> Option.get) bks
//         && bookNotOut (mbk |> Option.get)
//     then
//         let newBook = setBorrower mbr (mbk |> Option.get)
//         let fewerBooks = removeBook (mbk |> Option.get) bks
//         addItem newBook fewerBooks
//     else
//         bks
//
// let checkIn (t: string) (bks: Book list) : Book list =
//     let mbk = findItem t bks getTitle
//
//     if mbk |> Option.isSome && bookOut (mbk |> Option.get) then
//         let newBook = setBorrower None (mbk |> Option.get)
//         let fewerBooks = removeBook (mbk |> Option.get) bks
//         addItem newBook fewerBooks
//     else
//         bks
