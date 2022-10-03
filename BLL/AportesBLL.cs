using AP1_AP_Oly.DAL;
using AP1_AP_Oly.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AP1_AP_Oly.BLL
{
    public class AportesBLL
    {
        private Contexto _contexto;
        public AportesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Aportes aportes)
        {
            if (!Existe(aportes.AportesId))
                return this.Insertar(aportes);
            else
                return this.Modificar(aportes);

        }
        public bool Existe(int aportesId)
        {
            return _contexto.Aportes.Any(o => o.AportesId == aportesId);
        }

        private bool Insertar(Aportes aportes)
        {
            _contexto.Aportes.Add(aportes);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Aportes aportes)
        {
            _contexto.Entry(aportes).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public Aportes? Buscar(int aportesId)
        {
            return _contexto.Aportes
                    .Where(o => o.AportesId == aportesId)
                    .AsNoTracking()
                    .SingleOrDefault();

        }
        public bool Editar(Aportes aportes)
        {
            if (!Existe(aportes.AportesId))
                return this.Insertar(aportes);
            else
                return this.Modificar(aportes);
        }
        public bool Eliminar(Aportes aportes)
        {
            _contexto.Entry(aportes).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public List<Aportes> GetList(Expression<Func<Aportes, bool>> Criterio)
        {
            return _contexto.Aportes
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
    }
}
