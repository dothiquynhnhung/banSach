namespace WebsiteBanSach.Models
{
    public class GioHang
    {
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }
        public decimal TotalPrice => Sach.GiaBan.HasValue ? (Sach.GiaBan.Value * SoLuong) : 0;
        public int GetTotalItems(List<GioHang> gioHangList)
        {
            return gioHangList.Sum(item => item.SoLuong);
        }

        // Updated method to calculate total price in the cart
        public static decimal GetTotalPrice(List<GioHang> gioHangList)
        {
            return gioHangList.Sum(item => item.TotalPrice);
        }
    }

    
}