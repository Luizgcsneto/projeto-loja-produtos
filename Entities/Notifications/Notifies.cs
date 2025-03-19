using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }
        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notificacoes { get; set; }

        public bool validaPropriedadeString(string valor, string nomePropriedade)
        {
            if(string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }
            return true;
        }

        public bool validaPropriedadeInt(int valor, string nomePropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    Mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }
            return true;
        }

    }

    
}
