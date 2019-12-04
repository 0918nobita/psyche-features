module Punk

open Fable.Core

[<ImportDefault("@babel/generator")>]
let generate (_ast: obj, _options: obj, _code: string): obj = jsNative

let [<Global>] console: JS.Console = jsNative

open NodeJS

console.dir _process.argv

open Ast

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
