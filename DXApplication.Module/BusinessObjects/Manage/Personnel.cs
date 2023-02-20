using DevExpress.Data.Filtering;
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(HoTen))]
    [XafDisplayName("Nhận sự")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Personnel : BaseObject
    {
        public Personnel(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string cachTinhLuong;
        Job_position job_Position;
        NhomNhanVien nhomNhanVien;
        bool dangLamViec;
        string diaChi;
        string email;
        string soDienThoai;
        DateTime? ngaySinh;
        string soCCCD;
        string hoTen;
        [XafDisplayName("Họ và tên")]
        public string HoTen
        {
            get => hoTen;
            set => SetPropertyValue(nameof(HoTen), ref hoTen, value);
        }
        [XafDisplayName("Số CCCD")]
        public string SoCCCD
        {
            get => soCCCD;
            set => SetPropertyValue(nameof(SoCCCD), ref soCCCD, value);
        }
        [XafDisplayName("Ngày sinh")]
        public DateTime? NgaySinh
        {
            get => ngaySinh;
            set => SetPropertyValue(nameof(NgaySinh), ref ngaySinh, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }

        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Đang làm việc")]
        public bool DangLamViec
        {
            get => dangLamViec;
            set => SetPropertyValue(nameof(DangLamViec), ref dangLamViec, value);
        }

        [XafDisplayName("Nhóm nhân viên")]

        public NhomNhanVien NhomNhanVien
        {
            get => nhomNhanVien;
            set => SetPropertyValue(nameof(NhomNhanVien), ref nhomNhanVien, value);
        }
        [XafDisplayName("Vị trí việc làm")]
        public Job_position Job_Position
        {
            get => job_Position;
            set => SetPropertyValue(nameof(Job_Position), ref job_Position, value);
        }
        [XafDisplayName("Cách tính lương")]
        public string CachTinhLuong
        {
            get => cachTinhLuong;
            set => SetPropertyValue(nameof(CachTinhLuong), ref cachTinhLuong, value);
        }
    }
}