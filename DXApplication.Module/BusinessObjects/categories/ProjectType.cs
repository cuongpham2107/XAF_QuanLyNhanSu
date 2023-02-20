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
    [DefaultProperty(nameof(LoaiDuAn))]
    [XafDisplayName("Loại dự án")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class ProjectType : BaseObject
    {
        public ProjectType(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        string moTa;
        string loaiDuAn;
        [XafDisplayName("Loại dự án")]
        [RuleRequiredField("ProjectType.LoaiDuAn trường bắt buộc", DefaultContexts.Save, "Tên loại dự án phải có")]
        public string LoaiDuAn
        {
            get => loaiDuAn;
            set => SetPropertyValue(nameof(LoaiDuAn), ref loaiDuAn, value);
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