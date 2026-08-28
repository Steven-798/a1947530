namespace AdventDay7;

using System.Text;

/// <summary>
/// Program 类包含了神奇的 tachyon 流形（网格）处理逻辑，模拟光束在网格中的传播。
/// </summary>
public static class Program
{
    /// <summary>
    /// 要读取的输入文件路径。当前硬编码为 Codespaces 中的 Example.txt。
    /// TODO: 如需在其他环境运行，请修改此路径。
    /// </summary>
    public static string FileToRead { get; set; } = "/workspaces/a1947530/Topic4/PracB/Example.txt";

    /// <summary>
    /// 处理起点 S：在起点正下方的格子画一条竖线 |，表示光束从这里开始向下传播。
    /// </summary>
    /// <param name="posX">起点 S 所在的列索引（X 坐标）</param>
    /// <param name="posY">起点 S 所在的行索引（Y 坐标）</param>
    /// <param name="tachyonGrid">整个网格数据，每行是一个字符串</param>
    public static void processStart(int posX, int posY, List<string> tachyonGrid)
    {
        // 取出起点下方那一行，用 StringBuilder 修改（字符串不可变，需要用 StringBuilder）
        string line = tachyonGrid[posY + 1];
        StringBuilder sb = new StringBuilder(line);
        // 在起点正下方位置画竖线 |
        sb[posX] = '|';
        line = sb.ToString();
        // 把修改后的行写回网格
        tachyonGrid[posY + 1] = line;
    }

    /// <summary>
    /// 处理分裂器 ^：如果正上方有光束 |，则在当前行的左右两侧各画一条竖线 |，
    /// 表示光束被分裂成左右两路。注意：此方法目前不返回分裂次数，totalCount 不会被更新。
    /// </summary>
    /// <param name="posX">分裂器 ^ 所在的列索引（X 坐标）</param>
    /// <param name="posY">分裂器 ^ 所在的行索引（Y 坐标）</param>
    /// <param name="tachyonGrid">整个网格数据，每行是一个字符串</param>
    /// <remarks>
    /// 潜在问题：如果分裂器在最左列（posX=0）或最右列，posX-1 或 posX+1 会索引越界。
    /// 当前示例数据未触发此问题，但代码缺少边界检查。
    /// </remarks>
    public static void processSplitter(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        // 只有正上方有光束 | 时才分裂
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            // 向左分出一路
            sb[posX - 1] = '|';
            // 向右分出一路
            sb[posX + 1] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    /// <summary>
    /// 处理空格子：如果正上方有光束 |，则在当前格子也画一条竖线 |，表示光束直线向下传播。
    /// 第一行（posY=0）不调用此方法，因为正上方没有行。
    /// </summary>
    /// <param name="posX">当前空格子的列索引（X 坐标）</param>
    /// <param name="posY">当前空格子的行索引（Y 坐标），必须大于 0</param>
    /// <param name="tachyonGrid">整个网格数据，每行是一个字符串</param>
    public static void processEmpty(int posX, int posY, List<string> tachyonGrid)
    {
        string line = tachyonGrid[posY];
        StringBuilder sb = new StringBuilder(line);
        // 如果正上方有光束，延续到当前格子
        if (tachyonGrid[posY - 1][posX] == '|')
        {
            sb[posX] = '|';
            line = sb.ToString();
            tachyonGrid[posY] = line;
        }
    }

    /// <summary>
    /// 程序入口：读取网格文件，逐行逐格处理，输出处理前后的网格状态及分裂总数。
    /// </summary>
    /// <param name="args">命令行参数（未使用）</param>
    public static void Main(string[] args)
    {
        // 读取输入文件
        var sr = new StreamReader(FileToRead);
        string srText = sr.ReadToEnd();
        int totalCount = 0;

        // 按行分割文本，存入 symbols 列表（包含末尾空行）
        List<string> symbols = [.. srText.Split("\n")];
        // 去掉最后一行（空行），得到真正的网格数据
        List<string> tachyonGrid = symbols[..^1];

        // 输出初始网格状态
        Console.WriteLine("Begin Tachyon Manifold start state");
        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("End Tachyon Manifold start state");

        // 逐行、逐格遍历网格
        for (int posY = 0; posY < tachyonGrid.Count; posY++)
        {
            var item = tachyonGrid[posY];
            // .Index() 同时获取每个字符的索引（posX）和字符本身（character）
            foreach (var (posX, character) in item.Index())
            {
                if (character == 'S')
                {
                    // 遇到起点 S，向下画一条线
                    processStart(posX, posY, tachyonGrid);
                }
                else if (character == '^')
                {
                    // 遇到分裂器 ^，向左右分裂
                    processSplitter(posX, posY, tachyonGrid);
                }
                else if (posY != 0)
                {
                    // 空格子（非第一行），检查是否有光束延续
                    processEmpty(posX, posY, tachyonGrid);
                }
            }
        }

        // 输出处理后的网格状态
        Console.WriteLine($"Begin Taychon Manifold end state");
        foreach (var item in tachyonGrid)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"End Taychon Manifold end state");
        Console.WriteLine($"Total Tachyon Manifold splits were: {totalCount}");
        Console.WriteLine($"If using Example.txt, your total should be 21");
        Console.WriteLine($"If using Example.txt, your total is {(totalCount == 21 ? "RIGHT" : "WRONG")}");
    }
}
