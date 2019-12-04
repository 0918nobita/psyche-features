module Punk

open Fable.Core

[<ImportDefault("@babel/generator")>]
let generate (_ast: obj, _options: obj, _code: string): obj = jsNative

open Fable.Core.JsInterop

type Ast =
    | File of program : Ast
    | Program of body : Ast []
    | ExprStmt of expr : Ast
    | CallExpr of callee : Ast * args : Ast []
    | MemberExpr of object : Ast * property : Ast
    | Ident of name : string
    | NumLiteral of value : int

    member this.JsObject =
        match this with
        | File program ->
            createObj [
                "type" ==> "File"
                "program" ==> program.JsObject
            ]
        | Program body ->
            createObj [
                "type" ==> "Program"
                "body" ==> Array.map<Ast, obj> (fun x -> x.JsObject) body
            ]
        | ExprStmt expr ->
            createObj [
                "type" ==> "ExpressionStatement"
                "expression" ==> expr.JsObject
            ]
        | CallExpr (callee, args) ->
            createObj [
                "type" ==> "CallExpression"
                "callee" ==> callee.JsObject
                "arguments" ==> Array.map<Ast, obj> (fun x -> x.JsObject) args
            ]
        | MemberExpr (object, property) ->
            createObj [
                "type" ==> "MemberExpression"
                "object" ==> object.JsObject
                "property" ==> property.JsObject
            ]
        | Ident name ->
            createObj [
                "type" ==> "Identifier"
                "name" ==> name
            ]
        | NumLiteral value ->
            createObj [
                "type" ==> "NumericLiteral"
                "value" ==> value
            ]

let ast =
    File (Program
        [| ExprStmt
            (CallExpr
                ( MemberExpr (Ident "console", Ident "log")
                , [| NumLiteral 42 |]
                ))
        |])

let source = generate (ast.JsObject, createObj [], "")
