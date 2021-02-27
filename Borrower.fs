module total.Borrower

type Borrower = { name: string; maxBooks: int }

let makeBorrower n mb = { name = n; maxBooks = mb }

let getName (b: Borrower) = b.name

let setName (b: Borrower) n = { b with name = n }

let getMaxBooks (b: Borrower) = b.maxBooks

let setMaxBooks (b: Borrower) mb = { b with maxBooks = mb }
