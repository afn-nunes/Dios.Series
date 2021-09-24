using System;

namespace Dios.Series
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        private bool Excluido { get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "  Gênero: " + this.Genero + Environment.NewLine;
            retorno += "  Título: " + this.Titulo + Environment.NewLine;
            retorno += "  Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "  Ano de início: " + this.Ano + Environment.NewLine;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool isRemoved()
        {
            return this.Excluido;
        }

        public void setExcluido(bool excluido)
        {
            this.Excluido = excluido;
        }

    }
}
