# Topic 6: Prac B — Reflection

## Task 1
1. `OrderBy` returns `IOrderedEnumerable<T>`, need `.ToList()` to convert back.
2. LINQ returns a new sequence, doesn't modify the original (unlike `List.Sort()` which sorts in place).
3. `x` in `x => x` is the lambda parameter for each element.
4. Type is inferred by compiler; any name works; no explicit type needed because of type inference.

## Task 2
No syntax change between Stack and Queue — LINQ works the same on all `IEnumerable<T>` collections.

## Task 3
1. Prefer LINQ — much more concise than manual sorting, one chain replaces many lines.
2. LINQ feels unusual at first but method chaining (Where→Select→OrderBy) is intuitive.
3. No syntax change between Stack and Queue — same query works on both.
