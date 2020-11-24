using System.Diagnostics.CodeAnalysis;
using System;

namespace CSharp9
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public string Description { get; set; } = "";

        public Product(string name, string sku)
        {
            SetName(name);
            if (!SetSku(sku))
                throw new NullReferenceException();
        }

        [MemberNotNull(nameof(Name))]
        public void SetName(string name) => Name = name;

        [MemberNotNullWhen(true, nameof(Sku))]
        public bool SetSku(string sku)
        {
            if (sku is not { Length: > 0 })
                return false;
            Sku = sku;
            return true;
        }

        public void OutputDescrition()
        {
            if (TryGetDisplay(out var display))
            {
                Console.WriteLine(display.ToString());
            }
        }

        public bool TryGetDisplay([NotNullWhen(true)] out string? description)
        {
            if (!string.IsNullOrEmpty(Description))
            {
                description = Description;
                return true;
            }
            description = null;
            return false;
        }
    }
}