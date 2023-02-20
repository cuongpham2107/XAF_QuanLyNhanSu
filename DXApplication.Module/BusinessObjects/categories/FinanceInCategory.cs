using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using System;
using System.ComponentModel;
using System.Linq;

namespace DXApplication.Module.BusinessObjects.categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(TenKhoanMuc))]
    [XafDisplayName("Khoản mục thu")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class FinanceInCategory : BaseObject
    {
        public FinanceInCategory(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        string ghiChu;
        string tenKhoanMuc;
        [XafDisplayName("Tên khoản mục")]
        public string TenKhoanMuc
        {
            get => tenKhoanMuc;
            set => SetPropertyValue(nameof(TenKhoanMuc), ref tenKhoanMuc, value);
        }
        [XafDisplayName("Ghi chú")]
        [Size(SizeAttribute.Unlimited)]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
    }
}