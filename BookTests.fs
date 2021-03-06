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

//  "A Book" should "create itself properly" in {
//    assert(getTitle(bk1) == "Title1")
//    assert(getAuthor(bk1) == "Author1")
//    assert(getBorrower(bk1).isEmpty)
//    assert(getBorrower(bk2).contains(br2))
//    assert(getBorrower(bk3).isEmpty)
//  }
//
//  it should "return a string \"Title1 by Author1; Available\"" in {
//    assert(bookToString(bk1) == "Title1 by Author1; Available")
//  }
//
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
