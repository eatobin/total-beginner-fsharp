module total.BorrowerTests

open Xunit
open FsUnit.Xunit
open total.Borrower

let br1 = makeBorrower "Borrower1" 1

[<Fact>]
let ``getName test`` () = getName br1 |> should equal "Borrower1"

[<Fact>]
let ``getMaxBooks test`` () = getMaxBooks br1 |> should equal 1

[<Fact>]
let ``setName test`` () =
    setName br1 "Jack"
    |> should equal { name = "Jack"; maxBooks = 1 }

[<Fact>]
let ``setMaxBooks test`` () =
    setMaxBooks br1 11
    |> should equal { name = "Borrower1"; maxBooks = 11 }
