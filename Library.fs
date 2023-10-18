module total.Library

type Borrower = { name: string; maxBooks: int }

type BookIn = { title: string; author: string }

type BookOut =
    { title: string
      author: string
      borrower: Borrower }

// let booksOut: BookOut list = []
//
// let booksIn: BookIn list = []

let createBorrower (nameP: string) (maxBooksP: int) : Borrower = { name = nameP; maxBooks = maxBooksP }

let createBookIn (titleP: string) (authorP: string) : BookIn = { title = titleP; author = authorP }

let borrowerToString (br: Borrower) : string = $"%s{br.name} (%d{br.maxBooks} books)"

let addBorrowerToBookIn (br: Borrower) (bkIn: BookIn) : BookOut =
    { title = bkIn.title
      author = bkIn.author
      borrower = br }

let bookOutToString (bkOut: BookOut) : string =
    $"%s{bkOut.title} by %s{bkOut.author}; Checked out to %s{bkOut.borrower.name}"

let bookInToString (bkIn: BookIn) : string =
    $"%s{bkIn.title} by %s{bkIn.author}; Available"

let getName (br: Borrower) : string = br.name
let getTitleBookIn (bkIn: BookIn) : string = bkIn.title
let getTitleBookOut (bkOut: BookOut) : string = bkOut.title


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
let findItem (tgt: string) (coll: 'a list) (f: 'a -> string) : 'a option =
    let res = List.filter (fun item -> f item = tgt) coll
    if res.IsEmpty then None else Some(res.Head)

let getBooksOutForBorrower (br: Borrower) (bksOut: BookOut list) : BookOut list =
    List.filter (fun bkOut -> bkOut.borrower = br) bksOut

let numBooksOut br bksOut =
    getBooksOutForBorrower br bksOut |> List.length

let notMaxedOut br bksOut = numBooksOut br bksOut < br.maxBooks

let checkOutBookIn
    (n: string)
    (t: string)
    (brs: Borrower list)
    (bksIn: BookIn list)
    (bksOut: BookOut list)
    : BookOut list =
    let maybeBookIn = findItem t bksIn getTitleBookIn
    let maybeBookOut = findItem t bksOut getTitleBookOut
    let maybeBorrower = findItem n brs getName

    if
        maybeBookIn |> Option.isSome
        && maybeBookOut |> Option.isNone
        && maybeBorrower |> Option.isSome
        && notMaxedOut (maybeBorrower |> Option.get) bksOut
    then
        let newBookOut =
            addBorrowerToBookIn (maybeBorrower |> Option.get) (maybeBookIn |> Option.get)

        newBookOut :: bksOut
    else
        bksOut
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
