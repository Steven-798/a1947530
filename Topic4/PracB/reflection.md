# Topic 4: Prac B — Reflection

## 1. symbols vs tachyonGrid, what is [..^1]?
`symbols` has 17 elements (16 grid lines + 1 empty trailing line from the final newline). `tachyonGrid = symbols[..^1]` uses range syntax: `^1` means "last element", so `[..^1]` = "all except last". Result: tachyonGrid has 16 elements (the real grid).

## 2. foreach (var (posX, character) in item.Index())
`.Index()` pairs each character with its index as a tuple. Each loop: `posX` = column index (0,1,2...), `character` = the char at that position.
 Plain `foreach (char c in item)`: gets char only, no index
`for (int i = 0; ...)`: gets both, but you manage the index manually
`.Index()`: gets both, index provided automatically

## 3. processSplitter edge case
When a `^` has `|` above it, it draws `|` at posX-1 and posX+1 (splits beam left/right). This is correct behavior for a splitter. **Potential bug:** if splitter is at column 0 or 14 (edge), `posX-1` or `posX+1` goes out of bounds and crashes. Example.txt avoids this, but no boundary check exists.

## 4. Current output & why total is wrong
Output: `Total splits were: 0` → WRONG (should be 21). Reason: `totalCount` is set to 0 but **never incremented anywhere**. `processSplitter` should count each split but returns void and doesn't update totalCount. The TODO comment confirms this.
