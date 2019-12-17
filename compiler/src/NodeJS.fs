module NodeJS

type IProcess =
    abstract member argv: string []

open Fable.Core

[<Emit "process">]
let _process: IProcess = jsNative

type IStats =
    // 最終修正時刻
    abstract member mtime: obj

[<ImportMember("fs")>]
let statSync: string -> IStats = jsNative
