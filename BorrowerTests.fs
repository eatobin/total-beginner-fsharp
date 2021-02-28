module total.BorrowerTests

open Xunit
open FsUnit.Xunit
open total.Borrower

let jsonStringBr: string =
    "{\"name\":\"Borrower1\",\"maxBooks\":1}"

let br1: Borrower =
    borrowerJsonStringToBorrower (jsonStringBr)

[<Fact>]
let ``getName test`` () = getName br1 |> should equal "Borrower1"

[<Fact>]
let ``getMaxBooks test`` () = getMaxBooks br1 |> should equal 1

[<Fact>]
let ``setName test`` () =
    setName br1 "Jack"
    |> should equal { Name = "Jack"; MaxBooks = 1 }

[<Fact>]
let ``setMaxBooks test`` () =
    setMaxBooks br1 11
    |> should equal { Name = "Borrower1"; MaxBooks = 11 }

[<Fact>]
let ``borrowerToString test`` () =
    borrowerToString br1
    |> should equal "Borrower1 (1 books)"
