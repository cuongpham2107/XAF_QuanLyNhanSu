using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DXApplication.Module.BusinessObjects.Manage;
using DXApplication.Module.BusinessObjects.Timekeeping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static DXApplication.Blazor.Common.Enum;

namespace DXApplication.Module.Controllers
{
    public partial class TimeSheetController : ObjectViewController<ListView, TimeSheet>
    {

        public TimeSheetController()
        {
            InitializeComponent();
            Btn_TimeSheet();

        }
        public void Btn_TimeSheet()
        {
            var action = new SimpleAction(this, $"{Btn_TimeSheet}", "Edit")
            {
                Caption = "Bảng chấm công",
                ImageName = "Action_Inline_New",
                TargetViewNesting = Nesting.Nested,
                TargetViewType = ViewType.ListView,
                TargetObjectType = typeof(TimeSheet),
                SelectionDependencyType = SelectionDependencyType.Independent,
            };
            action.Execute += (s, e) =>
            {
                if (((DetailView)ObjectSpace.Owner).CurrentObject is Calendar wdl)
                {
                    var nhanvien = ObjectSpace.GetObjectsQuery<Personnel>().ToList();
                    if (nhanvien?.Any() != true)
                    {
                        Application.ShowViewStrategy.ShowMessage("Chưa có nhân viên nào", InformationType.Error);
                    }
                    else
                    {
                        var workdaylist = ObjectSpace.GetObject(wdl);
                        TimeSheet person = ObjectSpace.FirstOrDefault<TimeSheet>(p => p.Thu == workdaylist.Thu);
                        if (person != null)
                        {
                            Application.ShowViewStrategy.ShowMessage("Đã có bảng chấp công rồi ", InformationType.Error);
                        }
                        else
                        {
                            foreach (var item in nhanvien)
                            {
                                TimeSheet timeSheet = ObjectSpace.CreateObject<TimeSheet>();

                                timeSheet.Calendar = workdaylist;
                                timeSheet.Thu = workdaylist.Thu;
                                timeSheet.Tuan = workdaylist.Tuan;
                                timeSheet.Thang = workdaylist.Thang;
                                timeSheet.Nam = workdaylist.Nam;
                                timeSheet.Personnel = item;
                                timeSheet.GhiChu = string.Empty;
                                timeSheet.Sang = ChamCong.chuadiemdanh;
                                timeSheet.Chieu = ChamCong.chuadiemdanh;
                                View.CollectionSource.Add(timeSheet);
                            }
                            ObjectSpace.CommitChanges();
                            View.Refresh();
                            Application.ShowViewStrategy.ShowMessage("Lập bảng chấm công thành công");
                        }
                    }
                }
            };
        }
    }
}
