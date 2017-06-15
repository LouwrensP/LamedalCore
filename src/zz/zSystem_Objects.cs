using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.zz
{
    /// <summary>
    /// Shortcuts on object class
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Transformation_Extention)]
    [Test_IgnoreCoverage(enCode_TestIgnore.MethodIsShortCut)]
    public static class zSystem_Objects
    {
        /// <summary>
        /// Work on sender object to convert to other class.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <returns></returns>
        public static zSystem_ObjectsExtender zObject(this object sender)
        {
            return new zSystem_ObjectsExtender(sender);
        }

        ///// <summary>
        ///// Work on sender object to convert to other class.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="variable">The parameter.</param>
        ///// <returns></returns>
        //public static zSystemObjects_ExtenderList<T> zFind<T>(this T variable)
        //{
        //    return new zSystemObjects_ExtenderList<T>(variable);
        //}
        //

    }
}
