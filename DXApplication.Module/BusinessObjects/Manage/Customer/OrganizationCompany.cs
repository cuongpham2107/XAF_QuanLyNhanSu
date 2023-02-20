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
    public class OrganizationCompany : BaseObject
    {
        public OrganizationCompany(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Bank bank;
        string soTaiKhoan;
        string soDienThoai;
        string email;
        string diaChi;
        string tenCoQuan;
        [XafDisplayName("Tên cơ quan")]
        public string TenCoQuan
        {
            get => tenCoQuan;
            set => SetPropertyValue(nameof(TenCoQuan), ref tenCoQuan, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [XafDisplayName("Số điện thoại")]
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
    }
}