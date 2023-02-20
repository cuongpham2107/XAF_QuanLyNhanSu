using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.categories;
using DXApplication.Module.BusinessObjects.Manage.Contract;
using DXApplication.Module.BusinessObjects.Manage.Debt;
using System;
using System.Linq;

namespace DXApplication.Module.BusinessObjects.Manage.Finance
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuManage)]
    [XafDisplayName("Chi")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]

    public class FinanceOutcome : Finance
    {
        public FinanceOutcome(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Contract_A contract_A;
        DebtOut congNoPhaiTra;
        FinanceOutCategory khoanMucChi;
        [XafDisplayName("Khoản mục chi")]
        [RuleRequiredField("FinanceOutcome.KhoanMucChi trường bắt buộc", DefaultContexts.Save, "Khoản mục chi phải có")]
        public FinanceOutCategory KhoanMucChi
        {
            get => khoanMucChi;
            set => SetPropertyValue(nameof(KhoanMucChi), ref khoanMucChi, value);
        }
        [XafDisplayName("Hợp đồng thuê mua (A)")]

        public Contract_A Contract_A
        {
            get => contract_A;
            set => SetPropertyValue(nameof(Contract_A), ref contract_A, value);
        }
        [XafDisplayName("Công nợ phải trả")]
        [Association("DebtOut-FinanceOutcomes")]
        public DebtOut CongNoPhaiTra
        {
            get => congNoPhaiTra;
            set => SetPropertyValue(nameof(CongNoPhaiTra), ref congNoPhaiTra, value);
        }
    }
}