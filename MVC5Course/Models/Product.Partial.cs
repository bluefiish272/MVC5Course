namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price > 2000 && this.Stock > 100)
            {
                yield return new ValidationResult("此商品價格與庫存不合理", new string[] { "Price","Stock"});
            }
            if (this.ProductName == "pig")
            {
                yield return new ValidationResult("商品名稱不可為pig", new string[] { "ProductName"});
            }
            
            yield break;
        }    

    }
    
    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(1,9999)]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool Is刪除 { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
