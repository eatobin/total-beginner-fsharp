module total.BorrowerTests

open Xunit
open FsUnit.Xunit

open Borrower

let br1: Borrower =
    { Borrower.name = "Borrower1"
      Borrower.maxBooks = 1 }

[<Fact>]
let ``getName test - br1`` () = getName br1 |> should equal "Borrower1"

[<Fact>]
let ``getMaxBooks test - br1`` () = getMaxBooks br1 |> should equal 1

[<Fact>]
let ``setName test - br1`` () =
    setName "Jack" br1
    |> should
        equal
        { Borrower.name = "Jack"
          Borrower.maxBooks = 1 }

[<Fact>]
let ``setMaxBooks test - br1`` () =
    setMaxBooks 11 br1
    |> should
        equal
        { Borrower.name = "Borrower1"
          Borrower.maxBooks = 11 }

[<Fact>]
let ``toString test - br1`` () =
    toString br1 |> should equal "Borrower1 (1 books)"
