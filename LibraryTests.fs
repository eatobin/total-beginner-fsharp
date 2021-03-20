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

[<Fact>]
let ``A Library should add a Borrower or Book correctly - 1`` () =
    Library.addItem br3 brs1 |> should equal brs2
[<Fact>]
let ``A Library should add a Borrower or Book correctly - 2`` () =
    Library.addItem br2 brs1 |> should equal brs1
