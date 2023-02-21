using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.Manage.Contract;
using DXApplication.Module.BusinessObjects.Manage.Finance;
using System;
using System.ComponentModel;
using System.Linq;

namespace DXApplication.Module.BusinessObjects.Manage.Debt
{
    [DefaultClassOptions]

    [NavigationItem(Menu.MenuManage)]
    [DefaultProperty($"[{nameof(LoaiCongNo)}] {nameof(NoiDung)} ({nameof(TongSoTien)})")]
    [XafDisplayName("Công nợ phải thu")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class DebtIn : Debt
    {
        public DebtIn(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        int daThu;
        Contract_B contract_B;
        [XafDisplayName("Hợp đồng cung cấp")]

        public Contract_B Contract_B
        {
            get => contract_B;
            set => SetPropertyValue(nameof(Contract_B), ref contract_B, value);
        }
        [XafDisplayName("Đã thu")]
        public int DaThu
        {
            get => daThu;
            set => SetPropertyValue(nameof(DaThu), ref daThu, value);
        }
        [XafDisplayName("Quá trình thu")]
        [Association("DebtIn-FinanceIncomes")]
        public XPCollection<FinanceIncome> FinanceIncomes
        {
            get
            {
                return GetCollection<FinanceIncome>(nameof(FinanceIncomes));
            }
        }
    }
}