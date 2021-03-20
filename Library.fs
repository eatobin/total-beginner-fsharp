module total.Library

let addItem x xs =
    if List.contains x xs then xs else x :: xs
