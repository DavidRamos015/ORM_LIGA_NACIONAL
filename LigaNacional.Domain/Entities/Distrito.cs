﻿namespace LigaNacional.Domain.Entities
{
    public class Distrito : IEntityMaintenance
    {
        public virtual long Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual bool Activo { get; set; }
    }
}