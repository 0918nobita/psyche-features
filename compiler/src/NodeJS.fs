module NodeJS

type IProcess =
    abstract member argv: string []

open Fable.Core

[<Emit "process">]
let _process: IProcess = jsNative
