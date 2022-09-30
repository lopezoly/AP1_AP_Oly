using AP1_AP_Oly.DAL;
using AP1_AP_Oly.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AP1_AP_Oly.BLL
{
    public class RegistrosBLL
    {
        private Contexto _contexto;
        public RegistrosBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Registros registro)
        {
            if (!Existe(registro.RegistroId))
                return this.Insertar(registro);
            else
                return this.Modificar(registro);

        }
        public bool Existe(int registroId)
        {
            return _contexto.Registros.Any(o => o.RegistroId == registroId);
        }

        private bool Insertar(Registros registro)
        {
            _contexto.Registros.Add(registro);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Registros registro)
        {
            _contexto.Entry(registro).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public Registros? Buscar(int registroid)
        {
            return _contexto.Registros
                    .Where(o => o.RegistroId == registroid)
                    .AsNoTracking()
                    .SingleOrDefault();

        }
        public bool Editar(Registros registro)
        {
            if (!Existe(registro.RegistroId))
                return this.Insertar(registro);
            else
                return this.Modificar(registro);
        }
        public bool Eliminar(Registros registro)
        {
            _contexto.Entry(registro).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public List<Registros> GetList(Expression<Func<Registros, bool>> Criterio)
        {
            return _contexto.Registros
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
