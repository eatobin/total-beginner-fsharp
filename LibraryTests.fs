module total.LibraryTests

open Xunit
open FsUnit.Xunit

let br1 =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 1 }

let br2 =
    { Borrower.name = "Borrower2"
      Borrower.maxBooks = 2 }

let br3 =
    { Borrower.name = "Borrower3"
      Borrower.maxBooks = 3 }

let brs1 = [ br1; br2 ]
let brs2 = [ br3; br1; br2 ]

let bk1 =
    { Book.title = "Title1"
      Book.author = "Author1"
      Book.borrower = Some(br1) }

let bk2 =
    { Book.title = "Title2"
      Book.author = "Author2"
      Book.borrower = None }

let bk3 =
    { Book.title = "Title3"
      Book.author = "Author3"
      Book.borrower = Some(br3) }

let bk4 =
    { Book.title = "Title4"
      Book.author = "Author4"
      Book.borrower =
          Some
              { Borrower.name = "Borrower3"
                Borrower.maxBooks = 3 } }

let bk5 =
    { Book.title = "Title2"
      Book.author = "Author2"
      Book.borrower =
          Some
              { Borrower.name = "Borrower2"
                Borrower.maxBooks = 2 } }

let bks1 = [ bk1; bk2 ]
let bks2 = [ bk3; bk1; bk2 ]
let bks3 = [ bk1; bk2; bk3; bk4 ]

[<Fact>]
let ``A Library should add a Borrower or Book correctly - 1`` () =
    Library.addItem br3 brs1 |> should equal brs2

[<Fact>]
let ``A Library should add a Borrower or Book correctly - 2`` () =
    Library.addItem br2 brs1 |> should equal brs1

[<Fact>]
let ``A Library should add a Borrower or Book correctly - 3`` () =
    Library.addItem bk3 bks1 |> should equal bks2

[<Fact>]
let ``A Library should add a Borrower or Book correctly - 4`` () =
    Library.addItem bk2 bks1 |> should equal bks1

[<Fact>]
let ``A Library should remove a Book correctly - 1`` () =
    Library.removeBook bk3 bks2 |> should equal bks1

[<Fact>]
let ``A Library should remove a Book correctly - 2`` () =
    Library.removeBook bk3 bks1 |> should equal bks1

[<Fact>]
let ``A Library should find a Book or Borrower correctly - 1`` () =
    Library.findItem "Title1" bks2 Book.getTitle
    |> Option.get
    |> should equal bk1

[<Fact>]
let ``A Library should find a Book or Borrower correctly - 2`` () =
    Library.findItem "Title11" bks2 Book.getTitle
    |> should equal None

[<Fact>]
let ``A Library should find a Book or Borrower correctly - 3`` () =
    Library.findItem "Borrower1" brs2 Borrower.getName
    |> Option.get
    |> should equal br1

[<Fact>]
let ``A Library should find a Book or Borrower correctly - 4`` () =
    Library.findItem "Borrower11" brs2 Borrower.getName
    |> should equal None

[<Fact>]
let ``A Library should find List[Book] for a Borrower - 1`` () =
    Library.getBooksForBorrower br2 bks1
    |> should be Empty

[<Fact>]
let ``A Library should find List[Book] for a Borrower - 2`` () =
    Library.getBooksForBorrower br1 bks1
    |> should equal [ bk1 ]

[<Fact>]
let ``A Library should find List[Book] for a Borrower - 3`` () =
    Library.getBooksForBorrower br3 bks3
    |> should equal [ bk3; bk4 ]

[<Fact>]
let ``A Library should check out a Book correctly - 1`` () =
    Library.checkOut "Borrower2" "Title1" brs1 bks1
    |> should equal bks1

[<Fact>]
let ``A Library should check out a Book correctly - 2`` () =
    Library.checkOut "Borrower2" "NoTitle" brs1 bks1
    |> should equal bks1

[<Fact>]
let ``A Library should check out a Book correctly - 3`` () =
    Library.checkOut "NoName" "Title1" brs1 bks1
    |> should equal bks1

[<Fact>]
let ``A Library should check out a Book correctly - 4`` () =
    Library.checkOut "Borrower1" "Title2" brs1 bks1
    |> should equal bks1

[<Fact>]
let ``A Library should check out a Book correctly - 5`` () =
    Library.checkOut "Borrower2" "Title2" brs1 bks1
    |> should equal [ bk5; bk1 ]
