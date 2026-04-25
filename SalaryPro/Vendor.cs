using System;
using System.Collections.Generic;
using System.Linq;

public class Vendor
{
    public string Name { get; set; }

    // Кількість по категоріях
    public int Count55 { get; set; } = 0;
    public int Count30 { get; set; } = 0;
    public int Count15 { get; set; } = 0;
    public int Count5 { get; set; } = 0;

    // Розрахунок суми по постачальнику
    public int TotalSum => (Count55 * 55) + (Count30 * 30) + (Count15 * 15) + (Count5 * 5);

    // Розрахунок загальної кількості товарів
    public int TotalItems => Count55 + Count30 + Count15 + Count5;

    public Vendor(string name)
    {
        Name = name;
    }

    // Метод для формування рядка звіту (як у Python)
    public string GetReportLine()
    {
        if (TotalSum == 0) return "";

        List<string> parts = new List<string>();
        if (Count55 > 0) parts.Add($"{Count55}*55");
        if (Count30 > 0) parts.Add($"{Count30}*30");
        if (Count15 > 1) parts.Add($"{Count15}*15"); // Виправлено логіку для одиничних правок
        else if (Count15 == 1) parts.Add("1*15");
        if (Count5 > 0) parts.Add($"{Count5}*5");

        return $"{Name}\n{string.Join("+", parts)}={TotalSum}";
    }
}