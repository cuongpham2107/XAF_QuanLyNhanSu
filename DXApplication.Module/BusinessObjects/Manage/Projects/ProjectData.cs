using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using System;
using System.ComponentModel;
using System.Linq;

namespace DXApplication.Module.BusinessObjects.Manage.Projects
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(ThongTin))]
    [XafDisplayName("Dữ liệu dự án")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class ProjectData : BaseObject
    {
        public ProjectData(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Project project;
        string moTa;
        bool trangThai;
        FileData file;
        bool status;
        int soLuong;
        DateTime? thoiHan;
        int giaTri;
        string thongTin;

        [XafDisplayName("Dự án")]
        [Association("Project-ProjectDatas")]
        public Project Project
        {
            get => project;
            set => SetPropertyValue(nameof(Project), ref project, value);
        }
        [XafDisplayName("Thông tin")]
        public string ThongTin
        {
            get => thongTin;
            set => SetPropertyValue(nameof(ThongTin), ref thongTin, value);
        }
        [XafDisplayName("Giá trị")]
        public int GiaTri
        {
            get => giaTri;
            set => SetPropertyValue(nameof(GiaTri), ref giaTri, value);
        }
        [XafDisplayName("Thời hạn")]
        public DateTime? ThoiHan
        {
            get => thoiHan;
            set => SetPropertyValue(nameof(ThoiHan), ref thoiHan, value);
        }
        [XafDisplayName("Số lượng")]
        public int SoLuong
        {
            get => soLuong;
            set => SetPropertyValue(nameof(SoLuong), ref soLuong, value);
        }
        [XafDisplayName("Có/Không")]
        public bool Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }

        public FileData File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [XafDisplayName("Bỏ qua")]
        public bool TrangThai
        {
            get => trangThai;
            set => SetPropertyValue(nameof(TrangThai), ref trangThai, value);
        }
        [XafDisplayName("Mô tả")]
        [Size(SizeAttribute.Unlimited)]
        public string MoTa
        {
            get => moTa;
            set => SetPropertyValue(nameof(MoTa), ref moTa, value);
        }
    }
}