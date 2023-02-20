using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.categories;
using System;
using System.ComponentModel;
using System.Linq;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage.Projects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(TenDuAn))]
    [XafDisplayName("Dự án")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class Project : BaseObject
    {
        public Project(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string ghiChu;
        string moTaYeuCau;
        Personnel nguoiLap;
        Personnel leader;
        Personnel manager;
        TrangThaiDuAn trangThai;
        int quy;
        int thang;
        int nam;
        DateTime? ngayKetThuc;
        DateTime? ngayBatDau;
        ProjectType projectType;
        string tenDuAn;
        [XafDisplayName("Tên dự án")]
        [RuleRequiredField("Project.TenDuAn trường bắt buộc", DefaultContexts.Save,
      "Tên dự án phải có")]
        public string TenDuAn
        {
            get => tenDuAn;
            set => SetPropertyValue(nameof(TenDuAn), ref tenDuAn, value);
        }
        [XafDisplayName("Loại dự án")]
        [RuleRequiredField("Project.ProjectType trường bắt buộc", DefaultContexts.Save,
      "Loại dự án phải có")]
        public ProjectType ProjectType
        {
            get => projectType;
            set => SetPropertyValue(nameof(ProjectType), ref projectType, value);
        }
        [XafDisplayName("Ngày bắt đầu")]
        public DateTime? NgayBatDau
        {
            get => ngayBatDau;
            set => SetPropertyValue(nameof(NgayBatDau), ref ngayBatDau, value);
        }
        [XafDisplayName("Ngày kết thúc")]
        public DateTime? NgayKetThuc
        {
            get => ngayKetThuc;
            set => SetPropertyValue(nameof(NgayKetThuc), ref ngayKetThuc, value);
        }
        [XafDisplayName("Năm")]
        [ModelDefault("AllowEdit", "False")]
        public int Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }
        [XafDisplayName("Tháng")]
        [ModelDefault("AllowEdit", "False")]
        public int Thang
        {
            get => thang;
            set => SetPropertyValue(nameof(Thang), ref thang, value);
        }
        [XafDisplayName("Quý")]
        [ModelDefault("AllowEdit", "False")]
        public int Quy
        {
            get => quy;
            set => SetPropertyValue(nameof(Quy), ref quy, value);
        }
        [XafDisplayName("Trạng thái")]
        public TrangThaiDuAn TrangThai
        {
            get => trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
        }
        [XafDisplayName("Manager")]
        [RuleRequiredField("Project.Manager trường bắt buộc", DefaultContexts.Save,
      "Manager của dự án phải có")]
        public Personnel Manager
        {
            get => manager;
            set => SetPropertyValue(nameof(Manager), ref manager, value);
        }
        [XafDisplayName("Leader")]
        [RuleRequiredField("Project.Leader trường bắt buộc", DefaultContexts.Save,
     "Leader của dự án phải có")]
        public Personnel Leader
        {
            get => leader;
            set => SetPropertyValue(nameof(Leader), ref leader, value);
        }
        [XafDisplayName("Người lập")]
        public Personnel NguoiLap
        {
            get => nguoiLap;
            set => SetPropertyValue(nameof(NguoiLap), ref nguoiLap, value);
        }
        [XafDisplayName("Mô tả yêu cầu")]
        [Size(SizeAttribute.Unlimited)]
        public string MoTaYeuCau
        {
            get => moTaYeuCau;
            set => SetPropertyValue(nameof(MoTaYeuCau), ref moTaYeuCau, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Hồ sơ")]
        [Association("Project-Documents")]
        public XPCollection<Document.Document> Documents
        {
            get
            {
                return GetCollection<Document.Document>(nameof(Documents));
            }
        }
        [Association("Project-ProjectDatas")]
        public XPCollection<ProjectData> ProjectDatas
        {
            get
            {
                return GetCollection<ProjectData>(nameof(ProjectDatas));
            }
        }
        [XafDisplayName("Hợp đồng")]
        [Association("Project-Contracts")]
        public XPCollection<Contract.Contract> Contracts
        {
            get
            {
                return GetCollection<Contract.Contract>(nameof(Contracts));
            }
        }
        [XafDisplayName("Thu chi")]
        [Association("Project-Finances")]
        public XPCollection<Finance.Finance> Finances
        {
            get
            {
                return GetCollection<Finance.Finance>(nameof(Finances));
            }
        }
        [XafDisplayName("Công nợ")]
        [Association("Project-Debts")]
        public XPCollection<Debt.Debt> Debts
        {
            get
            {
                return GetCollection<Debt.Debt>(nameof(Debts));
            }
        }

    }
}