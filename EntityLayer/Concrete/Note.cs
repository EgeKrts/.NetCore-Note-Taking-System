using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public int UserId { get; set; } // Dış anahtar (Foreign Key) ilişkisi
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        // Diğer not özellikleri

        // Her not bir kullanıcıya ait olmalı
        public User User { get; set; }
    }
}
