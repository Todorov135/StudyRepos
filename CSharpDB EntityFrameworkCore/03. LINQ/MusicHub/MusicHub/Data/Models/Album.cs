﻿
using MusicHub.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationLength.AlbumNameMaxLenth)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [NotMapped]
        public decimal Price => this.Songs.Sum(s => s.Price);

        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
