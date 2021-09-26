namespace EAT.Infrastruture.WPF.Models
{
    public static class SimpleMapper
    {
        public static void Map<T>(T from, T to)
        {
            foreach (var propertyInfo in @from.GetType().GetProperties())
            {
                foreach (var property in to.GetType().GetProperties())
                {
                    if (property == propertyInfo)
                        property.SetValue(to, propertyInfo.GetValue(from));
                }
            }
        }
    }
}
