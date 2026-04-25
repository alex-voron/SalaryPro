public class Actualization
{
    public string VendorName { get; set; }
    public int Edits { get; set; }   // по 15 грн
    public int Removals { get; set; } // по 5 грн

    // Формула: (зміни*15) + (зняття*5) + (всі*10 за відповідь)
    public int TotalSum => (Edits * 15) + (Removals * 5) + ((Edits + Removals) * 10);

    public string GetReportLine()
    {
        List<string> parts = new List<string>();
        if (Edits > 0) parts.Add($"{Edits}*15");
        if (Removals > 0) parts.Add($"{Removals}*5");
        parts.Add($"{Edits + Removals}*10");

        return $"{VendorName}\n{string.Join("+", parts)}={TotalSum}";
    }
}