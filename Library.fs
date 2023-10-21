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

let bookFromBookIn (bkIn: BookIn) : Book = Book.BookIn bkIn

let bookFromBookOut (bkOut: BookOut) : Book = Book.BookOut bkOut

let makeBookList (bksIn: BookIn list) (bksOut: BookOut list) : Book list =
    let bksFromIn: Book list = List.map bookFromBookIn bksIn
    let bksFromOut: Book list = List.map bookFromBookOut bksOut
    List.append bksFromIn bksFromOut

let findBorrower (name: string) (brs: Borrower list) : Borrower option =
    brs |> List.filter (fun br -> getName br = name) |> List.tryHead

let findBookIn (title: string) (bks: Book list) : BookIn option =
    bks
    |> List.filter (fun bk -> getTitleBook bk = title)
    |> List.choose (fun bk ->
        match bk with
        | Book.BookIn bkIn -> Some bkIn
        | Book.BookOut _ -> None)
    |> List.tryHead

let findBookOut (title: string) (bks: Book list) : BookOut option =
    bks
    |> List.filter (fun bk -> getTitleBook bk = title)
    |> List.choose (fun bk ->
        match bk with
        | Book.BookIn _ -> None
        | Book.BookOut bkOut -> Some bkOut)
    |> List.tryHead

let getBooksOutForBorrower (br: Borrower) (bksOut: BookOut list) : BookOut list =
    List.filter (fun bkOut -> bkOut.borrower = br) bksOut

let numBooksOut br bksOut =
    getBooksOutForBorrower br bksOut |> List.length

let notMaxedOut br bksOut = numBooksOut br bksOut < br.maxBooks

let removeBook (bk: Book) (bks: Book list) : Book list = List.filter (fun b -> b <> bk) bks

let checkOutBookIn (n: string) (t: string) (brs: Borrower list) (bks: Book list) : Book list option =
    let maybeBookIn: BookIn option = findBookIn t bks
    let maybeBookOut: BookOut option = findBookOut t bks
    let maybeBorrower: Borrower option = findBorrower n brs
    let bksOut: BookOut list = makeBookOutList bks

    if
        maybeBookIn |> Option.isSome
        && maybeBookOut |> Option.isNone
        && maybeBorrower |> Option.isSome
        && notMaxedOut (maybeBorrower |> Option.get) bksOut
    then
        let newBook: Book =
            addBorrowerToBookIn (maybeBorrower |> Option.get) (maybeBookIn |> Option.get)
            |> bookFromBookOut

        let oldBook: Book = maybeBookIn |> Option.get |> bookFromBookIn
        let fewerBooks: Book list = removeBook oldBook bks
        Some(newBook :: fewerBooks)
    else
        None

let br1: Borrower =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 11 }

let bk1In: BookIn =
    { BookIn.title = "Title1In"
      BookIn.author = "Author1In" }

let bk2In: BookIn =
    { BookIn.title = "Title2In"
      BookIn.author = "Author2In" }

let bk2Out: BookOut =
    { BookOut.title = "Title2Out"
      BookOut.author = "Author2Out"
      BookOut.borrower = br1 }

let bk1: Book = bookFromBookIn bk1In
let bk2: Book = bookFromBookOut bk2Out
let bk3: Book = bookFromBookIn bk2In
let brs: Borrower list = [ br1 ]
let bks: Book list = [ bk1; bk2 ]
let bks2: Book list = [ bk3 ]
let bksIn: BookIn list = makeBookInList bks
let bksOut: BookOut list = makeBookOutList bks
let newBks: Book list = makeBookList bksIn bksOut
let maybeBorrowerPass: Borrower option = findBorrower "Borrower1" brs
let maybeBorrowerFail: Borrower option = findBorrower "Nope" brs
let maybeBookInPass: BookIn option = findBookIn "Title1" newBks
let maybeBookInFailIsOut: BookIn option = findBookIn "Title2" newBks
let maybeBookInFailIsNone: BookIn option = findBookIn "Nope" newBks
let maybeBookOutPass: BookOut option = findBookOut "Title2" newBks
let maybeBookOutFailIsIn: BookOut option = findBookOut "Title1" newBks
let maybeBookOutFailIsNone: BookOut option = findBookOut "Nope" newBks
let fewerBk1: Book list = removeBook bk1 newBks
let fewerBk2: Book list = removeBook bk2 newBks

let bk2InCheckedOut: Book list option =
    checkOutBookIn "Borrower1" "Title2In" brs bks2







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
