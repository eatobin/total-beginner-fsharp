module total.EricTests

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``These are from Eric`` () =
    let res = 4 + 4
    res |> should equal 8
    17 |> should equal 17
    1 |> should not' (equal 11)
    "ships" |> should startWith "shi"

[<Fact>]
let ``This one too`` () = [ 9 ] |> should not' (be Empty)
