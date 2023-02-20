using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.Manage.Contract;
using DXApplication.Module.BusinessObjects.Manage.Projects;
using System;
using System.ComponentModel;
using System.Linq;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage.Document
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(TenTaiLieu))]
    [XafDisplayName("Tài liệu")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Document : BaseObject
    {
        public Document(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Project project;
        Contract_B contract_B;
        string tomTat;
        ThuocTinh_TaiLieu thuocTinh_TaiLieu;
        FileData file;
        string duongLink;
        Personnel nguoiSua;
        DateTime? thoiGianSua;
        Personnel personnel;
        DateTime? ngayTao;
        Document_Group document_Group;
        string tenTaiLieu;
        [XafDisplayName("Tên tài liệu")]
        public string TenTaiLieu
        {
            get => tenTaiLieu;
            set => SetPropertyValue(nameof(TenTaiLieu), ref tenTaiLieu, value);
        }
        [XafDisplayName("Nhóm tài liệu")]
        public Document_Group Document_Group
        {
            get => document_Group;
            set => SetPropertyValue(nameof(Document_Group), ref document_Group, value);
        }
        [XafDisplayName("Thời gian tạo")]
        public DateTime? NgayTao
        {
            get => ngayTao;
            set => SetPropertyValue(nameof(NgayTao), ref ngayTao, value);
        }
        [XafDisplayName("Người tạo")]
        public Personnel Personnel
        {
            get => personnel;
            set => SetPropertyValue(nameof(Personnel), ref personnel, value);
        }
        [XafDisplayName("Thời gian sửa")]
        public DateTime? ThoiGianSua
        {
            get => thoiGianSua;
            set => SetPropertyValue(nameof(ThoiGianSua), ref thoiGianSua, value);
        }
        [XafDisplayName("Người sửa")]
        public Personnel NguoiSua
        {
            get => nguoiSua;
            set => SetPropertyValue(nameof(NguoiSua), ref nguoiSua, value);
        }
        [XafDisplayName("Đường link")]
        public string DuongLink
        {
            get => duongLink;
            set => SetPropertyValue(nameof(DuongLink), ref duongLink, value);
        }

        public FileData File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [XafDisplayName("Thuộc tính")]
        public ThuocTinh_TaiLieu ThuocTinh_TaiLieu
        {
            get => thuocTinh_TaiLieu;
            set => SetPropertyValue(nameof(ThuocTinh_TaiLieu), ref thuocTinh_TaiLieu, value);
        }
        [XafDisplayName("Hợp đồng")]
        public Contract_B Contract_B
        {
            get => contract_B;
            set => SetPropertyValue(nameof(Contract_B), ref contract_B, value);
        }
        [XafDisplayName("Dự án")]
        [Association("Project-Documents")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }
        [XafDisplayName("Tóm tắt")]
        [Size(SizeAttribute.Unlimited)]
        public string TomTat
        {
            get => tomTat;
            set => SetPropertyValue(nameof(TomTat), ref tomTat, value);
        }
    }
}