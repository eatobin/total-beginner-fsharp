module total.Library

type Borrower = { name: string; maxBooks: int }

type BookIn = { title: string; author: string }

type BookOut =
    { title: string
      author: string
      borrower: Borrower }

[<RequireQualifiedAccess>]
type Book =
    | BookIn of BookIn
    | BookOut of BookOut

let createBorrower (nameP: string) (maxBooksP: int) : Borrower = { name = nameP; maxBooks = maxBooksP }

let createBookIn (titleP: string) (authorP: string) : BookIn = { title = titleP; author = authorP }

let borrowerToString (br: Borrower) : string = $"%s{br.name} (%d{br.maxBooks} books)"

let addBorrowerToBookIn (br: Borrower) (bkIn: BookIn) : BookOut =
    { title = bkIn.title
      author = bkIn.author
      borrower = br }

let removeBorrowerFromBookOut (bkOut: BookOut) : BookIn =
    { title = bkOut.title
      author = bkOut.author }

let bookToString (bk: Book) : string =
    match bk with
    | Book.BookIn bkIn -> $"%s{bkIn.title} by %s{bkIn.author}; Available"
    | Book.BookOut bkOut -> $"%s{bkOut.title} by %s{bkOut.author}; Checked out to %s{bkOut.borrower.name}"

let getName (br: Borrower) : string = br.name

let getTitleBookIn (bkIn: BookIn) : string = bkIn.title

let getTitleBookOut (bkOut: BookOut) : string = bkOut.title

let getTitleBook (bk: Book) : string =
    match bk with
    | Book.BookIn bkIn -> bkIn.title
    | Book.BookOut bkOut -> bkOut.title

let makeBookInList (bks: Book list) : BookIn list =
    bks
    |> List.choose (fun bk ->
        match bk with
        | Book.BookIn bkIn -> Some bkIn
        | Book.BookOut _ -> None)

let makeBookOutList (bks: Book list) : BookOut list =
    bks
    |> List.choose (fun bk ->
        match bk with
        | Book.BookIn _ -> None
        | Book.BookOut bkOut -> Some bkOut)

let br1: Borrower =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 1 }

let bk1In: BookIn =
    { BookIn.title = "Title1"
      BookIn.author = "Author1" }

let bk2Out: BookOut =
    { BookOut.title = "Title1"
      BookOut.author = "Author1"
      BookOut.borrower = br1 }

let bk1: Book = Book.BookIn bk1In
let bk2: Book = Book.BookOut bk2Out

let bookFromBookIn (bkIn: BookIn) : Book = Book.BookIn bkIn

let bookFromBookOut (bkOut: BookOut) : Book = Book.BookOut bkOut

let bks: Book list = [ bk1; bk2 ]

let findItem (tgt: string) (coll: 'a list) (f: 'a -> string) : 'a option =
    let res = List.filter (fun item -> f item = tgt) coll
    if res.IsEmpty then None else Some(res.Head)

let getBooksOutForBorrower (br: Borrower) (bksOut: BookOut list) : BookOut list =
    List.filter (fun bkOut -> bkOut.borrower = br) bksOut

let numBooksOut br bksOut =
    getBooksOutForBorrower br bksOut |> List.length

let notMaxedOut br bksOut = numBooksOut br bksOut < br.maxBooks

// let checkOutBookIn (n: string) (t: string) (brs: Borrower list) (bks: Book list) : BookOut list =
//     let bksIn: BookIn list = makeBookInList bks
//     let bksOut: BookOut list = makeBookOutList bks
//     let maybeBookIn: BookIn option = findItem t bksIn getTitleBookIn
//     let maybeBookOut: BookOut option = findItem t bksOut getTitleBookOut
//     let maybeBorrower: Borrower option = findItem n brs getName
//
//     if
//         maybeBookIn |> Option.isSome
//         && maybeBookOut |> Option.isNone
//         && maybeBorrower |> Option.isSome
//         && notMaxedOut (maybeBorrower |> Option.get) bksOut
//     then
//         let newBookOut =
//             addBorrowerToBookIn (maybeBorrower |> Option.get) (maybeBookIn |> Option.get)
//
//         newBookOut :: bksOut
//     else
//         bksOut

// let checkInBookOut
//     (n: string)
//     (t: string)
//     (brs: Borrower list)
//     (bksIn: BookIn list)
//     (bksOut: BookOut list)
//     : BookIn list =
//     let maybeBookIn = findItem t bksIn getTitleBookIn
//     let maybeBookOut = findItem t bksOut getTitleBookOut
//     let maybeBorrower = findItem n brs getName
//
//     if
//         maybeBookIn |> Option.isNone
//         && maybeBookOut |> Option.isSome
//         && maybeBorrower |> Option.isSome
//     then
//         let newBookIn = removeBorrowerFromBookOut (maybeBookOut |> Option.get)
//
//         newBookIn :: bksIn
//     else
//         bksIn
