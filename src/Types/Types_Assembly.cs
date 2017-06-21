using System;
using System.Diagnostics;
using System.Reflection;
using JetBrains.Annotations;

namespace LamedalCore.Types
{
    public sealed class Types_Assembly
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library

        /// <summary>Returns the Assembly from the lamedal core.</summary>
        /// <returns></returns>
        public Assembly From_LamedalCore()
        {
            return From_Type<LamedalCore_>();
        }

        /// <summary>Return the Assembly_Get of Lamedal library.</summary>
        /// <returns></returns>
        public Assembly From_Type<T>()
        {
            return From_Type(typeof(T));
        }

        /// <summary>Return the Assembly_Get of Lamedal library.</summary>
        /// <returns></returns>
        public Assembly From_Type(Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        /// <summary>Loads the Assembly_Get for the object</summary>
        /// <param name="sender">The sender.</param>
        /// <returns></returns>
        public Assembly From_Object(object sender)
        {
            return From_Type(sender.GetType());
        }

        /// <summary>Return the type from the assembly.</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="typeAsStr">The type as string.</param>
        /// <returns></returns>
        public Type To_Type(Assembly assembly, string typeAsStr = "System.Object")
        {
            Type type = assembly.GetType(typeAsStr);
            return type;
            object myInstance = Activator.CreateInstance(type);
        }

        /// <summary>Loads an instance of the types</summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public object To_Object(Assembly assembly, Type type)
        {
            object myInstance = Activator.CreateInstance(type);
            return myInstance;
        }

        /// <summary>
        /// Get the assembly exe name
        /// </summary>
        public string To_Name(Assembly assembly)
        {
            string rootName = (assembly.ManifestModule).Name;
            return rootName;
        }

        /// <summary>
        /// Return the Namespace of the assembly.
        /// </summary>
        /// <param name="assembly">The assembly</param>
        /// <returns>string</returns>
        public string To_Namespace(Assembly assembly)
        {
            var rootName = To_Name(assembly);
            rootName = rootName.Replace(".dll", "");
            rootName = rootName.Replace(".exe", "");
            return rootName;
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public string To_FilePath(Assembly assembly)
        {
            return _lamed.lib.IO.Parts._Format2Slash(assembly.Location);
        }

        /// <summary>
        /// Function to get assembly path.
        /// </summary>
        /// <param name="name">The assembly name</param>
        /// <returns>string</returns>
        [Pure]
        public string To_FilePath(AssemblyName name)
        {
            string result = Assembly.Load(name).Location;
            return _lamed.lib.IO.Parts._Format2Slash(result);
        }

        /// <summary>
        /// Get the current process name
        /// </summary>
        /// <returns>string</returns>
        public string CurrentProcessPathName()
        {
            var process = CurrentProcess();
            var assemblyName = process.ProcessName + ".exe";
            return assemblyName;
        }

        /// <summary>Returns the currents process.</summary>
        /// <returns></returns>
        public Process CurrentProcess()
        {
            var process = Process.GetCurrentProcess();
            return process;
        }

    }
}