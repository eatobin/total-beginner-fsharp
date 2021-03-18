module total.BorrowerTests

open Xunit
open FsUnit.Xunit
open total.Borrower

let jsonStringBr: JsonString =
    "{\"name\":\"Borrower1\",\"maxBooks\":1}"

let br1: Borrower =
    borrowerJsonStringToBorrower jsonStringBr

[<Fact>]
let ``getName test`` () = getName br1 |> should equal "Borrower1"

[<Fact>]
let ``getMaxBooks test`` () = getMaxBooks br1 |> should equal 1

[<Fact>]
let ``setName test`` () =
    setName "Jack" br1
    |> should equal { name = "Jack"; maxBooks = 1 }

[<Fact>]
let ``setMaxBooks test`` () =
    setMaxBooks 11 br1
    |> should equal { name = "Borrower1"; maxBooks = 11 }

[<Fact>]
let ``borrowerToString test`` () =
    toString br1 |> should equal "Borrower1 (1 books)"

[<Fact>]
let ``borrowerToJSONString test`` () =
    borrowerToJsonString br1
    |> should equal jsonStringBr
