using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LamedalCore.zPublicClass;
using LamedalCore.zPublicClass.Test;
using LamedalCore.zz;

namespace LamedalCore.lib
{
    public sealed class lib_Test
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;


        /// <summary>Determines whether two objects are equal using Json serialisation.</summary>
        /// <param name="Object1">The first object</param>
        /// <param name="Object2">The second object</param>
        /// <param name="errorMsg">The error message</param>
        /// <returns>bool</returns>
        public bool ObjectsAreEqual(object Object1, object Object2, out string errorMsg)
        {
            return _lamed.lib.IO.Json.Object_IsEqual(Object1, Object2, out errorMsg);
        }

        /// <summary>Converts the Object to string.</summary>
        /// <param name="Object">The object.</param>
        /// <returns></returns>
        public string Object_2JsonStr(object Object)
        {
            return _lamed.lib.IO.Json.Convert_FromObject(Object);
        }

        /// <summary>Creates the object from json string.</summary>
        /// <param name="json">The json</param>
        /// <returns>T</returns>
        public T Object_FromJsonStr<T>(string json)
        {
            return _lamed.lib.IO.Json.Convert_ToType<T>(json);
        }

        /// <summary>Configuration settings for unit tests.</summary>
        /// <param name="folderApplication">The folder application.</param>
        /// <param name="folderTestCases">The folder excel test cases.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="configFile">The configuration file.</param>
        /// <returns></returns>
        public bool ConfigSettings(out string folderApplication, out string folderTestCases, out pcTest_ConfigData config, out string configFile)
        {
            var result = _lamed.lib.IO.File.Config_UnitTests(out folderApplication, out folderTestCases, out config, out configFile);
            return result;
        }
    }
}
