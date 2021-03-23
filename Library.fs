module total.Library

let addItem x xs =
    if List.contains x xs then xs else x :: xs

let removeBook bk bks = List.filter (fun b -> b <> bk) bks

let findItem (tgt: string) (coll: 'a list) (f: ('a -> string)): 'a option =
    let res =
        (List.filter (fun item -> f (item) = tgt) coll)

    if res.IsEmpty then None else Some(res.Head)
