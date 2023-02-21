using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.XtraPrinting.Native;
using DXApplication.Blazor.Common;
using DXApplication.Module.BusinessObjects.categories;
using DXApplication.Module.BusinessObjects.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.BusinessObjects.Timekeeping
{
    [DefaultClassOptions]
    [NavigationItem(Menu.MenuJob)]
    [XafDisplayName("Chấm công")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]



    [Appearance("Sang", AppearanceItemType = "ViewItem", TargetItems = "Sang", Criteria = "[Sang] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh#", Context = "Any", FontColor = "Red", FontStyle = System.Drawing.FontStyle.Bold, Priority = 1)]
    [Appearance("Chieu", AppearanceItemType = "ViewItem", TargetItems = "Chieu", Criteria = "[Chieu] = ##Enum#DXApplication.Blazor.Common.Enum+ChamCong,chuadiemdanh#", Context = "Any", FontColor = "Red", FontStyle = System.Drawing.FontStyle.Bold, Priority = 1)]
    public class TimeSheet : BaseObject
    {
        public TimeSheet(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        Calendar calendar;
        double cong;
        string ghiChu;
        int ngoaiGio;
        LeaveDetail leaveDetail;
        ChamCong sang;
        ChamCong chieu;
        Personnel personnel;
        int nam;
        int thang;
        int tuan;
        string thu;

        [Association("Calendar-TimeSheets")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public Calendar Calendar
        {
            get => calendar;
            set => SetPropertyValue(nameof(Calendar), ref calendar, value);
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
        [XafDisplayName("Nhân viên")]
        public Personnel Personnel
        {
            get => personnel;
            set => SetPropertyValue(nameof(Personnel), ref personnel, value);
        }
        [XafDisplayName("Sáng")]
        public ChamCong Sang
        {
            get => sang;
            set => SetPropertyValue(nameof(Sang), ref sang, value);
        }
        [XafDisplayName("Chiều")]
        public ChamCong Chieu
        {
            get => chieu;
            set => SetPropertyValue(nameof(Chieu), ref chieu, value);
        }
        [XafDisplayName("Lý do nghỉ phép")]
        public LeaveDetail LeaveDetail
        {
            get => leaveDetail;
            set => SetPropertyValue(nameof(LeaveDetail), ref leaveDetail, value);
        }
        [XafDisplayName("Ngoài giờ")]
        public int NgoaiGio
        {
            get => ngoaiGio;
            set => SetPropertyValue(nameof(NgoaiGio), ref ngoaiGio, value);
        }
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }
        [XafDisplayName("Công")]
        public double Cong
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    double tinhcong = 0;
                    switch (Sang)
                    {
                        case ChamCong.vang:
                            tinhcong += 0;
                            break;
                        case ChamCong.comat:
                            tinhcong += 0.5;
                            break;
                        case ChamCong.nghiphep:
                            tinhcong += 0;
                            break;
                        case ChamCong.denmuonvesom:
                            tinhcong += 0.25;
                            break;
                        case ChamCong.chuadiemdanh:
                            tinhcong += 0;
                            break;
                    }
                    switch (Chieu)
                    {
                        case ChamCong.vang:
                            tinhcong += 0;
                            break;
                        case ChamCong.comat:
                            tinhcong += 0.5;
                            break;
                        case ChamCong.nghiphep:
                            tinhcong += 0;
                            break;
                        case ChamCong.denmuonvesom:
                            tinhcong += 0.25;
                            break;
                        case ChamCong.chuadiemdanh:
                            tinhcong += 0;
                            break;

                    }
                    return tinhcong;
                }
                return cong;
            }
            set => SetPropertyValue(nameof(Cong), ref cong, value);
        }
    }
}