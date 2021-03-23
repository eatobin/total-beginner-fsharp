module total.BorrowerTests

open Xunit
open FsUnit.Xunit

let jsonStringBr: Borrower.JsonString =
    "{\"name\":\"Borrower1\",\"maxBooks\":1}"

let wonkyBr: Borrower.JsonString =
    "{\"wonky\":\"Borrower1\",\"maxBooks\":1}"

let br1: Result<Borrower.Borrower, string> =
    Borrower.jsonStringToBorrower jsonStringBr

let brWonky: Result<Borrower.Borrower, string> = Borrower.jsonStringToBorrower wonkyBr

[<Fact>]
let ``getName test - br1`` () =
    match br1 with
    | Ok br -> Borrower.getName br |> should equal "Borrower1"
    | Error e ->
        e
        |> should equal "Error at: `$.name`
Expecting a string but instead got: null"

[<Fact>]
let ``getName test - brWonky`` () =
    match brWonky with
    | Ok br -> Borrower.getName br |> should equal "Borrower1"
    | Error e ->
        e
        |> should equal "Error at: `$.name`
Expecting a string but instead got: null"

//[<Fact>]
//let ``getMaxBooks test`` () =
//    Borrower.getMaxBooks br1 |> should equal 1
//
//[<Fact>]
//let ``setName test`` () =
//    Borrower.setName "Jack" br1
//    |> should
//        equal
//           { Borrower.name = "Jack"
//             Borrower.maxBooks = 1 }
//
//[<Fact>]
//let ``setMaxBooks test`` () =
//    Borrower.setMaxBooks 11 br1
//    |> should
//        equal
//           { Borrower.name = "Borrower1"
//             Borrower.maxBooks = 11 }
//
//[<Fact>]
//let ``borrowerToString test`` () =
//    Borrower.toString br1
//    |> should equal "Borrower1 (1 books)"
//
//[<Fact>]
//let ``borrowerToJSONString test`` () =
//    Borrower.borrowerToJsonString br1
//    |> should equal jsonStringBr
