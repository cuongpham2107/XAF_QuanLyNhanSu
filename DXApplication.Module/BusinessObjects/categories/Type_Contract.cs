using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.categories
{
    [DefaultClassOptions]
    public class Type_Contract : BaseObject
    {
        public Type_Contract(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string ghiChu;
        string maHopDong;
        string nhomHopDong;
        [XafDisplayName("Nhóm hợp đồng")]
        [RuleRequiredField("Type_Contract.NhomHopDong trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string NhomHopDong
        {
            get => nhomHopDong;
            set => SetPropertyValue(nameof(NhomHopDong), ref nhomHopDong, value);
        }
        [XafDisplayName("Mã hợp đồng")]
        [RuleRequiredField("Type_Contract.MaHopDong trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string MaHopDong
        {
            get => maHopDong;
            set => SetPropertyValue(nameof(MaHopDong), ref maHopDong, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}