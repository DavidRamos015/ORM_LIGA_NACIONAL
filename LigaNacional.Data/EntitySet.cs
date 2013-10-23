using LigaNacional.Domain;

namespace LigaNacional.Data
{
    public class EntitySet
    {
        public static void DefaultValues(IEntity entity)
        {
            entity.Activo = true;
        }

        public static void InactivateData(IEntity entity)
        {
            entity.Activo = false;
        }
    }
}