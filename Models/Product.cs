namespace dotnet_mvc.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id} - Name: {this.Name} :: Category: {this.Category.Name}";
        }
    }
}