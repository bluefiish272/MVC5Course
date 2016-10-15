using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models.ViewModels
{
    public class ClientLoginViewModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "{0}太長，不得超過{1}個字元!")]
        [DisplayName("名字")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}太長，不得超過{1}個字元!")]
        [DisplayName("中間名")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0}太長，不得超過{1}個字元!")]
        [DisplayName("姓氏")]
        public string LastName { get; set; }
        //[DisplayFormat(string.Format = "{0:yyyy/MMMM/dd}")]
        [DisplayName("生日")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
    }
}