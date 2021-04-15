namespace WholesaleFirm.Model
{
  public class WarehouseGood
  {
    public int Id { get; }

    public int Count { get; set; }

    public int WarehouseId { get; }

    public WarehouseGood(int id, int count, int warehouseId)
    {
      Id = id;
      Count = count;
      WarehouseId = warehouseId;
    }
  }
}
