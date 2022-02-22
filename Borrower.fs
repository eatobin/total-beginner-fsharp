module total.Borrower

type Borrower = { name: string; maxBooks: int }

let getName (br: Borrower) : string = br.name

let setName (n: string) (br: Borrower) : Borrower = { br with name = n }

let getMaxBooks (br: Borrower) : int = br.maxBooks

let setMaxBooks (mb: int) (br: Borrower) : Borrower = { br with maxBooks = mb }

let toString (br: Borrower) : string =
    $"%s{getName br} (%i{getMaxBooks br} books)"
