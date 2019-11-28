module Punk

open Fable.Core

type IPathModule =
    abstract basename: string -> string

[<ImportDefault("path")>]
let pathModule: IPathModule = jsNative

printfn "%s" (pathModule.basename "/foo/bar/baz/myfile.html")

printfn "%i" (3 + 4)
