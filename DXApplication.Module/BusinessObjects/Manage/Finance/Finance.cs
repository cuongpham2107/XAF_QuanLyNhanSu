using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.categories;
using DXApplication.Module.BusinessObjects.Manage.Projects;
using System;
using System.ComponentModel;
using System.Linq;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage.Finance
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(TomTat))]
    [XafDisplayName("Thu chi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]

    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public abstract class Finance : BaseObject
    {
        public Finance(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string tomTat;
        string ghiChu;
        Project project;
        FinanceSource financeSource;
        Personnel personnel;
        int soTien;
        string noiDung;
        LoaiThuChi loaiThuChi;
        int quy;
        int thang;
        int nam;
        DateTime? ngay;
        string soChungTu;
        [XafDisplayName("Số chứng từ")]
        public string SoChungTu
        {
            get => soChungTu;
            set => SetPropertyValue(nameof(SoChungTu), ref soChungTu, value);
        }
        [XafDisplayName("Ngày")]
        [RuleRequiredField("Finance.Ngay trường bắt buộc", DefaultContexts.Save, "Ngày thu chi phải có")]
        public DateTime? Ngay
        {
            get => ngay;
            set => SetPropertyValue(nameof(Ngay), ref ngay, value);
        }
        [XafDisplayName("Năm")]
        public int Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }
        [XafDisplayName("Tháng")]
        public int Thang
        {
            get => thang;
            set => SetPropertyValue(nameof(Thang), ref thang, value);
        }
        [XafDisplayName("Quý")]
        public int Quy
        {
            get => quy;
            set => SetPropertyValue(nameof(Quy), ref quy, value);
        }
        [XafDisplayName("Loại thu chi")]
        public LoaiThuChi LoaiThuChi
        {
            get => loaiThuChi;
            set => SetPropertyValue(nameof(LoaiThuChi), ref loaiThuChi, value);
        }
        [XafDisplayName("Nội dung")]
        [RuleRequiredField("Finance.NoiDung trường bắt buộc", DefaultContexts.Save, "Nội dung thu chi phải có")]
        public string NoiDung
        {
            get => noiDung;
            set => SetPropertyValue(nameof(NoiDung), ref noiDung, value);
        }
        [XafDisplayName("Số tiền")]
        public int SoTien
        {
            get => soTien;
            set => SetPropertyValue(nameof(SoTien), ref soTien, value);
        }
        [XafDisplayName("Đối tượng")]
        [RuleRequiredField("Finance.Personnel trường bắt buộc", DefaultContexts.Save, "Đối tượng thu chi phải có")]
        public Personnel Personnel
        {
            get => personnel;
            set => SetPropertyValue(nameof(Personnel), ref personnel, value);
        }
        [XafDisplayName("Nguồn")]
        [RuleRequiredField("Finance.FinanceSource trường bắt buộc", DefaultContexts.Save, "Nguồn thu chi phải có")]
        public FinanceSource FinanceSource
        {
            get => financeSource;
            set => SetPropertyValue(nameof(FinanceSource), ref financeSource, value);
        }
        [XafDisplayName("Dự án")]
        [Association("Project-Finances")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Tóm tắt")]
        [ModelDefault("AllowEdit", "False")]
        public string TomTat
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (Ngay != null && NoiDung != null)
                    {
                        return $"[{Ngay}] {NoiDung} ({SoTien})";
                    }
                }
                return tomTat;
            }
            set => SetPropertyValue(nameof(TomTat), ref tomTat, value);
        }
    }
}