module total.Library

type BorrowerData = { name: string; maxBooks: int }
type BookData = { title: string; author: string }
type BookIn = BookData
type BookOut = (BookData * BorrowerData)

// type BookStatus =
//     | BookIn of Book
//     | BookOut of (Book * Borrower)

let getName (br: Borrower) : string = br.name

let setName (n: string) (br: Borrower) : Borrower = { br with name = n }

let getMaxBooks (br: Borrower) : int = br.maxBooks

let setMaxBooks (mb: int) (br: Borrower) : Borrower = { br with maxBooks = mb }

let toString (br: Borrower) : string =
    $"%s{getName br} (%i{getMaxBooks br} books)"

let getTitle (bk: Book) : String = bk.title

let getAuthor (bk: Book) : String = bk.author

let getBorrower (bkO: BookOut) : Borrower =
    let (_, br) = br
    br

let setBorrower br bk = { bk with borrower = br }

let private availableString bk =
    match (getBorrower bk) with
    | Some br -> $"Checked out to %s{getName br}"
    | None -> "Available"

let toString bk =
    $"%s{getTitle bk} by %s{getAuthor bk}; %s{availableString bk}"






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
