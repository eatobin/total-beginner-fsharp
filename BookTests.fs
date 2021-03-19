module total.BookTests

open Xunit
open FsUnit.Xunit

let jsonStringBk1: Book.JsonString =
    "{\"title\":\"Title1\",\"author\":\"Author1\",\"borrower\":null}"

let jsonStringBk2: Book.JsonString =
    "{\"title\":\"Title1\",\"author\":\"Author1\",\"borrower\":{\"name\":\"Borrower2\",\"maxBooks\":2}}"

let br2 =
    { Borrower.name = "Borrower2"
      Borrower.maxBooks = 2 }

let bk1 = Book.jsonStringToBook (jsonStringBk1)
let bk2 = Book.setBorrower (Some(br2)) bk1

let bk3 =
    { Book.defaultBook with
          title = "Title3"
          author = "Author3" }

[<Fact>]
let ``A Book should have a title`` () =
    Book.getTitle bk1 |> should equal "Title1"

[<Fact>]
let ``A Book should have an author`` () =
    Book.getAuthor bk1 |> should equal "Author1"

[<Fact>]
let ``A Book could not have an borrower`` () = Book.getBorrower bk1 |> should be null

[<Fact>]
let ``A Book could have a borrower`` () =
    Book.getBorrower bk2
    |> Option.get
    |> should equal br2

[<Fact>]
let ``A default Book should not have a borrower`` () = Book.getBorrower bk3 |> should be null

[<Fact>]
let ``A book should return a string "Title1 by Author1; Available"`` () =
    Book.toString bk1
    |> should equal "Title1 by Author1; Available"

[<Fact>]
let ``A book should return a string "Title1 by Author1; Checked out to Borrower2"`` () =
    Book.toString bk2
    |> should equal "Title1 by Author1; Checked out to Borrower2"

[<Fact>]
let ``A book without borrower should convert from JSON`` () =
    Book.jsonStringToBook jsonStringBk1
    |> should equal bk1

[<Fact>]
let ``A book with borrower should convert from JSON`` () =
    Book.jsonStringToBook jsonStringBk2
    |> should equal bk2

[<Fact>]
let ``A book without borrower should convert to JSON`` () =
    Book.bookToJsonString bk1
    |> should equal jsonStringBk1

[<Fact>]
let ``A book with borrower should convert to JSON`` () =
    Book.bookToJsonString bk2
    |> should equal jsonStringBk2
