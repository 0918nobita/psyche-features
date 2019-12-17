module Punk

open Fable.Core

[<ImportDefault("@babel/generator")>]
let generate (_ast: obj, _options: obj, _code: string): obj = jsNative

let [<Global>] console: JS.Console = jsNative

open JsAst

let ast =
    File (Program
        [| ExprStmt
            (CallExpr
                ( MemberExpr (Ident "console", Ident "log")
                , [| NumLiteral 42 |]
                ))
        |])

open Fable.Core.JsInterop

let source = generate (ast.JsObject, createObj [], "")

open System
open Parsec

let spaces: Parser<(Location * char) list> =
    some <| satisfy (fun (_, c) -> Char.IsWhiteSpace c)

let spacesOpt: Parser<(Location * char) list> =
    option [] spaces

let parse: Parser<string> =
    token "abc"
    |. spacesOpt
    |. token "def"
    |= (fun (_, x) -> succeed (x + "!"))

open NodeJS

console.log ((statSync "yarn.lock").mtime)

if Array.length _process.argv > 2
    then console.log (parse (bof, _process.argv.[2]))
