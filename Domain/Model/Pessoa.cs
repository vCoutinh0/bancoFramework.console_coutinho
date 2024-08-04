namespace Domain.Model
{
    public class Pessoa : BaseModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Pessoa()
        {
            Id = ObterInputInt("Número de identificação");
            Nome = ObterInputString("Nome");
            Cpf = ObterInputCpf();
        }
    }
}
