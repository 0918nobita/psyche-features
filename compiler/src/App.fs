module Punk

open Fable.Core

let [<Global>] console: JS.Console = jsNative

let [<Global>] JSON: JS.JSON = jsNative

[<ImportMember("@babel/parser")>]
let parse: string -> obj = jsNative

[<ImportDefault("@babel/generator")>]
let generate (ast: obj, options: obj, code: string): obj = jsNative

open Fable.Core.JsInterop

let file (program : obj) = createObj [
    "type" ==> "File"
    "program" ==> program
]

let program (stmts : obj []) = createObj [
    "type" ==> "Program"
    "body" ==> stmts
]

let exprStmt (expr : obj) = createObj [
    "type" ==> "ExpressionStatement"
    "expression" ==> expr
]

let callExpr (callee : obj) (args : obj []) = createObj [
    "type" ==> "CallExpression"
    "callee" ==> callee
    "arguments" ==> args
]

let memExpr (object : obj) (property : obj) = createObj [
    "type" ==> "MemberExpression"
    "object" ==> object
    "property" ==> property
]

let ident (name : string) = createObj [
    "type" ==> "Identifier"
    "name" ==> name
]

let numLiteral (n : int) = createObj [
    "type" ==> "NumericLiteral"
    "value" ==> n
]

let ast =
    [| exprStmt
        (callExpr
            (memExpr
                (ident "console")
                (ident "log"))
            [| numLiteral 42 |])
    |]
    |> program
    |> file

console.log (generate (ast, createObj [], ""))
