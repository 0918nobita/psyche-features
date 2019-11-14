# PunkScript

A dull, statically-typed language that compiles to JavaScript

- Export ES Module (`.mjs`)
- Export TypeScript Declaration File (`.d.ts`)
- Export Source Map (`.map`)

```typescript
let a: int = 2;
a <- 3;  // assignment

const b = 4;  // inferred type: int

// inferred type: (int, int) => int
const add = fn(x, y) { x + y };

fn isEven(n: int): boolean {
  Debug.log('checking...');
  n % 2 == 0
}

Debug.log( add(a, b) );  // => 7
Debug.log( isEven(8) );  // => "checking...", false
```

## Syntax / Semantics

### Variable shadowing

### If expression

### Function definition

### Lambda expression

### Tuple

### Type alias

```
alias Rgb = int * int * int;
```

### Enum

```
enum Maybe[T] {
  Some(T),
  None
}

const foo: Maybe[int] = None;
const bar = Some('hello');  // inferred type: Maybe[string]
```

### Record

```
record Person {
  age: int,
  name: string
}
```

### Pattern matching

```typescript
const x = Some(3);
const y = None;

fn mapMaybe(f: int => int, a: Maybe[int]): Maybe[int] {
  match a {
    Some(v) -> Some(f v),
    None -> None
  }
}

const mul7 = fn (n: int) { n * 7 };
Debug.log( mapMaybe(mul7, x) );  // => Some(21)
Debug.log( mapMaybe(mul7, y) );  // => None
```

### Implicit conversion

```
implicit fn intToString(n: int): string {
  Int.toString(n);  // Int is built-in module
}

fn concatString(a: string, b: string): string {
  a ++ b
}

Debug.log( concatString('3 + 4 = ', 3 + 4) );  // => "3 + 4 = 7"
```

### Signature / Module

#### `hoge.punk`

```
sig Hoge {
  foo: int => int;
  bar: string => string;
}

pub mod HogeImpl: Hoge {
  fn foo(n: int): int {
    n * n
  }

  fn bar(str: string): string {
    str ++ "!"
  }
}
```

#### `useHoge.punk`

```
import './hoge' (HogeImpl);


Debug.log( HogeImpl.foo(6) ); // => 36

open HogeImpl;

Debug.log( bar("hello") );  // => "hello!"
```

### Implicit module

#### `functor.punk`

```
pub sig Functor[T[_]] {
  fmap: {A, B} T[A] => (A => B) => T[B];
}

implicit mod maybeFunctor: Functor[Maybe[_]] {
  fn fmap[A, B](fa: Maybe[A]): (A => B) => Maybe[B] {
    fn (f: A => B) {
      match fa {
        Some(v) -> Some(f v),
        None -> None
      }
    }
  }
}
```

#### `derivation.punk`

```
// Toplevel implicit modules will be imported automatically.
import './functor' (Functor);


const mul6 = fn (n: int) { n * 6 };

Debug.log( Functor::fmap(Some(7))(mul6) );  // => Some(42)

open Functor;

// additional implicit module
implicit mod listFunctor: Functor[List[_]] {
  fn fmap[A, B](list: List[A]): (A => B) => List[B] {
    fn (f: A => B) {
      List.map(f, list);  // List is built-in module
    }
  }
}

Debug.log( fmap([2, 3, 4])(mul6) );  // => [12, 18, 24]
```

#### `derivationErr.punk`

```
import './functor' (Functor);


const add2 = fn (n: int) { n + 2 };

// [CompileError] Derivation failed.
// There is no available implicit module for `Functor[T[_]]` signature.
Debug.log( Functor::fmap(true)(add2) );
```
