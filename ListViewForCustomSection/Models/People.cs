using System.Runtime.Serialization;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ListViewForCustomSection.Models
{
    /// <summary>
    /// Class which represents our people
    /// </summary>
    [TableName("demo_people")]
    [PrimaryKey("id", autoIncrement = true)]
    [ExplicitColumns]
    [DataContract(Name = "people", Namespace = "")]
    public class People
    {
        [Column("id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [Column("firstname")]
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [Column("lastname")]
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [Column("age")]
        [DataMember(Name = "age")]
        public int Age { get; set; }

    }
}