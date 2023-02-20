using DevExpress.ExpressApp.DC;

namespace DXApplication.Blazor.Common;

public class Enum
{
    public enum TrangThaiDuAn
    {
        [XafDisplayName("Nháp")] nhap = 0,
        [XafDisplayName("Mở")] mo = 1,
        [XafDisplayName("Đóng")] dong = 2,
        [XafDisplayName("Huỷ")] huy = 3,
    }
    public enum TrangThaiHopDong
    {
        [XafDisplayName("Nháp")] nhap = 0,
        [XafDisplayName("Hoàn thành")] hoanthanh = 1,
        [XafDisplayName("Huỷ")] huy = 2,
        [XafDisplayName("Hoàn")] hoan = 3,
    }
    public enum NhomNhanVien
    {
        [XafDisplayName("Nhân viên dài hạn")] nhanviendaihan = 0,
        [XafDisplayName("Nhân viên thoả thuận")] nhanvienthoathuan = 1,
        [XafDisplayName("Cộng tác viên")] congtacvien = 2,
        [XafDisplayName("Thực tập sinh")] thuctapsinh = 3,
    }
    public enum CapBac
    {
        [XafDisplayName("Giám đốc")] giamdoc = 0,
        [XafDisplayName("Quản lý")] quanly = 1,
        [XafDisplayName("Trưởng nhóm")] truongnhom = 2,
        [XafDisplayName("Nhân viên")] nhanvien = 3,
        [XafDisplayName("Không xác định")] khongxacdinh = 4,

    }
    public enum ThoiGianLamViec
    {
        [XafDisplayName("Toàn thời gian")] toanthoigian = 0,
        [XafDisplayName("Bán thời gian")] banthoigian = 1,

    }
    public enum TrangThaiViTriViecLam
    {
        [XafDisplayName("Chính thức")] chinhthuc = 0,
        [XafDisplayName("Thử việc")] thuviec = 1,
        [XafDisplayName("Không xác định")] khongxacdinh = 2,

    }
    public enum ThuocTinh_TaiLieu
    {
        [XafDisplayName("Normal")] Normal = 0,
        [XafDisplayName("Readonly")] Readonly = 1,
        [XafDisplayName("Archived")] Archived = 2,
        [XafDisplayName("Started")] Started = 3,
    }
    public enum LoaiHopDong
    {
        [XafDisplayName("Cung cấp (A)")] cungcapa = 0,
        [XafDisplayName("Cung cấp (B)")] cungcapb = 1,
    }
    public enum LoaiHopDongCungCap
    {
        [XafDisplayName("Hợp đồng kinh tế")] hdKinhTe = 0,
        [XafDisplayName("Hợp đồng dịch vụ")] hdDichVu = 1,
    }
    public enum LoaiCongNo
    {
        [XafDisplayName("Phải thu")] phaithu = 0,
        [XafDisplayName("Phải trả")] phaitra = 1,
    }
    public enum LoaiThuChi
    {
        [XafDisplayName("Thu")] thu = 0,
        [XafDisplayName("Chi")] chi = 1,
    }
}