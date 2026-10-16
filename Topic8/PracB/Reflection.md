# Topic 8 Prac B Reflection

## Task 1

- 文件已存在时写入会被覆盖。
- @ 是逐字字符串，反斜杠不用转义。
- 用 using 会自动释放文件资源，不用可能导致文件被占用。
- StreamReader 逐行读适合大文件，ReadAllText 一次性读完适合小文件。

## Task 2

- ! 告诉编译器这个值不会是 null。
- 非 public 属性不会被序列化进 JSON。

## Task 3

- where T : class 限制 T 必须是引用类型，不能是 int 等值类型。

## Task 4

- GC 自动回收不用的内存，防止泄漏。
- 它管理堆内存所以知道用了多少。
- GC.Collect() 强制立即回收。
- PeakWorkingSet64 是进程总内存，HeapSizeBytes 只是托管堆，所以不一样。

## Task 5

- LinkedList 用内存更多。
- 因为每个节点要存前后指针，额外开销大；List 是数组，连续存放开销小。
