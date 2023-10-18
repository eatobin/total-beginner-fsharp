module total.Library

type Borrower = { name: string; maxBooks: int }

type BookIn = { title: string; author: string }

type BookOut =
    { title: string
      author: string
      borrower: Borrower }

let createBorrower (nameP: string) (maxBooksP: int) : Borrower = { name = nameP; maxBooks = maxBooksP }

let createBook (titleP: string) (authorP: string) : BookIn = { title = titleP; author = authorP }

let borrowerToString (br: Borrower) : string = $"%s{br.name} (%d{br.maxBooks} books)"

let checkOutBookIn (br: Borrower) (bkIn: BookIn) : BookOut =
    { title = bkIn.title
      author = bkIn.author
      borrower = br }

let bookOutToString (bkOut: BookOut) : string =
    $"%s{bkOut.title} by %s{bkOut.author}; Checked out to %s{bkOut.borrower.name}"

let bookInToString (bkIn: BookIn) : string =
    $"%s{bkIn.title} by %s{bkIn.author}; Available"





// let bookToString (bk: Book) : string =
//     match bk with
//     | BookOut bkOut -> $"%s{bkOut.title} by %s{bkOut.author}; Checked out to %s{bkOut.borrower.name}"
//     | BookIn bkIn -> $"%s{bkIn.title} by %s{bkIn.author}; Available"
//
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
