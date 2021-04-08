using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstraiProdottiFiniti
{
    public class BrandContoLavoro
    {
        public string Brand { get; set; }
        public string AreaDiProduzione { get; set; }

        public BrandContoLavoro(string brand, string areaDiProduzione)
        {
            Brand = brand;
            AreaDiProduzione = areaDiProduzione;
        }

        public override string ToString()
        {
            return Brand;
        }
        public static List<BrandContoLavoro> EstraiLista()
        {
            List<BrandContoLavoro> lista = new List<BrandContoLavoro>();
            lista.Add(new BrandContoLavoro("Gucci", "C00030"));
            lista.Add(new BrandContoLavoro("YSL", "C00155"));
            return lista;
        }
    }


}
