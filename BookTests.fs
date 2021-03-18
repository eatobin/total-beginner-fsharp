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
let bk2 = setBorrower (Some(br2)) bk1

let bk3 =
    { defaultBook with
          title = "Title3"
          author = "Author3" }

[<Fact>]
let ``A Book should have a title`` () = getTitle bk1 |> should equal "Title1"

[<Fact>]
let ``A Book should have an author`` () = getAuthor bk1 |> should equal "Author1"

[<Fact>]
let ``A Book could not have an borrower`` () = getBorrower bk1 |> should be null

[<Fact>]
let ``A Book could have a borrower`` () =
    getBorrower bk2 |> Option.get |> should equal br2

[<Fact>]
let ``A default Book should not have a borrower`` () = getBorrower bk3 |> should be null

[<Fact>]
let ``A book should return a string "Title1 by Author1; Available"`` () =
    toString bk1
    |> should equal "Title1 by Author1; Available"

[<Fact>]
let ``A book should return a string "Title1 by Author1; Checked out to Borrower2"`` () =
    toString bk2
    |> should equal "Title1 by Author1; Checked out to Borrower2"

[<Fact>]
let ``A book without borrower should convert from JSON`` () =
    bookJsonStringToBook jsonStringBk1
    |> should equal bk1

[<Fact>]
let ``A book with borrower should convert from JSON`` () =
    bookJsonStringToBook jsonStringBk2
    |> should equal bk2

[<Fact>]
let ``A book without borrower should convert to JSON`` () =
    bookToJsonString bk1 |> should equal jsonStringBk1

[<Fact>]
let ``A book with borrower should convert to JSON`` () =
    bookToJsonString bk2 |> should equal jsonStringBk2
