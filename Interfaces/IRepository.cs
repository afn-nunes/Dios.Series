using System.Collections.Generic;

namespace Dios.Series.Interfaces
{
    interface IRepository<T>
    {
        List<T> Lista();

        T retornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}
