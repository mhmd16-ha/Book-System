using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class Book
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
        public byte CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public DateTime AddedOn { get; set; }
        public Book()
        {
            AddedOn = DateTime.Now;
        }

    }
}