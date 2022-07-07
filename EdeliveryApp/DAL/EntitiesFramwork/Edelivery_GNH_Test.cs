namespace DAL.EntitiesFramwork
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Edelivery_GNH_Test
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SONumber { get; set; }

        [StringLength(50)]
        public string SOItems { get; set; }

        [StringLength(50)]
        public string MADONVICUNGCAP { get; set; }

        public string TENDONVICUNGCAP { get; set; }

        [StringLength(50)]
        public string MAKHACHANG { get; set; }

        public string TENKHACHHANG { get; set; }

        [StringLength(50)]
        public string MAHANGHOA { get; set; }

        public string TENHANGHOA { get; set; }

        public decimal? SOBC { get; set; }

        public decimal? SOCAY { get; set; }

        public decimal? SOCAYLE { get; set; }

        public decimal? TRONGLUONG { get; set; }

        public string SOLUONGBEBO { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
