using CRUD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.ViewModel
{
    public class BookFormViewModel
    {
        public int Id { get; set; }
        [MaxLength(256)]
        [Required]
        public string Title { get; set; }
        [MaxLength(256)]
        [Required]
        public string Author { get; set; }
        [MaxLength(2000)]
        [Required]
        public string Discription { get; set; }
        [Display(Name ="Category")]
        public byte CategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}