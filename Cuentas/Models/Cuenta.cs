namespace Cuentas.Models
{
    public class Cuenta
    {
        private string estado = "Activo";

        public int Id { get; set; }
        public string numero { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public double creditos { get; set; }
        public double debitos { get; set; }
        public double balance { get; set; }

        public string Estado { get; set; } = "Activo";



        public Cuenta() 
        { 
            this.creditos = 0;
            this.debitos = 0;
            this.balance = 0;
        }

        public Cuenta(int Id, string numero, string descripcion, double creditos, double debitos, double balance)
        {
            this.Id = Id;
            this.numero = numero;
            this.descripcion = descripcion;
            this.creditos = creditos;
            this.debitos = debitos;
            this.balance = balance;
           
        }

        public class Cuentas
        {
            public int CuentaId { get; set; }
            public string Nombre { get; set; }

            // Relación uno-a-muchos
            public virtual ICollection<Movimiento> Movimientos { get; set; }
        }



        public void setbalance()
        {
            this.balance = this.creditos - this.debitos;
        }

        public void setCredito(double credito)
        {
            this.creditos += credito;
        }

        public void setDebito(double monto)
        {
            this.debitos += monto;
        }

    }
}
