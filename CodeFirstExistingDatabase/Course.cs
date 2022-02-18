namespace CodeFirstExistingDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    //[Table("Courses", Schema = "catalog")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public string ISBN { get; set; }
        
        
        //[Key]
        //[Column(Order=1)]
        //public int OrderId { get; set; }

        //[Key]
        //[Column(Order=2)]
        //public int OrderItemId { get; set; }

        
        //[Index(IsUnique = true)]
        //public int AuthorId { get; set; }
        
        
        //[Index("IX_AuthorStudentsCount",1)]
        //public int AuthorId { get; set; }
        
        //[Index("IX_AuthorStudentsCount",2)]
        //public int StudentsCount { get; set; }
        
        
        //[Column("sName", TypeName = "varchar")]
        //[MaxLength(255)]
        public string Name { get; set; }
        
        //[Required]
        public string Description { get; set; }
        public int Level { get; set; }

        public float FullPrice { get; set; }

        public int? Author_Id { get; set; }

        public virtual Author Author { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
