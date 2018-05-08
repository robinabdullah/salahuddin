using BioMetrixCore;
using salahuddinahmed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salahuddinahmed.Controllers
{
    public class FetchDeviceRecordController : Controller
    {
        // GET: FetchDeviceRecord
        DeviceManipulator manipulator = new DeviceManipulator();
        public ZkemClient objZkeeper;

        [HttpGet]
        public List<Attendance_Record> fetchAttendance(AttendanceDataConfig config)
        {
            try
            {
                objZkeeper = new ZkemClient(RaiseDeviceEvent);
                bool IsDeviceConnected = objZkeeper.Connect_Net(config.IPAddress, config.PortNumber);
                int todaysRecord = 0;
                if (IsDeviceConnected)
                {
                    string deviceInfo = manipulator.FetchDeviceInfo(objZkeeper, config.MachineNumber);///tbxMachineNumber.Text.Trim()
                    ///lblDeviceInfo.Text = deviceInfo;
                    ICollection<MachineInfo> lstMachineInfo = manipulator.GetLogData(objZkeeper, config.MachineNumber);///tbxMachineNumber.Text.Trim()
                    var attendanceRecord = new List<Attendance_Record>();
                    foreach (var item in lstMachineInfo)
                    {
                        if (DateTime.Compare(item.DateOnlyRecord, config.DateTo) == 0)///DateTime.Parse(item.DateTimeRecord).Date
                        {
                            attendanceRecord.Add(new Attendance_Record() { Information_Id = item.IndRegID, Attendance_Timing = DateTime.Parse(item.DateTimeRecord) });
                            todaysRecord++;
                        }
                    }
                    return attendanceRecord;
                }
                return new List<Attendance_Record>();
            }
            catch (Exception ex)
            {
                return new List<Attendance_Record>();
            }
        }

        private void RaiseDeviceEvent(object sender, string actionType)
        {
            switch (actionType)
            {
                case "Disconnect":
                    {
                        
                        break;
                    }

                default:
                    break;
            }

        }

        public ActionResult AttendanceRecord()
        {
            AttendanceDataConfig config = new AttendanceDataConfig();
            config.IPAddress = "103.88.232.188";
            config.PortNumber = 4370;
            config.MachineNumber = 1;
            config.DateTo = DateTime.Now.Date;
            var data = fetchAttendance(config);
            return View("View", data);
        }
    }
}