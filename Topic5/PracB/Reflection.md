# Topic 5: Prac B — Reflection Notes

## Task 1 Reflection Questions

### 1. How is the structure of a LinkedList<T> different from List<T>?

- **List<T>** uses an **internal array** that stores elements contiguously in memory. Elements are accessed by index, and when the array is full, a new larger array is created and elements are copied over.
- **LinkedList<T>** uses **nodes** (`LinkedListNode<T>`), where each node contains a value, a reference to the next node, and a reference to the previous node (doubly linked list). Nodes are not stored contiguously — they are scattered in memory and connected by references.

### 2. Why can't you initialize a LinkedList<string> using standard List syntax?

```csharp
LinkedList<string> list = ["Why", "isn't", "it", "possible!?"];

