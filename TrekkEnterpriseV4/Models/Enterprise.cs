using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TrekkEnterpriseV4.Models
{
    public class Enterprise
    {
        public int ID { get; set; }

        [DisplayName("Client ID")]
        public int ClientID { get; set; }

        [DisplayName("Parent ID")]
        public int ParentID { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Access Code")]
        public string AccessCode { get; set; }

        [DisplayName("Android?")]
        public bool IsAndroid { get; set; }

        [DisplayName("APK Name")]
        public string ApkName { get; set; }

        [Required]
        public string Route { get; set; }

        public bool Enabled { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Last Modified")]
        public DateTime DateModified { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [DisplayName("Download Count")]
        public int DownloadCount { get; set; }

        // Navigation
        public Client Client { get; set; }
        public Parent Parent { get; set; }
    }
}