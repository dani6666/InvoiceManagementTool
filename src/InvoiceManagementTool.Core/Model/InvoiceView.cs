namespace InvoiceManagementTool.Core.Model
{
    public class InvoiceView
    {
        public string Id { get; set; }
        public string DateOfIssue { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public float TotalValue { get; set; }
    }
}
