module total.MathStuffTests

open Xunit
open FsUnit.Xunit
open total.MathStuff

[<Fact>]
let ``These are from MathStuff`` () =
    let res = eatAdd 66 66
    res |> should equal 132

[<Fact>]
let ``This one too`` () =
    let res2 = eatSubtract 99 9
    res2 |> should equal 90
