# PunkScript

A dull, statically-typed language that compiles to JavaScript

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

Debug.log(add(a, b));  // => 7
Debug.log(isEven(8));  // => "checking...", false
```

## Syntax / Semantics

### Variable shadowing

### If expression

### Function definition

### Lambda expression

### Tuple

### Enum

```
enum 'a option {
  Some('a),
  None
}

const foo: int option = None;
const bar = Some('hello');  // inferred type: string option
```

### Record

```
record person {
  age: int,
  name: string
}
```

### Pattern matching

```typescript
const x = Some(3);
const y = None;

fn mapOption(f: (int) => int, a: int option): int option {
  match a {
    Some(v) -> Some(f v),
    None -> None
  }
}

const mul7 = fn(n: int): int { n * 7 };
Debug.log(mapOption(mul7, x));  // => Some 21
Debug.log(mapOption(mul7, y));  // => None
```

### Type alias

```
alias rgb = int * int * int;
```

### Type class
