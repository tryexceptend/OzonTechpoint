string testsCountInput = Console.ReadLine();
if (string.IsNullOrEmpty(testsCountInput))
{
    Console.WriteLine("ERR");
    return;
}
int testsCount = int.Parse(s: testsCountInput);
List<string> result = new();
Dictionary<int, int> daysPerMonth = new()
{
    {1, 31},//Январь - 31 день
    {2, 28},//Февраль - 28 дней (29 в високосном)
    {3, 31},//Март - 31 день
    {4, 30},//Апрель - 30 дней
    {5, 31},//Май - 31 день
    {6, 30},//Июнь - 30 дней
    {7, 31},//Июль - 31 день
    {8, 31},//Август - 31 день
    {9, 30},//Сентябрь - 30 дней
    {10,31},//Октябрь - 31 день
    {11,30},//Ноябрь - 30 дней
    {12,31}//Декабрь - 31 день
};
for (int i = 0; i < testsCount; i++)
{
    string testInput = Console.ReadLine();
    if (string.IsNullOrEmpty(testInput))
    {
        result.Add("NO");
        continue;
    }
    int[] test = testInput.Split(new char[] { ' ' }).Select(c => int.Parse(c)).ToArray();
    if (test == null || test.Length != 3)
    {
        result.Add("NO");
    }
    else
    {
        int day = test[0];
        int month = test[1];
        int year = test[2];
        int addDay = 0;
        if (month == 2)
        {
            //вычисление высокосного года
            addDay = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0 ? 1 : 0;
        }
        result.Add(day <= daysPerMonth[month] + addDay ? "YES" : "NO");
    }
}
foreach (string res in result)
{
    Console.WriteLine(res);
}
