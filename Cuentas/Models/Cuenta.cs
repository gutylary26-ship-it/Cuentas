namespace Cuentas.Models
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string numero { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public double creditos { get; set; }
        public double debitos { get; set; }
        public double balance { get; set; }

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
    }
}
