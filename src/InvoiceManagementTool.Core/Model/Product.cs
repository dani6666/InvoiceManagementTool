namespace InvoiceManagementTool.Core.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StorageAmount { get; set; }
        public float Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
