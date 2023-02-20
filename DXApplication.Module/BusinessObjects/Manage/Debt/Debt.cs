using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.Manage.Contract;
using DXApplication.Module.BusinessObjects.Manage.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage.Debt
{
    [DefaultClassOptions]
    public class Debt : BaseObject
    {
        public Debt(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string ghiChu;
        bool status;
        float daThu;
        float tongSoTien;
        Project project;
        int thang;
        int nam;
        DateTime? ngay;
        string noiDung;
        string soChungTu;
        LoaiCongNo loaiCongNo;
        [XafDisplayName("Loại")]
        public LoaiCongNo LoaiCongNo
        {
            get => loaiCongNo;
            set => SetPropertyValue(nameof(LoaiCongNo), ref loaiCongNo, value);
        }
        [XafDisplayName("Số chứng từ")]
        public string SoChungTu
        {
            get => soChungTu;
            set => SetPropertyValue(nameof(SoChungTu), ref soChungTu, value);
        }

        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }

        public DateTime? Ngay
        {
            get => ngay;
            set => SetPropertyValue(nameof(Ngay), ref ngay, value);
        }

        public int Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }

        public int Thang
        {
            get => thang;
            set => SetPropertyValue(nameof(Thang), ref thang, value);
        }

        [XafDisplayName("Dự án")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }
        [XafDisplayName("Tổng số tiền")]
        public float TongSoTien
        {
            get => tongSoTien;
            set => SetPropertyValue(nameof(TongSoTien), ref tongSoTien, value);
        }
        [XafDisplayName("Đóng")]
        public bool Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
        [XafDisplayName("Ghi chú")]

        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}