﻿namespace MiPrimeraAPI2.Controllers.DTOS
{
    public class PostProducto
    {
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int Id_Usuario { get; set; }
    }
}
