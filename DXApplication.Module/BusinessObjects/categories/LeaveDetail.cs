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
    [DefaultProperty(nameof(NghiPhep))]
    [XafDisplayName("Ngày nghỉ phép")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class LeaveDetail : BaseObject
    {
        public LeaveDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        string giaiThich;
        int soNgay;
        string dieuKien;
        string nghiPhep;
        [XafDisplayName("Nghỉ phép")]
        public string NghiPhep
        {
            get => nghiPhep;
            set => SetPropertyValue(nameof(NghiPhep), ref nghiPhep, value);
        }
        [XafDisplayName("Điều kiện")]
        public string DieuKien
        {
            get => dieuKien;
            set => SetPropertyValue(nameof(DieuKien), ref dieuKien, value);
        }
        [XafDisplayName("Số ngày")]
        public int SoNgay
        {
            get => soNgay;
            set => SetPropertyValue(nameof(SoNgay), ref soNgay, value);
        }
        [XafDisplayName("Giải thích")]
        public string GiaiThich
        {
            get => giaiThich;
            set => SetPropertyValue(nameof(GiaiThich), ref giaiThich, value);
        }
    }
}