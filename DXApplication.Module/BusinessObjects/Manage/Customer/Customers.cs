using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Module.BusinessObjects.categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Manage.Customer
{
    [DefaultClassOptions]
    public class Customers : BaseObject
    {
        public Customers(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int hopDong;
        Bank bank;
        string soTaiKhoan;
        string soDienThoai;
        string email;
        DateTime? ngaySinh;
        string soCCCD;
        string chuVu;
        OrganizationCompany coQuan;
        string diaChi;
        string hoTen;
        [XafDisplayName("Họ tên")]
        public string HoTen
        {
            get => hoTen;
            set => SetPropertyValue(nameof(HoTen), ref hoTen, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Cơ quan")]
        public OrganizationCompany CoQuan
        {
            get => coQuan;
            set => SetPropertyValue(nameof(CoQuan), ref coQuan, value);
        }
        [XafDisplayName("Chức vụ")]
        public string ChuVu
        {
            get => chuVu;
            set => SetPropertyValue(nameof(ChuVu), ref chuVu, value);
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
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [XafDisplayName("Sô điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        [XafDisplayName("Số tài khoản")]
        public string SoTaiKhoan
        {
            get => soTaiKhoan;
            set => SetPropertyValue(nameof(SoTaiKhoan), ref soTaiKhoan, value);
        }
        [XafDisplayName("Ngân hàng")]
        public Bank Bank
        {
            get => bank;
            set => SetPropertyValue(nameof(Bank), ref bank, value);
        }
        [XafDisplayName("Hợp đồng")]
        public int HopDong
        {
            get => hopDong;
            set => SetPropertyValue(nameof(HopDong), ref hopDong, value);
        }
    }
}