using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinClientApp.Model
{
    public class Barang
    {
        public string KodeBarang { get; set; }
        public int IdJenisMotor { get; set; }
        public int KategoriId { get; set; }
        public string Nama { get; set; }
        public string Stok { get; set; }
        public string HargaBeli { get; set; }
        public string HargaJual { get; set; }
        public string TanggalBeli { get; set; }
    }
}
