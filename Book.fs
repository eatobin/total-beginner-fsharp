module total.Book

type Book =
    { title: string
      author: string
      borrower: Borrower.Borrower option }

let defaultBook =
    { title = ""
      author = ""
      borrower = None }

let getTitle bk = bk.title

let getAuthor bk = bk.author

let getBorrower bk = bk.borrower

let setBorrower br bk = { bk with borrower = br }

let private availableString bk =
    match (getBorrower bk) with
    | Some br -> $"Checked out to %s{Borrower.getName br}"
    | None -> "Available"

let toString bk =
    $"%s{getTitle bk} by %s{getAuthor bk}; %s{availableString bk}"
