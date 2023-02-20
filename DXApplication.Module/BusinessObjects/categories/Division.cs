using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.categories
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuCatalog)]
    [DefaultProperty(nameof(TenBoPhan))]
    [XafDisplayName("Bộ phận")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class Division : BaseObject, IListViewInline
    {
        public Division(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string ghiChu;
        string tenBoPhan;
        [XafDisplayName("Tên bộ phân")]
        [RuleRequiredField("Division.TenBoPhan trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string TenBoPhan
        {
            get => tenBoPhan;
            set => SetPropertyValue(nameof(TenBoPhan), ref tenBoPhan, value);
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