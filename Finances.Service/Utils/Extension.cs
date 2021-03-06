﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Finances.Service.Utils
{
    public static class Extension
    {
        public static T GetCustomAttribute<T>(this MemberInfo memberInfo) where T : Attribute
        {
            return memberInfo.GetCustomAttributes(typeof(T), true).FirstOrDefault() as T;
        }

        public static object GetPropertyValue<T>(string propertyName, T entity) where T : class
        {
            try
            {
                return typeof(T).GetProperty(propertyName).GetValue(entity, null);
            }
            catch (Exception e)
            {

                return null;
            }
        }

        public static string GetPropertyNameByDescription<T>(string descriptionColumn) where T:class
        {
            var properties = typeof(T).GetProperties();

            foreach (var propertyInfo in properties)
            {
                try
                {
                    var description = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);

                    DescriptionAttribute descriptioAttribute = (DescriptionAttribute)description[0];

                    if(descriptioAttribute.Description == descriptionColumn)
                    {
                        return propertyInfo.Name;
                    }
                    else
                    {
                        continue;
                    }

                }
                catch (Exception e)
                {
                    continue;
                }
            }

            return string.Empty;
        }

        public static string[] GetPropertiesDescription<T>() where T : class
        {
            ICollection<string> propertiesDescription = new List<string>();

            var properties = typeof(T).GetProperties();

            foreach (var propertyInfo in properties)
            {
                try
                {
                    var description = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);

                    DescriptionAttribute descriptioAttribute = (DescriptionAttribute)description[0];

                    propertiesDescription.Add(descriptioAttribute.Description);
                }
                catch (Exception e)
                {
                    continue;
                }
            }

            return propertiesDescription.ToArray();

        }
    }
}
