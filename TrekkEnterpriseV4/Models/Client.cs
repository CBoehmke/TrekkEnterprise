using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrekkEnterpriseV4.Models
{
    public class Client
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Last Modified")]
        public DateTime DateModified { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        // navigation
        public ICollection<Enterprise> EnterpriseClients { get; set; }
    }
}