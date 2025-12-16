namespace Cuentas.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int Tipo { get; set; } // 1: Credito, 2: Debito 
        public string? Concepto { get; set; }
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCuenta { get; set; }

        public Movimiento()
        {
            this.Id = 0;
        }


        public class Movimientos
        {
            public int MovimientoId { get; set; }
            public DateTime Fecha { get; set; }
            public decimal Monto { get; set; }

            // Clave foránea
            public int CuentaId { get; set; }
            public virtual Cuenta Cuenta { get; set; }
        }


        public Movimiento(int id, int tipo, string? concepto, double monto, DateTime fecha, int IdCuenta)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Concepto = concepto;
            this.Monto = monto;
            this.Fecha = fecha;
            this.IdCuenta = IdCuenta;
        }



    }
}

