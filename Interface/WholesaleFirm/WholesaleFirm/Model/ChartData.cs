using System;

namespace WholesaleFirm.Model
{
  public class ChartData
  {
    public DateTime Date { get; }

    public decimal Count { get; }

    public ChartData(DateTime date, decimal count)
    {
      Date = date;
      Count = count;
    }
  }
}
