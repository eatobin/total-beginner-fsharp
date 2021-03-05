module total.Book

open total.Borrower

type InBook = { title: string; author: string }

type OutBook =
    { title: string
      author: string
      borrower: Borrower }

type Book =
    | InBook
    | OutBook
