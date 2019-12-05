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

open Parsec

let parse = fmap (fun (_, x) -> x + "!") (token "abc")

open NodeJS

if Array.length _process.argv > 2
    then console.log (parse (bof, _process.argv.[2]))
