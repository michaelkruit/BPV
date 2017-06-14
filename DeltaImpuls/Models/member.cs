//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeltaImpuls.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class member
    {
        public System.Guid ID { get; set; }
        [Required, DisplayName("Voornaam")]
        [RegularExpression(@"/([A-Za-z])/", ErrorMessage = "Er mogen geen cijfers in de naam")]
        public string firstname { get; set; }
        [Required, DisplayName("Achternaam")]
        [RegularExpression(@"/([A-Za-z])/", ErrorMessage = "Er mogen geen cijfers in de achternaam")]
        public string lastname { get; set; }
        [DisplayName("T.V.")]
        [RegularExpression(@"/([A-Z- . a-z])/", ErrorMessage = "Er mogen geen cijfers in het tussenvoegsel")]
        public string insertion { get; set; }
        [Required, DisplayName("Bondsnmr")]
        public long bondsnr { get; set; }
        [DisplayName("CG")]
        public bool cg { get; set; }
        [DisplayName("Para-TT")]
        public bool paratt { get; set; }
        [Required, DisplayName("Geb. Datum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
            ErrorMessage = "Er is geen valide datum ingevoerd: dd-mm-yyyy")]
        public System.DateTime dateborn { get; set; }
        [DisplayName("M/V")]
        public bool gender { get; set; }
        [Required, DisplayName("Lid sinds")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$",
            ErrorMessage = "Er is geen valide datum ingevoerd: dd-mm-yyyy")]
        public System.DateTime membersince { get; set; }
        [Required, DisplayName("Adres")]
        public string adres { get; set; }
        [Required, DisplayName("Postcode")]
        [DataType(DataType.PostalCode), StringLength(7, MinimumLength = 4)]
        [RegularExpression(@"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", ErrorMessage = "Postcode is niet correct ingevuld")]
        public string postcode { get; set; }
        [Required, DisplayName("Woonplaats")]
        [RegularExpression(@"/([A-Za-z])/", ErrorMessage = "Er mogen geen cijfers in de woonplaats")]
        public string city { get; set; }
        [DisplayName("Telefoonnummer")]
        [DataType(DataType.PhoneNumber), StringLength(12, MinimumLength = 6)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Niet een correct telefoonnummer")]
        public string phonennumber { get; set; }
        [DisplayName("Mobiel")]
        [DataType(DataType.PhoneNumber)]
        public string mobilenumber { get; set; }
        [Required, DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public System.Guid categorie_id { get; set; }
        public System.Guid location_ID { get; set; }
        public Nullable<System.Guid> lj_id { get; set; }
        public Nullable<System.Guid> ls_id { get; set; }

        public virtual categorie categorie { get; set; }
        public virtual lj lj { get; set; }
        public virtual location location { get; set; }
        public virtual ls ls { get; set; }
    }
}
