
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.categories;
using DXApplication.Module.BusinessObjects.Manage.Customer;
using DXApplication.Module.BusinessObjects.Manage.Projects;
using System;
using System.ComponentModel;
using System.Linq;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Manage.Contract
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(TenHopDong))]
    [XafDisplayName("Hợp đồng")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public abstract class Contract : BaseObject
    {
        public Contract(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string ghiChu;
        Project duAn;
        DateTime? ketThuc;
        DateTime? batDau;
        DateTime? ngayKi;
        TrangThaiHopDong trangThaiHopDong;
        Customers customer;
        string soHopDong;
        LoaiHopDongCungCap loaiHopDongCungCap;
        LoaiHopDong loaiHopDong;
        Type_Contract nhomHopDong;
        string tenHopDong;
        [XafDisplayName("Tên hợp đồng")]
        [RuleRequiredField("Contract.TenHopDong trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string TenHopDong
        {
            get => tenHopDong;
            set => SetPropertyValue(nameof(TenHopDong), ref tenHopDong, value);
        }
        [XafDisplayName("Nhóm hợp đồng")]
        [RuleRequiredField("Contract.NhomHopDong trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public Type_Contract NhomHopDong
        {
            get => nhomHopDong;
            set => SetPropertyValue(nameof(NhomHopDong), ref nhomHopDong, value);
        }
        [XafDisplayName("Loại hợp đồng")]
        public LoaiHopDong LoaiHopDong
        {
            get => loaiHopDong;
            set => SetPropertyValue(nameof(LoaiHopDong), ref loaiHopDong, value);
        }
        [XafDisplayName("Loại hợp đồng cung cấp")]
        public LoaiHopDongCungCap LoaiHopDongCungCap
        {
            get => loaiHopDongCungCap;
            set => SetPropertyValue(nameof(LoaiHopDongCungCap), ref loaiHopDongCungCap, value);
        }
        [XafDisplayName("Số hợp đồng")]
        [RuleRequiredField("Contract.SoHopDong trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string SoHopDong
        {
            get => soHopDong;
            set => SetPropertyValue(nameof(SoHopDong), ref soHopDong, value);
        }
        [XafDisplayName("Đối tác")]
        [RuleRequiredField("Contract.Customer trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public Customers Customer
        {
            get => customer;
            set => SetPropertyValue(nameof(Customer), ref customer, value);
        }
        [XafDisplayName("Trạng thái")]
        public TrangThaiHopDong TrangThaiHopDong
        {
            get => trangThaiHopDong;
            set => SetPropertyValue(nameof(TrangThaiHopDong), ref trangThaiHopDong, value);
        }
        [XafDisplayName("Ngày kí")]
        [RuleRequiredField("Contract.NgayKi trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public DateTime? NgayKi
        {
            get => ngayKi;
            set => SetPropertyValue(nameof(NgayKi), ref ngayKi, value);
        }
        [XafDisplayName("Bắt đầu")]
        [RuleRequiredField("Contract.BatDau trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public DateTime? BatDau
        {
            get => batDau;
            set => SetPropertyValue(nameof(BatDau), ref batDau, value);
        }
        [XafDisplayName("Kết thúc")]
        [RuleRequiredField("Contract.KetThuc trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public DateTime? KetThuc
        {
            get => ketThuc;
            set => SetPropertyValue(nameof(KetThuc), ref ketThuc, value);
        }
        [XafDisplayName("Dự án")]
        [Association("Project-Contracts")]
        public Project DuAn
        {
            get => duAn;
            set => SetPropertyValue(nameof(DuAn), ref duAn, value);
        }
        [XafDisplayName("Ghi Chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}