module Punk

open Fable.Core

let [<Global>] console: JS.Console = jsNative

let [<Global>] JSON: JS.JSON = jsNative

[<ImportMember("@babel/parser")>]
let parse: string -> obj = jsNative

[<ImportDefault("@babel/generator")>]
let generate (ast: obj, options: obj, code: string): obj = jsNative

let code = "console.log(6 * 7);"

let ast = parse code
printfn "%s" (JSON.stringify ast)

open Fable.Core.JsInterop

console.log (generate (ast, createObj [], code))
