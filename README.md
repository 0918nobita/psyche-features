# Features of the [Psyche](https://github.com/0918nobita/psyche) programming language

Conceptual Stage

```typescript
// name binding
let a: i32 = 3;

let mut b = 0;  // inferred type: i32
// mutation
b <- 4;

let add = fn (x: i32, y: i32) { x + y };

fn is_even(n: i32): bool {
  Debug.log('is_even was called');
  n % 2 == 0
}

Debug.log( add(a, b) );  // => 7
Debug.log( is_even(8) );  // => "is_even was called", false
```

## Variable shadowing

## If expression

## Function definition

## Lambda expression

## Tuple

## Type alias

```typescript
alias Rgb = (u8, u8, u8);
```

## Enum

```typescript
enum Maybe[T] {
  Some(T),
  None,
}

let foo: Maybe[i32] = None;
let bar = Some('hello');  // inferred type: Maybe[string]
```

## Record

```typescript
record Person {
  age: i32,
  name: string,
}
```

## Pattern matching

```typescript
let x = Some(3);
let y = None;

fn map_maybe(f: i32 => i32, a: Maybe[i32]): Maybe[i32] {
  match a {
    Some(v) -> Some(f(v)),
    None -> None
  }
}

let mul7 = fn (n: i32) { n * 7 };
Debug.log( map_maybe(mul7, x) );  // => Some(21)
Debug.log( map_maybe(mul7, y) );  // => None
```

## (Partial) Active pattern

## Signature / Module

`hoge.psy` :

```typescript
sig Hoge {
  foo: i32 => i32;
  bar: string => string;
}

pub mod HogeImpl: Hoge {
  fn foo(n: i32): i32 {
    n * n
  }

  fn bar(str: string): string {
    str ++ "!"
  }
}
```

`use_hoge.psy` :

```typescript
import './hoge' (HogeImpl);

Debug.log( HogeImpl.foo(6) ); // => 36
open HogeImpl;
Debug.log( bar("hello") );  // => "hello!"
```

## Implicit module

`functor.psy` :

```typescript
pub sig Functor[T[_]] {
  fmap: {A, B} T[A] => (A => B) => T[B];
}

implicit mod MaybeFunctor: Functor[Maybe[_]] {
  fn fmap[A, B](fa: Maybe[A]): (A => B) => Maybe[B] {
    fn (f: A => B) {
      match fa {
        Some(v) -> Some(f(v)),
        None -> None
      }
    }
  }
}
```

`derivation.psy` :

```typescript
// Toplevel implicit modules will be imported automatically.
import './functor' (Functor);

let mul6 = fn (n: i32) { n * 6 };
Debug.log( Functor::fmap(Some(7))(mul6) );  // => Some(42)

open Functor;

// additional implicit module
implicit mod ListFunctor: Functor[List[_]] {
  fn fmap[A, B](list: List[A]): (A => B) => List[B] {
    fn (f: A => B) {
      List.map(f, list);  // List is built-in module
    }
  }
}

Debug.log( fmap([2, 3, 4])(mul6) );  // => [12, 18, 24]
```

`derivation_err.psy` :

```typescript
import './functor' (Functor);

let add2 = fn (n: i32) { n + 2 };

// [CompileError] Derivation failed.
// There is no available implicit module for `Functor[T[_]]` signature.
Debug.log( Functor::fmap(true)(add2) );
```

## Computation expression

WIP
