module total.BorrowerTests

open Xunit
open FsUnit.Xunit
open total.Borrower

[<Fact>]
let ``These are from Borrower`` () =
    let res = eatAdd 66 66
    res |> should equal 132

[<Fact>]
let ``This one from Borrower too`` () =
    let res2 = eatSubtract 99 9
    res2 |> should equal 90
