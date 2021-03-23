module total.Borrower

open Thoth.Json.Net

type Borrower = { name: string; maxBooks: int }

//    static member Decoder: Decoder<Borrower> =
//        Decode.map2 (fun n mb -> { name = n; maxBooks = mb }: Borrower) (Decode.field "n" Decode.string)
//            (Decode.field "mb" Decode.int)


//type Point =
//    { X : int
//      Y : int }
//
//    static member Decoder : Decoder<Point> =
//        Decode.map2 (fun x y ->
//                { X = x
//                  Y = y } : Point)
//             (Decode.field "x" Decode.int)
//             (Decode.field "y" Decode.int)

//> Decode.fromString Point.Decoder """{"x": 10, "y": 21}"""
//val it : Result<Point, string> = Ok { X = 10; Y = 21 }





type JsonString = string
//
let getName (br: Borrower): string = br.name
//
//let setName (n: string) (br: Borrower): Borrower = { br with name = n }
//
//let getMaxBooks (br: Borrower): int = br.maxBooks
//
//let setMaxBooks (mb: int) (br: Borrower): Borrower = { br with maxBooks = mb }
//
//let toString (br: Borrower): string =
//    sprintf "%s (%i books)" (getName br) (getMaxBooks br)
//
let jsonStringToBorrower (borrowerString: JsonString): Result<Borrower, string> =
    //    Decode.fromString Borrower.Decoder borrowerString
    Decode.Auto.fromString<Borrower> (borrowerString)
//let borrowerToJsonString (br: Borrower): JsonString = Json.serializeU br
