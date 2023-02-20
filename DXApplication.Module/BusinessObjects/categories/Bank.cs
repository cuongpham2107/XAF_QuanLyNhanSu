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
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(NganHang))]
    [XafDisplayName("Ngân hàng")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Bank : BaseObject
    {
        public Bank(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string tenDayDu;
        string tenVietTat;
        string nganHang;
        [XafDisplayName("Ngân hàng")]
        public string NganHang
        {
            get => nganHang;
            set => SetPropertyValue(nameof(NganHang), ref nganHang, value);
        }
        [XafDisplayName("Tên viết tắt")]
        public string TenVietTat
        {
            get => tenVietTat;
            set => SetPropertyValue(nameof(TenVietTat), ref tenVietTat, value);
        }
        [XafDisplayName("Tên đầy đủ")]
        public string TenDayDu
        {
            get => tenDayDu;
            set => SetPropertyValue(nameof(TenDayDu), ref tenDayDu, value);
        }
    }
}