using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ListViewForCustomSection.Models
{
    [DataContract(Name = "pagedPeople", Namespace = "")]
    public class PagedPeopleResult
    {
        [DataMember(Name = "people")]
        public List<People> People { get; set; }

        [DataMember(Name = "currentPage")]
        public long CurrentPage { get; set; }

        [DataMember(Name = "itemsPerPage")]
        public long ItemsPerPage { get; set; }

        [DataMember(Name = "totalPages")]
        public long TotalPages { get; set; }

        [DataMember(Name = "totalItems")]
        public long TotalItems { get; set; }
    }
}