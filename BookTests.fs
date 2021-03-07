module total.BookTests

open Xunit
open FsUnit.Xunit
open total.Borrower
open total.Book

let jsonStringBk1: JsonString =
    "{\"title\":\"Title1\",\"author\":\"Author1\",\"borrower\":null}"

let jsonStringBk2: JsonString =
    "{\"title\":\"Title1\",\"author\":\"Author1\",\"borrower\":{\"name\":\"Borrower2\",\"maxBooks\":2}}"

let br2 = { name = "Borrower2"; maxBooks = 2 }
let bk1 = bookJsonStringToBook (jsonStringBk1)
let bk2 = setMaybeBorrower bk1 (Some(br2))

let bk3 =
    { defaultBook with
          title = "Title3"
          author = "Author3" }

[<Fact>]
let ``A Book should have a title`` () = getTitle bk1 |> should equal "Title1"

[<Fact>]
let ``A Book should have an author`` () = getAuthor bk1 |> should equal "Author1"

[<Fact>]
let ``A Book could not have an borrower`` () = getMaybeBorrower bk1 |> should be null

[<Fact>]
let ``A Book could have a borrower`` () =
    getMaybeBorrower bk2
    |> Option.get
    |> should equal br2

[<Fact>]
let ``A default Book should not have a borrower`` () = getMaybeBorrower bk3 |> should be null

[<Fact>]
let ``A book return a string "Title1 by Author1; Available"`` () = toString bk1 |> should equal "Title1 by Author1; Available"


//  it should "return a string \"Title1 by Author1; Checked out to Borrower2\"" in {
//    assert(bookToString(bk2) == "Title1 by Author1; Checked out to Borrower2")
//  }
//
//  it should "convert from JSON" in {
//    val bkJson1: Either[Error, Book] = bookJsonStringToBook(jsonStringBk1)
//    assert(bkJson1 == Right(bk1))
//    val bkJson2: Either[Error, Book] = bookJsonStringToBook(jsonStringBk2)
//    assert(bkJson2 == Right(bk2))
//  }
//
//  it should "turn a Book into a JSON string" in {
//    assert(bookToJsonString(bk1) == jsonStringBk1)
//  }
//
//}
