using Dios.Series.Interfaces;
using System;
using System.Collections.Generic;

namespace Dios.Series
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }
        public void Exclui(int id)
        {
            listaSerie[id].setExcluido(true);
        }

        public void Insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie retornaPorId(int id)
        {
            if (id > listaSerie.Count - 1)
                return null;

            return listaSerie[id];
        }
    }
}
