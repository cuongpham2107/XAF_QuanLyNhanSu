using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
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
    [XafDisplayName("Thu")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class FinanceIncome : BaseObject
    {
        public FinanceIncome(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        DebtIn congNoPhaiThu;
        Contract_B contract_B;
        FinanceInCategory financeInCategory;
        [XafDisplayName("Khoản mục thu")]
        [RuleRequiredField("FinanceIncome.FinanceInCategory trường bắt buộc", DefaultContexts.Save, "Khoản mục chi phải có")]
        public FinanceInCategory FinanceInCategory
        {
            get => financeInCategory;
            set => SetPropertyValue(nameof(FinanceInCategory), ref financeInCategory, value);
        }
        [XafDisplayName("Hợp đồng cung cấp (B)")]
        public Contract_B Contract_B
        {
            get => contract_B;
            set => SetPropertyValue(nameof(Contract_B), ref contract_B, value);
        }
        [XafDisplayName("Công nợ phải thu")]
        [Association("DebtIn-FinanceIncomes")]
        public DebtIn CongNoPhaiThu
        {
            get => congNoPhaiThu;
            set => SetPropertyValue(nameof(CongNoPhaiThu), ref congNoPhaiThu, value);
        }
    }
}