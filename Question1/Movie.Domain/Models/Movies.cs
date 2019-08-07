using System;
using System.Collections.Generic;

namespace Movie.Domain.Models
{
    public partial class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MovieTypeId { get; set; }
        public string ImdbId { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public bool Active { get; set; }
        public DateTime DtCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DtModified { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Users ModifiedByNavigation { get; set; }
        public virtual MovieTypes MovieType { get; set; }
    }
}
