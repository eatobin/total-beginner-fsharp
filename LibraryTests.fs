module total.LibraryTests
//
//open Xunit
//open FsUnit.Xunit
//
//let br1 =
//    { Borrower.name = "Borrower1"
//      Borrower.maxBooks = 1 }
//
//let br2 =
//    { Borrower.name = "Borrower2"
//      Borrower.maxBooks = 2 }
//
//let br3 =
//    { Borrower.name = "Borrower3"
//      Borrower.maxBooks = 3 }
//
//let brs1 = [ br1; br2 ]
//let brs2 = [ br3; br1; br2 ]
//
//let bk1 =
//    { Book.title = "Title1"
//      Book.author = "Author1"
//      Book.borrower = Some(br1) }
//
//let bk2 =
//    { Book.title = "Title2"
//      Book.author = "Author2"
//      Book.borrower = None }
//
//let bk3 =
//    { Book.title = "Title3"
//      Book.author = "Author3"
//      Book.borrower = Some(br3) }
//
//let bks1 = [ bk1; bk2 ]
//let bks2 = [ bk3; bk1; bk2 ]
//
//[<Fact>]
//let ``A Library should add a Borrower or Book correctly - 1`` () =
//    Library.addItem br3 brs1 |> should equal brs2
//
//[<Fact>]
//let ``A Library should add a Borrower or Book correctly - 2`` () =
//    Library.addItem br2 brs1 |> should equal brs1
//
//[<Fact>]
//let ``A Library should add a Borrower or Book correctly - 3`` () =
//    Library.addItem bk3 bks1 |> should equal bks2
//
//[<Fact>]
//let ``A Library should add a Borrower or Book correctly - 4`` () =
//    Library.addItem bk2 bks1 |> should equal bks1
//
//[<Fact>]
//let ``A Library should remove a Book correctly - 1`` () =
//    Library.removeBook bk3 bks2 |> should equal bks1
//
//[<Fact>]
//let ``A Library should remove a Book correctly - 2`` () =
//    Library.removeBook bk3 bks1 |> should equal bks1
