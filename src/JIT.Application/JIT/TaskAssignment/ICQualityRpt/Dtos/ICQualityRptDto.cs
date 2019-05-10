using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace JIT.TaskAssignment.ICQualityRpt.Dtos
{
    //[AutoMapFrom(typeof(JITEF.DIME2Barcode.ICQualityRpt))]
    public class ICQualityRptDto : IEntityDto<string>
    {
        public string Id { get => FID; set => FID = value; }

        public string FID { get; set; }
        public int FItemID { get; set; }
        public Nullable<decimal> FAuxQty { get; set; }
        public string FRemark { get; set; }
        public string FNote { get; set; }
    }
}