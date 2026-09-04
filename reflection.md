# Prac A Reflection
1. What differences did you observe moving from procedural to class‑based design?
Procedural code keeps data and functions separate. Class‑based design groups related data and methods together inside one class. It supports data validation, better code reuse and makes the code structure clearer.

2. How does static typing affect your workflow?
Static typing checks types during compile time. It catches many bugs before running the program. It provides editor hints, but we need to explicitly define types for variables.

# Topic 5: Prac A — Reflection

# Task 1: How does C# sort a string Array?

C# uses `Array.Sort()` to sort string arrays. By default, it sorts in **alphabetical (lexicographical) order** using the current culture's string comparison rules.

---

# Task 3: Arrays vs Lists

# Syntax Differences

| Feature | Array | List |
|---------|-------|------|
| Declaration | `string[] arr = new string[10];` | `List<string> list = new List<string>();` |
| Size | Fixed (cannot change) | Dynamic (can grow/shrink) |
| Get count | `.Length` | `.Count` |
| Add/Remove | Not supported | `.Add()`, `.Remove()`, `.Insert()` |
| Sort/Reverse | `Array.Sort(arr)`, `Array.Reverse(arr)` | `list.Sort()`, `list.Reverse()` |

# Performance and Flexibility

- **Array**: Faster, less memory overhead, but inflexible — size is locked at creation.
- **List**: Slightly more overhead, but very flexible — dynamically resizes, supports Add/Remove/Insert/Search.

# When to use which

- **Use Array** when: size is known in advance and will never change (e.g., days of week, fixed dataset).
- **Use List** when: size is unknown or may change, or you need dynamic add/remove/search (most application code).

**Rule of thumb**: Default to `List<T>` for most code; use arrays only when you specifically need fixed size or maximum performance.
