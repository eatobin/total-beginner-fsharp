module total.LibraryTests

open Xunit
open FsUnit.Xunit

open Library



let br2 =
    { Borrower.name = "Borrower2"
      Borrower.maxBooks = 2 }

let br3 =
    { Borrower.name = "Borrower3"
      Borrower.maxBooks = 3 }

let brs1 = [ br1; br2 ]
let brs2 = [ br3; br1; br2 ]

let bk1In: BookIn =
    { BookIn.title = "Title1"
      BookIn.author = "Author1" }

let bk1Out: BookOut =
    { BookOut.title = "Title1"
      BookOut.author = "Author1"
      BookOut.borrower = br1 }

let bk2: BookIn =
    { BookIn.title = "Title2"
      BookIn.author = "Author2" }

let bk3: BookOut =
    { BookOut.title = "Title3"
      BookOut.author = "Author3"
      BookOut.borrower = br3 }

let bk4: BookOut =
    { BookOut.title = "Title4"
      BookOut.author = "Author4"
      BookOut.borrower =
        { Borrower.name = "Borrower3"
          Borrower.maxBooks = 3 } }

let bk5: BookOut =
    { BookOut.title = "Title2"
      BookOut.author = "Author2"
      BookOut.borrower =
        { Borrower.name = "Borrower2"
          Borrower.maxBooks = 2 } }

let bksIn1: BookIn list = [ bk1In ]
let bksOut1: BookOut list = [ bk1Out ]
// let bksOut2: Book list = [ bk1Out; bk2 ]








let br1: Borrower =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 11 }

// let bk1In: BookIn =
//     { BookIn.title = "Title1In"
//       BookIn.author = "Author1In" }
//
// let bk2In: BookIn =
//     { BookIn.title = "Title2In"
//       BookIn.author = "Author2In" }
//
// let bk2Out: BookOut =
//     { BookOut.title = "Title2Out"
//       BookOut.author = "Author2Out"
//       BookOut.borrower = br1 }
//
// let bk1: Book = bookFromBookIn bk1In
// let bk2: Book = bookFromBookOut bk2Out
// let bk3: Book = bookFromBookIn bk2In
// let brs: Borrower list = [ br1 ]
// let bks: Book list = [ bk1; bk2 ]
// let bks2: Book list = [ bk3 ]
// let bks3: Book list = [ bk2 ]
// let bksIn: BookIn list = makeBookInList bks
// let bksOut: BookOut list = makeBookOutList bks
// let newBks: Book list = makeBookList bksIn bksOut
// let maybeBorrowerPass: Borrower option = findBorrower "Borrower1" brs
// let maybeBorrowerFail: Borrower option = findBorrower "Nope" brs
// let maybeBookInPass: BookIn option = findBookIn "Title1" newBks
// let maybeBookInFailIsOut: BookIn option = findBookIn "Title2" newBks
// let maybeBookInFailIsNone: BookIn option = findBookIn "Nope" newBks
// let maybeBookOutPass: BookOut option = findBookOut "Title2" newBks
// let maybeBookOutFailIsIn: BookOut option = findBookOut "Title1" newBks
// let maybeBookOutFailIsNone: BookOut option = findBookOut "Nope" newBks
// let fewerBk1: Book list = removeBook bk1 newBks
// let fewerBk2: Book list = removeBook bk2 newBks
// let bk2InCheckOut: Book list option = checkOutBookIn "Borrower1" "Title2In" brs bks2
// let bk2OutCheckIn: Book list option = checkInBookOut "Title2Out" bks3














//
// [<Fact>]
// let ``A Library should add a Borrower or Book correctly - 2`` () =
//     Library.addItem br2 brs1 |> should equal brs1
//
// [<Fact>]
// let ``A Library should add a Borrower or Book correctly - 3`` () =
//     Library.addItem bk3 bks1 |> should equal bks2
//
// [<Fact>]
// let ``A Library should add a Borrower or Book correctly - 4`` () =
//     Library.addItem bk2 bks1 |> should equal bks1
//
// [<Fact>]
// let ``A Library should remove a Book correctly - 1`` () =
//     Library.removeBook bk3 bks2 |> should equal bks1
//
// [<Fact>]
// let ``A Library should remove a Book correctly - 2`` () =
//     Library.removeBook bk3 bks1 |> should equal bks1
//
// [<Fact>]
// let ``A Library should find a Book or Borrower correctly - 1`` () =
//     findItem "Title1" bksOut1 getTitleBookOut |> Option.get |> should equal bk1Out
//
// [<Fact>]
// let ``A Library should find a Book or Borrower correctly - 2`` () =
//     findItem "Title11" bksOut1 getTitleBookOut |> should equal None
//
// [<Fact>]
// let ``A Library should find a Book or Borrower correctly - 3`` () =
//     findItem "Borrower1" brs2 getName |> Option.get |> should equal br1
//
// [<Fact>]
// let ``A Library should find a Book or Borrower correctly - 4`` () =
//     findItem "Borrower11" brs2 getName |> should equal None

// [<Fact>]
// let ``A Library should find List[Book] for a Borrower - 1`` () =
//     Library.getBooksForBorrower br2 bks1 |> should be Empty
//
// [<Fact>]
// let ``A Library should find List[Book] for a Borrower - 2`` () =
//     Library.getBooksForBorrower br1 bks1 |> should equal [ bk1 ]
//
// [<Fact>]
// let ``A Library should find List[Book] for a Borrower - 3`` () =
//     Library.getBooksForBorrower br3 bks3 |> should equal [ bk3; bk4 ]
//
// [<Fact>]
// let ``A Library should check out a Book correctly - Pass`` () =
//     checkOutBookIn "Borrower2" "Title1" brs1 bks1 |> should equal bks1

// [<Fact>]
// let ``A Library should check out a Book correctly - 2`` () =
//     Library.checkOut "Borrower2" "NoTitle" brs1 bks1 |> should equal bks1
//
// [<Fact>]
// let ``A Library should check out a Book correctly - 3`` () =
//     Library.checkOut "NoName" "Title1" brs1 bks1 |> should equal bks1
//
// [<Fact>]
// let ``A Library should check out a Book correctly - 4`` () =
//     Library.checkOut "Borrower1" "Title2" brs1 bks1 |> should equal bks1
//
// [<Fact>]
// let ``A Library should check out a Book correctly - 5`` () =
//     Library.checkOut "Borrower2" "Title2" brs1 bks1 |> should equal [ bk5; bk1 ]
