using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(TenViTri))]
    [XafDisplayName("Vị trí việc làm")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Job_position : BaseObject
    {
        public Job_position(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        bool status;
        FileData file;
        DateTime? ngayQuyetDinh;
        TrangThaiViTriViecLam trangThaiViTriViecLam;
        Division division;
        CapBac capBac;
        NhomNhanVien nhomNhanVien;
        string tenViTri;
        [XafDisplayName("Tên vị trí việc làm")]
        public string TenViTri
        {
            get => tenViTri;
            set => SetPropertyValue(nameof(TenViTri), ref tenViTri, value);
        }
        [XafDisplayName("Nhóm nhân viên")]
        public NhomNhanVien NhomNhanVien
        {
            get => nhomNhanVien;
            set => SetPropertyValue(nameof(NhomNhanVien), ref nhomNhanVien, value);
        }
        [XafDisplayName("Cấp độ")]
        public CapBac CapBac
        {
            get => capBac;
            set => SetPropertyValue(nameof(CapBac), ref capBac, value);
        }
        [XafDisplayName("Bộ phận")]
        public Division Division
        {
            get => division;
            set => SetPropertyValue(nameof(Division), ref division, value);
        }
        [XafDisplayName("Trạng thái")]
        public TrangThaiViTriViecLam TrangThaiViTriViecLam
        {
            get => trangThaiViTriViecLam;
            set => SetPropertyValue(nameof(TrangThaiViTriViecLam), ref trangThaiViTriViecLam, value);
        }
        [XafDisplayName("Ngày quyết định")]
        [RuleRequiredField("Job_position.NgayQuyetDinh trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public DateTime? NgayQuyetDinh
        {
            get => ngayQuyetDinh;
            set => SetPropertyValue(nameof(NgayQuyetDinh), ref ngayQuyetDinh, value);
        }
        [XafDisplayName("File quyết định")]
        public FileData File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }
        [XafDisplayName("Áp dụng")]
        public bool Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }
    }
}