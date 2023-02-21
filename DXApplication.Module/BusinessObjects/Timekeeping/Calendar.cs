using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Blazor.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DXApplication.Module.BusinessObjects.Timekeeping
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuJob)]
    [XafDisplayName("Ngày làm việc")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]



    [Appearance("NgayNghi", AppearanceItemType = "ViewItem", TargetItems = "*", Criteria = "[NgayNghi] = True", Context = "Any", FontColor = "Red", FontStyle = System.Drawing.FontStyle.Bold, Priority = 1)]
    [ListViewFilter("Tất cả", "", Index = 0)]
    [ListViewFilter("Hôm nay", "[Ngay] = Today()", Index = 1)]
    [ListViewFilter("Tuần này", "IsThisWeek([Ngay])", Index = 2)]
    [ListViewFilter("Tháng này", "[Thang] = GetMonth(Today())", Index = 3)]


    public class Calendar : BaseObject
    {
        public Calendar(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        bool ngayNghi;
        string ghiCHu;
        int nam;
        int thang;
        int tuan;
        string thu;
        DateTime ngay;
        [XafDisplayName("Ngày")]
        public DateTime Ngay
        {
            get => ngay;
            set => SetPropertyValue(nameof(Ngay), ref ngay, value);
        }
        [XafDisplayName("Thứ")]
        public string Thu
        {
            get => thu;
            set => SetPropertyValue(nameof(Thu), ref thu, value);
        }
        [XafDisplayName("Tuần")]
        public int Tuan
        {
            get => tuan;
            set => SetPropertyValue(nameof(Tuan), ref tuan, value);
        }
        [XafDisplayName("Tháng")]
        public int Thang
        {
            get => thang;
            set => SetPropertyValue(nameof(Thang), ref thang, value);
        }
        [XafDisplayName("Năm")]
        public int Nam
        {
            get => nam;
            set => SetPropertyValue(nameof(Nam), ref nam, value);
        }
        [XafDisplayName("Ngày nghỉ")]
        public bool NgayNghi
        {
            get => ngayNghi;
            set => SetPropertyValue(nameof(NgayNghi), ref ngayNghi, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiCHu
        {
            get => ghiCHu;
            set => SetPropertyValue(nameof(GhiCHu), ref ghiCHu, value);
        }
        [XafDisplayName("Chấm công")]
        [Association("Calendar-TimeSheets")]
        public XPCollection<TimeSheet> TimeSheets
        {
            get
            {
                return GetCollection<TimeSheet>(nameof(TimeSheets));
            }
        }
    }
}