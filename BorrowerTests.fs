module total.BorrowerTests

open Xunit
open FsUnit.Xunit

let br1: Borrower.Borrower =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 1 }

[<Fact>]
let ``getName test - br1`` () =
    Borrower.getName br1 |> should equal "Borrower1"

[<Fact>]
let ``getMaxBooks test - br1`` () =
    Borrower.getMaxBooks br1 |> should equal 1

[<Fact>]
let ``setName test - br1`` () =
    Borrower.setName "Jack" br1
    |> should
        equal
        { Borrower.name = "Jack"
          Borrower.maxBooks = 1 }

[<Fact>]
let ``setMaxBooks test - br1`` () =
    Borrower.setMaxBooks 11 br1
    |> should
        equal
        { Borrower.name = "Borrower1"
          Borrower.maxBooks = 11 }

[<Fact>]
let ``toString test - br1`` () =
    Borrower.toString br1
    |> should equal "Borrower1 (1 books)"
