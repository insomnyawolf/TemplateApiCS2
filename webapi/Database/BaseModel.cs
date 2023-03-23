using System.Reflection;

namespace webapi.Database
{
    public abstract class BaseModel<T> where T : BaseModel<T>
    {
        public virtual long Id { get => (long)RealIdFieldProperty.GetValue(this); set => RealIdFieldProperty.SetValue(this, value); }
        private PropertyInfo RealIdFieldProperty { get; set; }
        private PropertyInfo[] FilteredProperties { get; }
        public PropertyInfo[] GetRelevantPropertyInfos() => FilteredProperties;

        public BaseModel()
        {
            var type = GetType();

            var cache = new List<PropertyInfo>();

            foreach (var propertyInfo in type.GetProperties())
            {
                if(propertyInfo.Name == nameof(Id))
                {
                    RealIdFieldProperty = propertyInfo;
                }
                if (propertyInfo?.GetMethod?.IsPublic == true)
                {
                    if (propertyInfo.PropertyType.IsValueType || propertyInfo.PropertyType == typeof(string))
                    {
                        cache.Add(propertyInfo);
                    }
                }
            }

            FilteredProperties = cache.ToArray();
        }

        public void UpdateValuesFrom(T model)
        {
            for (int i = 0; i < FilteredProperties.Length; i++)
            {
                var prop = FilteredProperties[i];

                if (prop.SetMethod is not null)
                {
                    var value = prop.GetValue(model, null);
                    prop.SetValue(this, value, null);
                }
            }
        }
    }
}
