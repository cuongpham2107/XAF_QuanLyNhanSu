using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DXApplication.Module.BusinessObjects.categories;
using DXApplication.Module.BusinessObjects.Timekeeping;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.Controllers
{

    public partial class ChamCongController : ViewController
    {
        public ChamCongController()
        {
            InitializeComponent();
            Btn_ChamSang();
            Btn_ChamChieu();
            Btn_NghiPhep();
        }
        public void Btn_ChamChieu()
        {
            var action = new PopupWindowShowAction(this, $"{nameof(Btn_ChamChieu)}", "Edit")
            {
                Caption = "Chấm chiều",
                ImageName = "Action_Validation_Validate",
                TargetViewNesting = Nesting.Nested,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(TimeSheet),
                TargetObjectsCriteria = "[Chieu] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh#",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
            };
            action.CustomizePopupWindowParams += (object s, CustomizePopupWindowParamsEventArgs e) =>
            {
                NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(ChamCongParameters));
                os.PopulateAdditionalObjectSpaces(Application);
                e.DialogController.SaveOnAccept = false;
                e.View = e.Application.CreateDetailView(os, os.CreateObject<ChamCongParameters>());
            };
            action.Execute += (object s, PopupWindowShowActionExecuteEventArgs e) =>
            {
                var chamcong = ((ChamCongParameters)e.PopupWindowViewCurrentObject).ChamCong;
                foreach (TimeSheet item in View.SelectedObjects)
                {
                    item.Chieu = chamcong;
                }
                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Đã chấm công thành công!", InformationType.Success);
            };
        }
        public void Btn_ChamSang()
        {
            var action = new PopupWindowShowAction(this, $"{nameof(Btn_ChamSang)}", "Edit")
            {
                Caption = "Chấm sáng",
                ImageName = "Action_Validation_Validate",
                TargetViewNesting = Nesting.Nested,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(TimeSheet),
                TargetObjectsCriteria = "[Sang] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh#",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
            };
            action.CustomizePopupWindowParams += (object s, CustomizePopupWindowParamsEventArgs e) =>
            {
                NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(ChamCongParameters));
                os.PopulateAdditionalObjectSpaces(Application);
                e.DialogController.SaveOnAccept = false;
                e.View = e.Application.CreateDetailView(os, os.CreateObject<ChamCongParameters>());
            };
            action.Execute += (s, e) =>
            {
                var chamcong = ((ChamCongParameters)e.PopupWindowViewCurrentObject).ChamCong;
                foreach (TimeSheet item in View.SelectedObjects)
                {
                    item.Sang = chamcong;
                }
                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Đã chấm công thành công!", InformationType.Success);
            };
        }
        public void Btn_NghiPhep()
        {
            var action = new PopupWindowShowAction(this, $"{nameof(Btn_NghiPhep)}", "Edit")
            {
                Caption = "Phép",
                ImageName = "Action_SimpleAction",
                TargetViewNesting = Nesting.Nested,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(TimeSheet),
                TargetObjectsCriteria = "[Sang] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh# Or [Chieu] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh#",
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
            };
            action.CustomizePopupWindowParams += (object s, CustomizePopupWindowParamsEventArgs e) =>
            {
                NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(NghiPhepParameters));
                os.PopulateAdditionalObjectSpaces(Application);
                e.DialogController.SaveOnAccept = false;
                e.View = e.Application.CreateDetailView(os, os.CreateObject<NghiPhepParameters>());
            };
            action.Execute += (s, e) =>
            {
                var nghiphep = ((NghiPhepParameters)e.PopupWindowViewCurrentObject).NghiPhep;
                foreach (TimeSheet item in View.SelectedObjects)
                {
                    item.LeaveDetail = nghiphep;
                }
                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Cập nhập thành công!", InformationType.Success);
            };
        }

    }
    [DomainComponent]
    [XafDisplayName("Chấm công")]
    public class ChamCongParameters : IDomainComponent
    {
        [XafDisplayName("Chọn tình trạng (* Không chọn nghỉ phép)")]
        public ChamCong ChamCong { get; set; }
    }

    [DomainComponent]
    [XafDisplayName("Nghỉ phép")]
    public class NghiPhepParameters : IDomainComponent
    {
        [XafDisplayName("Lý do nghỉ phép")]
        public LeaveDetail NghiPhep { get; set; }
    }
}
