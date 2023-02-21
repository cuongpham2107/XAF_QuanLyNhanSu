﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.Manage.Debt;
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
    [XafDisplayName("Hợp đồng cung cấp (B)")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class Contract_B : Contract
    {
        public Contract_B(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        DebtIn debtIn;
        int conNo;
        int tongThu;
        int giaTri;
        [XafDisplayName("Giá trị")]
        [DetailViewLayout("Tài chính", 2)]
        public int GiaTri
        {
            get => giaTri;
            set => SetPropertyValue(nameof(GiaTri), ref giaTri, value);
        }
        [XafDisplayName("Tổng thu")]
        [DetailViewLayout("Tài chính", 2)]
        public int TongThu
        {
            get => tongThu;
            set => SetPropertyValue(nameof(TongThu), ref tongThu, value);
        }
        [XafDisplayName("Còn nợ")]
        [DetailViewLayout("Tài chính", 2)]
        public int ConNo
        {
            get => conNo;
            set => SetPropertyValue(nameof(ConNo), ref conNo, value);
        }
        [XafDisplayName("Công nợ phải thu")]
        [DetailViewLayout("Tài chính", 2)]
        public DebtIn DebtIn
        {
            get => debtIn;
            set => SetPropertyValue(nameof(DebtIn), ref debtIn, value);
        }
    }
}