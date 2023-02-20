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

namespace DXApplication.Module.BusinessObjects.Manage.Contract
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty(nameof(TenHopDong))]
    [XafDisplayName("Hợp đồng thuê mua (A)")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Contract_A : Contract
    {
        public Contract_A(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        float conNo;
        float tongChi;
        float giaTri;
        [XafDisplayName("Giá trị")]
        [DetailViewLayout("Tài chính", 2)]
        public float GiaTri
        {
            get => giaTri;
            set => SetPropertyValue(nameof(GiaTri), ref giaTri, value);
        }
        [XafDisplayName("Tổng chi")]
        [DetailViewLayout("Tài chính", 2)]
        public float TongChi
        {
            get => tongChi;
            set => SetPropertyValue(nameof(TongChi), ref tongChi, value);
        }
        [XafDisplayName("Còn nợ")]
        [DetailViewLayout("Tài chính", 2)]
        public float ConNo
        {
            get => conNo;
            set => SetPropertyValue(nameof(ConNo), ref conNo, value);
        }


    }
}