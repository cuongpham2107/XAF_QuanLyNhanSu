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
using DXApplication.Module.BusinessObjects.Timekeeping;
using DXApplication.Module.Extension;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Calendar = DXApplication.Module.BusinessObjects.Timekeeping.Calendar;

namespace DXApplication.Module.Controllers
{
    public partial class CalendarController : ObjectViewController<ListView, Calendar>
    {
        public CalendarController()
        {
            InitializeComponent();
            Btn_LapDanhSach();

        }
        public void Btn_LapDanhSach()
        {
            var action = new PopupWindowShowAction(this, $"{nameof(Btn_LapDanhSach)}", "Edit")
            {
                Caption = "Lập danh sách",
                ImageName = "Action_Inline_New",
                TargetViewNesting = Nesting.Root,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(Calendar),
                SelectionDependencyType = SelectionDependencyType.Independent,
            };
            action.Execute += LapDanhSach;
            action.CustomizePopupWindowParams += LapDanhSach_CustomizePopupWindowParams;
        }
        public void LapDanhSach_CustomizePopupWindowParams(object s, CustomizePopupWindowParamsEventArgs e)
        {
            NonPersistentObjectSpace os = (NonPersistentObjectSpace)e.Application.CreateObjectSpace(typeof(CalendarParameters));
            os.PopulateAdditionalObjectSpaces(Application);
            e.DialogController.SaveOnAccept = false;
            e.View = e.Application.CreateDetailView(os, os.CreateObject<CalendarParameters>());
        }
        public void LapDanhSach(object s, PopupWindowShowActionExecuteEventArgs e)
        {
            int year = ((CalendarParameters)e.PopupWindowViewCurrentObject).Nam;
            List<DateTime> list = new List<DateTime>();
            for (int i = 1; i <= 12; i++)
            {
                var day = GetDates(year, i);
                foreach (var item in day)
                {
                    list.Add(item);
                }
            }
            List<string> arr = new List<string>() { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
            foreach (var kq in list)
            {
                CultureInfo ciCurr = CultureInfo.CurrentCulture;

                Calendar workDay = ObjectSpace.CreateObject<Calendar>();
                workDay.Ngay = kq;
                workDay.Tuan = ciCurr.Calendar.GetWeekOfYear(kq, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
                workDay.Thu = arr[(int)kq.DayOfWeek];
                workDay.Thang = kq.Month;
                workDay.Nam = kq.Year;
                if (kq.DayOfWeek == DayOfWeek.Sunday)
                {
                    workDay.NgayNghi = true;
                }
                View.CollectionSource.Add(workDay);
            }
            ObjectSpace.CommitChanges();
            View.Refresh();
            Application.ShowViewStrategy.ShowMessage("Lập danh sách ngày công thành công!", InformationType.Success);

        }
        public static List<DateTime> GetDates(int year, int month)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                            .Select(day => new DateTime(year, month, day))
                            .ToList();
        }
    }
    [DomainComponent]
    [XafDisplayName("Chọn giá trị")]
    public class CalendarParameters : IDomainComponent
    {
        [XafDisplayName("Giá trị")]
        public int Nam { get; set; } = DateTime.Now.Year;
    }
    public partial class CalendarStatusController : ViewController
    {
        public CalendarStatusController()
        {
            Btn_NgayNghi();
        }
        public void Btn_NgayNghi()
        {
            var action = new SimpleAction(this, $"{nameof(Btn_NgayNghi)}", "Edit")
            {
                Caption = "Ngày nghỉ",
                ImageName = "Check",
                TargetViewNesting = Nesting.Root,
                TargetViewType = ViewType.Any,
                TargetObjectType = typeof(Calendar),
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects,
            };
            action.Execute += (s, e) =>
            {
                foreach (Calendar item in View.SelectedObjects)
                {
                    item.NgayNghi = true;
                }
                this.ObjectSpace.CommitChanges();
                Application.ShowViewStrategy.ShowMessage("Xác nhận ngày nghỉ thành công!", InformationType.Success);
            };
        }
    }

}
