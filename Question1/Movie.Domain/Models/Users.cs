using System;
using System.Collections.Generic;

namespace Movie.Domain.Models
{
    public partial class Users
    {
        public Users()
        {
            InverseCreatedByNavigation = new HashSet<Users>();
            InverseModifiedByNavigation = new HashSet<Users>();
            MovieTypesCreatedByNavigation = new HashSet<MovieTypes>();
            MovieTypesModifiedByNavigation = new HashSet<MovieTypes>();
            MoviesCreatedByNavigation = new HashSet<Movies>();
            MoviesModifiedByNavigation = new HashSet<Movies>();
            Tokens = new HashSet<Tokens>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Saltkey { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime DtCreated { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? DtModified { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Users ModifiedByNavigation { get; set; }
        public virtual ICollection<Users> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<Users> InverseModifiedByNavigation { get; set; }
        public virtual ICollection<MovieTypes> MovieTypesCreatedByNavigation { get; set; }
        public virtual ICollection<MovieTypes> MovieTypesModifiedByNavigation { get; set; }
        public virtual ICollection<Movies> MoviesCreatedByNavigation { get; set; }
        public virtual ICollection<Movies> MoviesModifiedByNavigation { get; set; }
        public virtual ICollection<Tokens> Tokens { get; set; }
    }
}
