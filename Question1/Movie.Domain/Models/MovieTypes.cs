using System;
using System.Collections.Generic;

namespace Movie.Domain.Models
{
    public partial class MovieTypes
    {
        public MovieTypes()
        {
            Movies = new HashSet<Movies>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime DtCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? DtModified { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Users ModifiedByNavigation { get; set; }
        public virtual ICollection<Movies> Movies { get; set; }
    }
}
