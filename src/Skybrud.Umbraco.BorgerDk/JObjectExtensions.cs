﻿using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Umbraco.BorgerDk {

    /// <summary>
    /// Various extensions methods for <code>JObject</code> that makes manual parsing easier.
    /// </summary>
    public static class JObjectExtensions {

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static JObject GetObject(this JObject obj, string propertyName) {
            if (obj == null) return null;
            return obj.GetValue(propertyName) as JObject;
        }

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>. If an object is found, it is
        /// parsed to the type of <code>T</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static T GetObject<T>(this JObject obj, string propertyName) {
            if (obj == null) return default(T);
            JObject child = obj.GetValue(propertyName) as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>. If an object is found, the
        /// object is parsed using the specified delegate <code>func</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        public static T GetObject<T>(this JObject obj, string propertyName, Func<JObject, T> func) {
            return obj == null ? default(T) : func(obj.GetValue(propertyName) as JObject);
        }

        /// <summary>
        /// Gets a string from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static string GetString(this JObject obj, string propertyName) {
            if (obj == null) return null;
            JToken property = obj.GetValue(propertyName);
            return property == null ? null : property.Value<string>();
        }

        /// <summary>
        /// Gets the string value from the property with the specified <code>propertyName</code> and parses it into an
        /// instance of <code>T</code> using the specified <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the string value.</param>
        public static T GetString<T>(this JObject obj, string propertyName, Func<string, T> callback) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : callback(property.Value<string>());
        }

        /// <summary>
        /// Gets a 32-bit integer (int) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static int GetInt32(this JObject obj, string propertyName) {
            if (obj == null) return default(int);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(int) : property.Value<int>();
        }

        /// <summary>
        /// Gets the integer value from the property with the specified <code>propertyName</code> and parses it into an instance of
        /// <code>T</code> using the specified <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        public static T GetInt32<T>(this JObject obj, string propertyName, Func<int, T> callback) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : callback(property.Value<int>());
        }

        /// <summary>
        /// Gets 64-bit integer (long) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static long GetInt64(this JObject obj, string propertyName) {
            if (obj == null) return default(long);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(long) : property.Value<long>();
        }

        /// <summary>
        /// Gets a float from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static float GetFloat(this JObject obj, string propertyName) {
            if (obj == null) return default(float);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(float) : property.Value<float>();
        }

        /// <summary>
        /// Gets a double from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static double GetDouble(this JObject obj, string propertyName) {
            if (obj == null) return default(double);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(double) : property.Value<double>();
        }

        /// <summary>
        /// Gets a boolean from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static bool GetBoolean(this JObject obj, string propertyName) {
            if (obj == null) return default(bool);
            JToken property = obj.GetValue(propertyName);
            return property != null && property.Value<bool>();
        }

        /// <summary>
        /// Gets an instance of <code>JArray</code> from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static JArray GetArray(this JObject obj, string propertyName) {
            return obj == null ? null : obj.GetValue(propertyName) as JArray;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from a property with the specified <code>propertyName</code> using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        public static T[] GetArray<T>(this JObject obj, string propertyName, Func<JObject, T> func) {

            if (obj == null) return null;

            JArray property = obj.GetValue(propertyName) as JArray;
            if (property == null) return null;

            return (
                from JObject child in property
                select func(child)
            ).ToArray();

        }

    }

}