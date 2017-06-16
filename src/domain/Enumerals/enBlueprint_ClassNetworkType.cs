using LamedalCore.domain.Attributes;

namespace LamedalCore.domain.Enumerals
{
    /// <summary>
    /// 
    /// </summary>
    public enum enBlueprint_ClassNetworkType
    {
        /// <summary>
        /// Ignore the class in transformations. This type of class should be changed or be moved to other parts of the CTIN network.
        /// </summary>
        [BlueprintRule_Field(Name = "Undefined", Description = "This class is not defined")]
        Undefined = 0,

        /// <summary>
        /// Class Transformation Information Network
        /// </summary>
        [BlueprintRule_Field(Name ="CTIN", Description = "Class Transformation Information Network ", 
                        Class_IsSingelton = true, Methods_None = true, Properties_OneOrMany = true)]
        CTIN,

        /// <summary>
        /// Class Transformation Information methods. This is a class with only methods.
        /// </summary>
        [BlueprintRule_Field(Name = "Node Actions", Description = "Class Transformation action node network.",
                        Methods_OneOrMany = true, Properties_None = true, Fields_None = true, Fields_OneOrMany_SingletonFields = true)]
        Node_Action,

        /// <summary>
        /// This node contains mainly a list of data items that can be used by other nodes.
        /// </summary>
        [BlueprintRule_Field(Name = "Node Data", Description = "This node contains mainly a list of data items that can be used by other nodes.")]
        Node_Data,

        /// <summary>
        /// State class. This is a very simple class with state info.
        /// </summary>
        [BlueprintRule_Field(Name = "Node State information", Description = "Class with state (properties and methods) info",
                        Methods_OneOrMany = false, Fields_OneOrMany = true, Properties_OneOrMany = true, Class_HasConstructor_Private = true)]
        Node_State,

        /// <summary>
        /// Class with a private constructor and can have methods and fields. This class has a static method that will create the class and populate the fields.
        /// </summary>
        [BlueprintRule_Field(Name = "Node action & data class", Description = "Class with a private constructor and can have methods and fields. This class has a static method that will create the class and populate the fields.",
                        Methods_1Static = true, Fields_OneOrMany = true, Properties_OneOrMany = true, Class_HasConstructor_Private = true)]
        Node_ActionData,

        /// <summary>
        /// Node State controller. This is a very simple class implement method zzState(this nodeStateType state).
        /// </summary>
        [BlueprintRule_Field(Name = "Node State controller", Description = "Static class that implement method zzState(this nodeStateType state)",
                        Methods_1Static = true, Class_IsStatic = true, Methods_zzState = true, Fields_None = true, Properties_None = true)]
        Node_StateController,

        /// <summary>
        /// Class Transformation Information linking
        /// </summary>
        [BlueprintRule_Field(Name = "Node Links", Description = "Class Transformation link definition",
                        Methods_None = true, Properties_OneOrMany = true)]
        Node_Link,

        [BlueprintRule_Field(Name = "Node Singleton", Description = "Class that hold rule based information in memory", Class_IsSingelton = true)]
        Transformation_Singleton,

        /// <summary>
        /// Class Transformation Information manual linking
        /// </summary>
        [BlueprintRule_Field(Name = "Manual Extention Methods", Description = "Manual defintion of extention methods",
                        Methods_OneOrMany = true, Properties_OneOrMany = false, Class_IsStatic = true)]
        Transformation_Connector,

        /// <summary>
        /// Class Transformation Information automatic linking
        /// </summary>
        [BlueprintRule_Field(Name = "Automatic Extention Methods", Description = "Shortcut extention methods.",
                        Methods_OneOrMany = true, Properties_OneOrMany = false, Class_IsStatic = true, Class_IsGenerated = true)]
        Transformation_Extention,

        [BlueprintRule_Field(Name = "Blueprint Active Template", Description = "Active templates are used in code generation.")]
        ActiveTemplate,

        /// <summary>
        /// Class Transformation Information Factory class. This create different object in a consistent manner.
        /// </summary>
        [BlueprintRule_Field(Name = "CTI Factory", Description = "CTI Factory class. This class will expose a statefull class to the network.")]
        CTI_Factory,

        [BlueprintRule_Field(Name = "Visual Studio Ignore", Description = "CTI class that can be ignored. Test classes should be ignored and are marked with this attribute.")]
        VS_Ignore,

        [BlueprintRule_Field(Name = "Visual Studio Static", Description = "Normal Visual Studio classic class library.", Class_IsStatic = true)]
        VS_Static,

        [BlueprintRule_Field(Name = "Visual Studio Class", Description = "Visual Studio Stateful class.", Class_IsStatic = false)]
        StandardClass,

        [BlueprintRule_Field(Name = "Blueprint Rule definition", Description = "This is an attribute class that define blueprint rules", Class_IsStatic = false)]
        BlueprintRuleDef,

        [BlueprintRule_Field(Name = "Unit Tests", Description = "This class contains only test data", Class_IsStatic = false)]
        XUnitTestData, 

        [BlueprintRule_Field(Name = "Unit Test Methods", Description = "This class contains only test methods", Class_IsStatic = false)]
        XUnitTestMethods
    }
}