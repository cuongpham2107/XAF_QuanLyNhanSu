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
    [XafDisplayName("Công nợ phải trả")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    public class DebtOut : Debt
    {
        public DebtOut(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        int daTra;
        Contract_A contract_A;
        [XafDisplayName("Hợp đồng bên mua")]
        public Contract_A Contract_A
        {
            get => contract_A;
            set => SetPropertyValue(nameof(Contract_A), ref contract_A, value);
        }
        [XafDisplayName("Đã trả")]
        public int DaTra
        {
            get => daTra;
            set => SetPropertyValue(nameof(DaTra), ref daTra, value);
        }
        [XafDisplayName("Quá trình trả")]
        [Association("DebtOut-FinanceOutcomes")]
        public XPCollection<FinanceOutcome> FinanceOutcomes
        {
            get
            {
                return GetCollection<FinanceOutcome>(nameof(FinanceOutcomes));
            }
        }
    }
}